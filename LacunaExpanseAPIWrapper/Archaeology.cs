using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Archaeology : Buildings
	{
		public static string URL = "archaeology";
		public static String SubsidizeSearch(String sessionID, String buildingID)
		{
			return BasicRequest(1, "subsidize_search", sessionID, buildingID);
		}
		public static String GetGlyphs(String sessionID, String buildingID)
		{
			return BasicRequest(1, "get_glyphs", sessionID, buildingID);
		}
		public static String GetGlyphSummary(String sessionID, String buildingID)
		{
			return BasicRequest(1, "get_glyph_summary", sessionID, buildingID);

		}
		public static String GetOresAvailableForProcessing(String sessionID, String buildingID)
		{
			return BasicRequest(1, "get_ores_available_for_processing", sessionID, buildingID);
		}
		public static String ViewExcavators(String sessionID, String buildingID)
		{
			return BasicRequest(1, "view_excavators", sessionID, buildingID);
		}
		public static String SearchForGlyph(String sessionID, String buildingID, String oreType)
		{
			return BasicRequest(1, "search_for_glyph", sessionID, buildingID, oreType);
		}
		public static String AbandonExcavator(String sessionID, String buildingID, String siteID)
		{
			return BasicRequest(1, "abandon_excavator", sessionID, buildingID, siteID);
		}

        //params Models has a dictionary listing valid recipes for this call
        public static String AssembleGlyphs(String sessionID, String buildingID, string glyphs, string quantity)
        {
            return "{\"id\":9,\"method\":\"assemble_glyphs\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",\"" + buildingID + "\",[\"" + glyphs + "\"]," + quantity + "]}";
        }

        public static string MassAbandonExcavator(String sessionID, String buildingID)
		{
			return BasicRequest(1, "mass_abandon_excavator", sessionID, buildingID);
		}
	}
}
