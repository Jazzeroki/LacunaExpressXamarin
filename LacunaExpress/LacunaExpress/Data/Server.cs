using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft;
using LacunaExpanseAPIWrapper;
using System.Threading;
using LacunaExpanseAPIWrapper.ResponseModels;

namespace LacunaExpress.Data
{
	public class Server
	{
		static int requestCounter = 0;
		static DateTime minute = DateTime.Now;
		const int requestsPerMinuteLimit = 40;
		public async Task<string> GetHttpResultStringAsyncAsString(string gameServer, string url, string json)
		{
			

			if (requestCounter > requestsPerMinuteLimit)
			{
				while (DateTime.Now < minute.AddSeconds(60)) { }
				requestCounter = 0;
				minute = DateTime.Now;
			}

			HttpClient client = new HttpClient();
			url = url.Replace("/", ""); //Some sources for the URL have / at that start
			var requestUrl  = (gameServer + "/"+url);
			try
			{
				var result = await client.PostAsync(requestUrl, new StringContent(
					json,
					Encoding.UTF8,
					"application/json"));
				var x = await result.Content.ReadAsStringAsync();
				return x;
			}
			catch (Exception e) 
			{ 
				var f = e;
				return null;
			}
		}
		public async Task<Response> GetHttpResultAsync(string gameServer, string url, string json)
		{
			var r = await GetHttpResultStringAsyncAsString(gameServer, url, json);
			if(r != null){
				return Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(r);
			}
			else
				return null;
		}

		public async void ThrottledServer(List<ThrottledServerRequest> requests)
		{
			int requestCounter = 0;
			DateTime minute = DateTime.Now;

			foreach (var r in requests)
			{
				if (requestCounter > 50)
				{
					while (DateTime.Now < minute.AddSeconds(60)) { }
					requestCounter = 0;
					minute = DateTime.Now;
				}
				HttpClient client = new HttpClient();
				var requestUrl = (r.GameServer + "/" + r.Url);
				try
				{
					var result = await client.PostAsync(requestUrl, new StringContent(
						r.Json,
						Encoding.UTF8,
						"application/json"));
				}
				catch (Exception e)
				{
				}
				finally
				{
					requestCounter++;
				}
			}
			
		}
		public static async Task<List<Response>> ThrottledServerReturns(List<ThrottledServerRequest> requests)
		{
			//int requestCounter = 0;
			//DateTime minute = DateTime.Now;
			var responseList = new List<Response>();
			foreach (var r in requests)
			{
				if (requestCounter > 50)
				{
					while (DateTime.Now < minute.AddSeconds(60)) { }
					requestCounter = 0;
					minute = DateTime.Now;
				}
				HttpClient client = new HttpClient();
				var requestUrl = (r.GameServer + "/" + r.Url);
				try
				{
					var result = await client.PostAsync(requestUrl, new StringContent(
						r.Json,
						Encoding.UTF8,
						"application/json"));
					var x = await result.Content.ReadAsStringAsync();
					if (r != null)
					{
						var response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(x);
						responseList.Add(response);
					}
				}
				catch (Exception e)
				{
				}
				finally
				{
					requestCounter++;
				}
			}
			return responseList;
		}
	}

}
