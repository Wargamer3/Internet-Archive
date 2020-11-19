using Api;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _4Chan_Crawler
{
    public abstract class ApiHelper
	{
		private readonly HttpClient Client;
		private readonly string Origin;
		private readonly JsonSerializer JsonSerializer;
		
		public ApiHelper(HttpClient Client, string Origin)
		{
			this.Client = Client;
			this.Origin = Origin;
			JsonSerializer = JsonSerializer.Create();
		}

		private HttpRequestMessage CreateRequest(Uri Uri, DateTimeOffset ModifiedSince)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Uri);
			request.Headers.IfModifiedSince = ModifiedSince;
			request.Headers.Add("Origin", Origin);

			return request;
		}

		private async Task<HttpResponseMessage> DoCall(Uri Uri, DateTimeOffset ModifiedSince, CancellationToken CancellationToken)
		{
			using (HttpRequestMessage request = CreateRequest(Uri, ModifiedSince))
			{
				return await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken);
			}
		}

		protected async Task<ApiResponse<T>> MakeApiCall<T>(Uri Uri, DateTimeOffset ModifiedSince, CancellationToken CancellationToken)
		{
			using (HttpResponseMessage ResponseMessage = await NetworkPolicies.HttpApiPolicy.ExecuteAsync(() => DoCall(Uri, ModifiedSince, CancellationToken)))
			{
				if (ResponseMessage.StatusCode == HttpStatusCode.NotModified)
				{
					return new ApiResponse<T>(default, YotsubaResponseType.NotModified);
				}

				if (ResponseMessage.StatusCode == HttpStatusCode.NotFound)
				{
					return new ApiResponse<T>(default, YotsubaResponseType.NotFound);
				}

				if (!ResponseMessage.IsSuccessStatusCode)
					throw new WebException($"Received an error code: {ResponseMessage.StatusCode}");

				using (Stream ResponseStream = await ResponseMessage.Content.ReadAsStreamAsync())
				using (StreamReader StreamReader = new StreamReader(ResponseStream))
				using (JsonReader Reader = new JsonTextReader(StreamReader))
				{
					T Response = JsonSerializer.Deserialize<T>(Reader);

					return new ApiResponse<T>(Response, YotsubaResponseType.Ok);
				}
			}
		}
	}
}
