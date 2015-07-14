using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	class Archaeology : Buildings
	{
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
		public static String AssembleGlyphs(String sessionID, String buildingID, int quantity, params String[] glyphs)
		{
			return null;
		}

		public static String AssembleGlyphs(String sessionID, String buildingID, params String[] glyphs)
		{
			return null;
			/*
			 * mass_abandon_excavator ( session_id, building_id )
	session_id
	building_id
			String b = "0";
			try{
				writer.beginObject();
				writer.name("jsonrpc").value(2);
				writer.name("id").value(1);
				writer.name("method").value("assemble_glyphs");
				writer.name("params").beginArray();
				writer.value(sessionID);
				writer.value(buildingID);
				for(String i: glyphs)
					writer.value(i);
				writer.value(quantity);
				writer.endArray();
				writer.endObject();
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
			*/
		}
		public static string MassAbandonExcavator(String sessionID, String buildingID)
		{
			return BasicRequest(1, "mass_abandon_excavator", sessionID, buildingID);
		}
	}
}
