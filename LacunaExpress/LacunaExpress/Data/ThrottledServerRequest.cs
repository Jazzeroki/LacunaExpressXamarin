using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.Data
{
	public class ThrottledServerRequest
	{
		public ThrottledServerRequest(string gameserver, string url, string json)
		{
			GameServer = gameserver;
			Url = url;
			Json = json;
		}
		public string GameServer { get; set; }
		public string Url { get; set; }
		public string Json { get; set; }
	}
}
