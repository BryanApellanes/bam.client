// <copyright file="Creator{T}.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Bam.Sdk.Client;

namespace Bam.Client
{
    public class Creator<T> : ApiCaller, ICreator<T>
    {
        public Creator(ApiConfig apiConfig, ICreateRequestCreator<T> requestCreator, IDataManagementContext dataManagementContext): base(apiConfig, dataManagementContext)
        {
            this.ApiClient = new ApiClient(apiConfig);
            this.RequestCreator = requestCreator;
            this.HttpMethod = HttpMethod.Post;
        }

        public ICreateRequestCreator<T> RequestCreator { get; set; }

        public Task<ICreateRequest<T>> CreateRequestAsync(ICreateArguments<T> args)
        {
            return RequestCreator.CreateRequestAsync(args);
        }

        public async virtual Task<ICreateResult<T>> CreateAsync(ICreateArguments<T> args)
        {
            if (ApiClient == null)
            {
                throw new ArgumentNullException(nameof(ApiClient));
            }
           
            ICreateRequest<T> request = await CreateRequestAsync(args);
            Info($"Creating {typeof(T).Name}: {JsonConvert.SerializeObject(request.Data, Formatting.Indented)}");
            CreateResult<T> result = new CreateResult<T>(args);
            try
            {
                RequestParameters requestParameters = await GetRequestParametersAsync(ApiConfig);
                requestParameters.Data = request.Data;
                HandlePathArguments(args, requestParameters);

                IResponse<T> response = await CallApiAsync<T>(ApiPathResolver.ResolvePath<T>(args), requestParameters, ApiConfig);
                if (!IsSuccessCode(response))
                {
                    throw new ApiException(JsonConvert.DeserializeObject<ApiErrorResponse>(response.RawContent));
                }
                result.Response = response;
                result.CreatedObject = response.Data;
            }
            catch (Exception ex)
            {
                Error($"Exception creating {typeof(T).Name}: {ex.Message}", ex);
                result = new CreateResult<T>(args, ex);
            }

            return result;
        }
    }
}
