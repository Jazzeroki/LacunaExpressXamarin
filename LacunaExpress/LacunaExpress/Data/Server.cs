using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft;
using LacunaExpanseAPIWrapper;
using System.Threading;

namespace LacunaExpress.Data
{
	public class Server
	{
		public async Task<string> GetHttpResultStringAsyncAsString(string gameServer, string url, string json)
		{
			HttpClient client = new HttpClient();
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
	}

}
