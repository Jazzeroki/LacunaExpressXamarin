using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace LacunaExpanseAPIWrapper
{
	public class CoreClass
	{
		//JsonWriter writer = new JsonTextWriter();
		protected static string BasicRequest(int requestID, string method, string sessionID, params string[] parameters)
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
				writer.WriteValue(method);
				writer.WritePropertyName("params");
				writer.WriteStartArray();
				writer.WriteValue(sessionID);
				foreach (var p in parameters)
					writer.WriteValue(p);
				writer.WriteEndArray();
				writer.WriteEndObject();
				//writer.WriteComment("(broken)");
				//writer.WriteValue("500 gigabyte hard drive");
				//writer.WriteValue("200 gigabype hard drive");
				//writer.WriteEnd();
				//writer.WriteEndObject();

				return sb.ToString().Replace("\n","");

				/*
				 * protected static String Request(String method, String sessionID, String id){
		String b = "0";
		try{
			StringWriter w = new StringWriter();
			JsonWriter writer = new JsonWriter(w);
			writer.beginObject();
			writer.name("jsonrpc").value(2);
			writer.name("id").value(1);
			writer.name("method").value(method);
			writer.name("params").beginArray();
			writer.value(sessionID);
			writer.value(id);
			writer.endArray();
			writer.endObject();
			writer.flush();
			writer.close();
			b = gson.toJson(writer);
			//writer.flush();
			b = CleanJsonObject(b);
		}catch(IOException e){
			System.out.println("ioexception");
		}catch(NullPointerException e){
			System.out.println("null pointer exception");
		}finally{
		}
		return b;
	}
				 * 
				 * 
				 */
			}
		}
	}
}
