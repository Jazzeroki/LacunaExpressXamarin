using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Body : CoreClass
	{
		public static string url = "body";
		public static string GetBuildings(int requestID, string sessionID, string bodyID)
		{
			return BasicRequest(requestID, "get_buildings", sessionID, bodyID);
		}

		//The below methods are not yet implemented
		public static string RepairList(int requestID, string sessionID, string bodyID, List<string> buildings) 
		{
			StringBuilder sb = new StringBuilder();
			StringWriter sw = new StringWriter(sb);
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				writer.Formatting = Formatting.Indented;

				writer.WriteStartObject();
				writer.WritePropertyName("jsonrpc");
				writer.WriteValue("2.0");
				writer.WritePropertyName("id");
				writer.WriteValue(requestID);
				writer.WritePropertyName("method");
				writer.WriteValue("repair_list");
				writer.WritePropertyName("params");
				writer.WriteStartArray();
				writer.WriteValue(sessionID);
				writer.WriteValue(bodyID);
				writer.WriteStartArray();
				foreach (var p in buildings)
					writer.WriteValue(p);
				writer.WriteEndArray();				
				writer.WriteEndArray();
				writer.WriteEndObject();
				
				var x = sb.ToString().Replace("\n", "");
				return x;
			}

		}
		static void RearrangeBuildings(int requestID, string sessionID, string bodyID, params ArrangementForRearrangBuildings[] buildings) { }
		public static string GetBuildable(int requestID, string sessionID, string bodyID, string x, string y)
		{
			return BasicRequest(requestID, "get_buildable", sessionID, bodyID, x, y);
		}
		public static string Rename(int requestID, string sessionID, string bodyID, string name)
		{
			return BasicRequest(requestID, "rename", sessionID, bodyID, name);
		}
		public static string Abandon(int requestID, string sessionID, string bodyID)
		{
			return BasicRequest(requestID, "abandon", sessionID, bodyID);
		}
		public class ArrangementForRearrangBuildings
		{
			String id, x, y;
		}
	}
}
