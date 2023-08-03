using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Bam.Sdk.Client;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Bam.Client
{
    public class ApiSerializer : IRestSerializer, ISerializer, IDeserializer
    {
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        public ContentType ContentType
        {
            get;
            set;
        }

        public ISerializer Serializer => this;

        public IDeserializer Deserializer => this;

        public string[] AcceptedContentTypes => new string[] { "application/json" };

        public SupportsContentType SupportsContentType => (contentType) => contentType.Equals(ContentType.Json);

        public DataFormat DataFormat => DataFormat.Json;

        public string Serialize(object obj)
        {
            if (obj != null && obj is Bam.Sdk.Model.AbstractOpenAPISchema)
            {
                // the object to be serialized is an oneOf/anyOf schema
                return ((Bam.Sdk.Model.AbstractOpenAPISchema)obj).ToJson();
            }
            else
            {
                return JsonConvert.SerializeObject(obj, _serializerSettings);
            }
        }

        public T Deserialize<T>(RestResponse response)
        {
            return (T)Deserialize(typeof(T), response);
        }

        internal object Deserialize(Type type, RestResponse response)
        {
            if (type == typeof(byte[])) // return byte array
            {
                return response.RawBytes;
            }

            if (type == typeof(Stream))
            {
                var bytes = response.RawBytes;
                if (response.Headers != null)
                {
                    var filePath = Path.GetTempPath();
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in response.Headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, bytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                var stream = new MemoryStream(bytes);
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(response.Content, null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return Convert.ChangeType(response.Content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                JToken token = JToken.Parse(response.Content);
                if(token is JArray)
                {
                    Type elementType = type.GetElementType();
                    Type listType = typeof(List<>);
                    Type genericListType = listType.MakeGenericType(elementType);
                    IList list = (IList)Activator.CreateInstance(genericListType);
                    foreach (var item in (JArray)token)
                    {
                        list.Add(item.ToObject(elementType));
                    }
                    MethodInfo method = genericListType.GetMethod("ToArray");
                    return method.Invoke(list, new object[] { });
                }
                return JsonConvert.DeserializeObject(response.Content, type, _serializerSettings);
            }
            catch (Exception e)
            {
                throw new Exception("Exception deserializing response", e);
            }
        }
        private static string SanitizeFilename(string filename)
        {
            Match match = Regex.Match(filename, @".*[/\\](.*)$");
            return match.Success ? match.Groups[1].Value : filename;
        }

        public string Serialize(Parameter parameter)
        {
            return Serialize(parameter.Value);
        }
    }
}
