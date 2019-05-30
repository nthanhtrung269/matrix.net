﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Matrix.Framework.Api.Response;
using Matrix.Framework.Business;
using Matrix.Web.Business.Services;
using RestSharp;

namespace Matrix.Web.Business.Proxy
{
    public class ConfigurationService : Service, IConfigurationService
    {
        private RestClient Api { get; set; }

        public ConfigurationService(IServiceContext context)
            : base(context)
        {
            Api = new RestClient(context.Configurator);
        }

        public async Task<List<KeyValuePair<string, string>>> GetSettings(Guid application)
        {
            var result = new List<KeyValuePair<string, string>>();

            var request = new RestRequest("/applications/{application}/configuration", Method.GET);

            request.AddUrlSegment("application", application);

            var response = await Api.ExecuteTaskAsync<SuccessResponse<List<KeyValuePair<string, string>>>>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK) && response.Data != null)
            {
                foreach (var i in response.Data.Data)
                {
                    if (!string.IsNullOrEmpty(i.Key) && !string.IsNullOrEmpty(i.Value))
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }

        public async Task<string> GetSettings(Guid application, string key)
        {
            var result = string.Empty;

            var request = new RestRequest("/applications/{application}/configuration/{key}", Method.GET);

            request.AddUrlSegment("application", application);
            request.AddUrlSegment("key", key);

            var response = await Api.ExecuteTaskAsync<string>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<Guid> Create(Guid application, string key, string value)
        {
            var result = Guid.Empty;

            var request = new RestRequest("/applications/{application}/configuration", Method.POST);

            request.AddJsonBody(new
            {
                application,
                key,
                value
            });

            var response = await Api.ExecuteTaskAsync<Guid>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<bool> Update(Guid application, string key, string value)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/configuration", Method.PUT);

            request.AddJsonBody(new
            {
                application,
                key,
                value
            });

            var response = await Api.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }

        public async Task<bool> Delete(Guid application, string key)
        {
            var result = false;

            var request = new RestRequest("/applications/{application}/configuration/{key}", Method.DELETE);

            request.AddUrlSegment("application", application);
            request.AddUrlSegment("key", key);

            var response = await Api.ExecuteTaskAsync<bool>(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                result = response.Data;
            }

            return result;
        }
    }
}