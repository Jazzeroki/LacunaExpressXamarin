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
                return sb.ToString();
				//return sb.ToString().Replace("\n","");
			}
		}
		protected static string CleanForJSON(string s)
		{
            string reworked = s.Replace("\"", "\\\"");
            reworked = reworked.Replace("\n", "\\n");
            //reworked = reworked.Replace(@"\n", @"\\n");
            //reworked = reworked.Replace(@"\b", @"\\b");
            //reworked = reworked.Replace(@"\f", @"\\f");
            //reworked = reworked.Replace(@"\r", @"\\r");
            //reworked = reworked.Replace(@"\t", @"\\t");
            //reworked = reworked.Replace("{", @"\{");
            //reworked = reworked.Replace("}", @"\}");
            
            //reworked = reworked.Replace(",", @"\,");
            reworked = reworked.Replace("<", "");
            reworked = reworked.Replace(">", "");
            reworked = reworked.Trim();
            return reworked;
            //if (s == null || s.Length == 0)
            //{
            //	return "";
            //}

            //char c = '\0';
            //int i;
            //int len = s.Length;
            //StringBuilder sb = new StringBuilder(len + 4);
            //         string t;

            //for (i = 0; i < len; i += 1)
            //{
            //	c = s[i];
            //	switch (c)
            //	{
            //		case '\\':
            //		case '"':
            //			sb.Append('\\');
            //			sb.Append(c);
            //			break;
            //		case '/':
            //			sb.Append('\\');
            //			sb.Append(c);
            //			break;
            //		case '\b':
            //			sb.Append("\\b");
            //			break;
            //		case '\t':
            //			sb.Append("\\t");
            //			break;
            //		case '\n':
            //			sb.Append("\\n");
            //			break;
            //		case '\f':
            //			sb.Append("\\f");
            //			break;
            //		case '\r':
            //			sb.Append("\\r");
            //			break;
            //		default:
            //			if (c < ' ')
            //			{
            //				t = "000" + string.Format("X", c);
            //				sb.Append("\\u" + t.Substring(t.Length - 4));
            //			}
            //			else
            //			{
            //				sb.Append(c);
            //			}
            //			break;
            //	}
            //}
            //return sb.ToString();
        }
	}
}
