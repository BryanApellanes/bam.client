using Newtonsoft.Json;
using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class Lister<T> : ApiCaller, ILister<T>
    {
        public Lister(ApiConfig sdkConfig, IListRequestCreator<T> requestLister, IDataManagementContext dataManagementContext): base(sdkConfig, dataManagementContext)
        {
            this.ApiClient = new ApiClient(sdkConfig);
            this.RequestCreator = requestLister;
            this.HttpMethod = HttpMethod.Get;
        }

        public IListRequestCreator<T> RequestCreator { get; set; }

        public Task<IListRequest<T>> CreateRequestAsync(IListArguments arguments)
        {
            return this.RequestCreator.CreateRequestAsync(arguments);
        }

        public async Task<IListResult<T>> ListAsync(IListArguments arguments)
        {
            if (this.ApiClient == null)
            {
                throw new ArgumentNullException(nameof(ApiClient));
            }

            IListRequest<T> request = await this.CreateRequestAsync(arguments);
            this.Info($"Creating {typeof(T).Name}: {JsonConvert.SerializeObject(request.Data, Formatting.Indented)}");
            IListResult<T> result = new ListResult<T>(arguments);
            try
            {
                RequestParameters requestParameters = await this.GetRequestParametersAsync(this.ApiConfig);
                HandlePathArguments(arguments, requestParameters);

                if (arguments.SearchParameter != null)
                {
                    requestParameters.QueryParameters.Add("search", arguments.SearchParameter.ValueToString());
                }

                if (arguments.FilterParameter != null)
                {
                    requestParameters.QueryParameters.Add("filter", arguments.FilterParameter.ValueToString());
                }

                if (arguments.QParameter != null)
                {
                    requestParameters.QueryParameters.Add("q", arguments.QParameter.Value);
                }

                IResponse<T[]> response = await this.CallApiAsync<T[]>(this.ApiPathResolver.ResolvePath<T>(arguments), requestParameters, this.ApiConfig);
                if (this.IsSuccessCode(response))
                {
                    result.List = response.Data;
                }
                else
                {
                    throw new ApiException(JsonConvert.DeserializeObject<ApiErrorResponse>(response.RawContent));
                }
            }
            catch (Exception ex)
            {
                this.Error($"Exception creating {typeof(T).Name}: {ex.Message}", ex);
                result = new ListResult<T>(arguments, ex);
            }

            return result;
        }

        async Task<IListRequest> ILister.CreateRequestAsync(IListArguments args)
        {
            return await this.CreateRequestAsync(args);
        }

        async Task<IListResult> ILister.ListAsync(IListArguments args)
        {
            return await this.ListAsync(args);
        }
    }
}
