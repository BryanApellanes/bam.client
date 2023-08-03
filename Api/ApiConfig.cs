// <copyright file="ApiConfig.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Bam.Sdk.Client;
using YamlDotNet.Serialization;

namespace Bam.Client
{
    /// <summary>
    /// Represents the minimal configuration used by the management Sdk during wizard operations.
    /// </summary>
    public class ApiConfig
    {
        public static explicit operator Configuration(ApiConfig sdkConfig)
        {
            return new ApiConfiguration(sdkConfig.OrgUrl, sdkConfig.Token);
        }

        /// <summary>
        /// Identifier for ISO 8601 DateTime Format.
        /// </summary>
        /// <remarks>See https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8 for more information.</remarks>
        public const string ISO8601_DATETIME_FORMAT = "o";

        public ApiConfig() 
        {
            this.AuthorizationMode = AuthorizationMode.SSWS;
            this.UserAgent = BamWizard.GetUserAgent();
        }

        public ApiConfig(string orgUrl, string token)
        {
            this.AuthorizationMode = AuthorizationMode.SSWS;
            this.UserAgent = BamWizard.GetUserAgent();
            this.OrgUrl = orgUrl;
            this.Token = token;
            if (Global == null)
            {
                Global = this;
            }
        }

        public static ApiConfig Global
        {
            get;
            set;
        }

        [YamlMember(Alias = "orgUrl")]
        public string OrgUrl { get; set; }

        [YamlMember(Alias = "token")]
        public string Token { get; set; }

        [YamlIgnore]
        [JsonIgnore]
        public string UserAgent { get; set; }

        [YamlIgnore]
        public string Domain
        {
            get
            {
                if (!string.IsNullOrEmpty(OrgUrl))
                {
                    Uri uri = new Uri(OrgUrl);
                    return uri.Host;
                }
                return string.Empty;
            }
        }

        [YamlIgnore]
        [JsonIgnore]
        public AuthorizationMode AuthorizationMode { get; set; }

        private string dateTimeFormat;

        [YamlIgnore]
        [JsonIgnore]
        public virtual string DateTimeFormat
        {
            get
            {
                if (string.IsNullOrEmpty(this.dateTimeFormat))
                {
                    return ISO8601_DATETIME_FORMAT;
                }

                return this.dateTimeFormat;
            }

            set
            {
                this.dateTimeFormat = value;
            }
        }

        [YamlIgnore]
        [JsonIgnore]
        public bool IsPrivateKeyMode
        {
            get
            {
                return AuthorizationMode == AuthorizationMode.PrivateKey;
            }
        }

        /// <summary>
        /// Determines if the configuration file exists.
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static bool Exists(string configPath = null)
        {
            configPath = configPath ?? BamWizardSettings.WIZARD_CONFIGURATION_FILE_PATH;
            string filePath = new FileInfo(HomePath.Resolve(configPath)).FullName;
            return File.Exists(filePath);
        }

        /// <summary>
        /// Deletes the configuration file.
        /// </summary>
        /// <param name="configPath"></param>
        public static void Delete(string configPath = null)
        {
            configPath = configPath ?? BamWizardSettings.WIZARD_CONFIGURATION_FILE_PATH;
            string filePath = new FileInfo(HomePath.Resolve(configPath)).FullName;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Loads the configuration file.
        /// </summary>
        /// <param name="configPath">The path to the configuration file.</param>
        /// <returns>SdkConfig</returns>
        public static ApiConfig Load(string configPath = null)
        {
            configPath = configPath ?? BamWizardSettings.WIZARD_CONFIGURATION_FILE_PATH;
            string filePath = new FileInfo(HomePath.Resolve(configPath)).FullName;
            if (!File.Exists(filePath))
            {
                return null;
            }

            Deserializer deserializer = new Deserializer();
            return deserializer.Deserialize<ApiConfig>(File.ReadAllText(filePath));
        }

        /// <summary>
        /// Tries to save the configuration file.
        /// </summary>
        /// <param name="ex">The exception that occurred, if any.</param>
        /// <returns>True if the file was saved.</returns>
        public bool TrySave(out Exception ex)
        {
            return this.TrySave(BamWizardSettings.WIZARD_CONFIGURATION_FILE_PATH, out ex);
        }

        /// <summary>
        /// Tries to save the configuration file.
        /// </summary>
        /// <param name="configPath">The path to the configuration file.</param>
        /// <param name="ex">The exception that occurred, if any. </param>
        /// <returns>True if the file was save.</returns>
        public bool TrySave(string configPath, out Exception ex)
        {
            ex = null;
            try
            {
                this.Save(configPath);
                return true;
            }
            catch (Exception e)
            {
                ex = e;
            }

            return false;
        }

        /// <summary>
        /// Saves the configuration file.
        /// </summary>
        /// <param name="configPath">The path to save the configuration to.</param>
        public void Save(string configPath = null)
        {
            configPath = configPath ?? BamWizardSettings.WIZARD_CONFIGURATION_FILE_PATH;
            string filePath = HomePath.Resolve(configPath);
            Serializer serializer = new Serializer();
            File.WriteAllText(filePath, serializer.Serialize(this));
        }

        public string ConvertToString(object obj)
        {
            return ConvertToString(obj, this.DateTimeFormat);
        }

        public static string ConvertToString(object obj, string dateTimeFormat = null)
        {
            dateTimeFormat = dateTimeFormat ?? ISO8601_DATETIME_FORMAT;
            if (obj is DateTime dateTime)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return dateTime.ToString(dateTimeFormat);
            }
            if (obj is DateTimeOffset dateTimeOffset)
            {
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return dateTimeOffset.ToString(dateTimeFormat);
            }
            if (obj is bool boolean)
            {
                return boolean ? "true" : "false";
            }

            return Convert.ToString(obj, CultureInfo.InvariantCulture);
        }
    }
}
