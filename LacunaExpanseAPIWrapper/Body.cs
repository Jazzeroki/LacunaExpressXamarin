using LacunaExpanseAPIWrapper.ParamsModels;
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
		public enum GetBuildableLocationsOptions
		{
			Four, Nine
		}
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
        public static string RearrangeBuildings(int requestID, string sessionID, string bodyID, List<BuildingArrangement> buildings)
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
                writer.WriteValue("rearrange_buildings");
                writer.WritePropertyName("params");
                writer.WriteStartArray();
                writer.WriteValue(sessionID);
                writer.WriteValue(bodyID);
                writer.WriteStartArray();
                foreach (var p in buildings)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("id");
                    writer.WriteValue(p.BuildingID);
                    writer.WritePropertyName("x");
                    writer.WriteValue(p.X);
                    writer.WritePropertyName("y");
                    writer.WriteValue(p.Y);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndArray();
                writer.WriteEndObject();

                var x = sb.ToString().Replace("\n", "");
                return x;
            }
        }
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
		public static string GetBuildableLocations(int requestID, string sessionID)
		{
			return BasicRequest(requestID, "get_buildable_locations", sessionID);
		}
		public static string GetBuildableLocations(int requestID, string sessionID, GetBuildableLocationsOptions options)
		{
			if(options == GetBuildableLocationsOptions.Four)
				return BasicRequest(requestID, "get_buildable_locations", sessionID, "4");
			else
				return BasicRequest(requestID, "get_buildable_locations", sessionID, "9");
		}
		public static string ViewLaws(int requestID, string sessionID, string claimingStationID)
		{
			return BasicRequest(requestID, "view_laws", sessionID, claimingStationID);
		}

		/*


set_colony_notes
session_id
body_id
options
	*/
	}
}
