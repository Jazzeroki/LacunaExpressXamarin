using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{


	/**
	 * Created by Alma on 1/27/2015.
	 */
	public class Map : CoreClass
	{
		public static String URL = "map";
		public static String CheckStarForIncomingProbe(String sessionID, String starID)
		{
			return BasicRequest(1, "check_star_for_incoming_probe", sessionID, starID);
		}
		public static String GetStar(String sessionID, String starID)
		{
			return BasicRequest(1, "get_star", sessionID, starID);
		}
		public static String GetStarByName(String sessionID, String name)
		{
			return BasicRequest(1, "get_star_by_name", sessionID, name);
		}
		public static String SearchStars(String sessionID, String name)
		{
			return BasicRequest(1, "search_stars", sessionID, name);
		}
		public static String GetStars(String sessionID, String x1, String x2, String y1, String y2)
		{
			return BasicRequest(1, "get_stars", sessionID, x1, x2, y1, y2);
		}
		public static String GetStarsByXY(String sessionID, String x1, String y1)
		{
			return BasicRequest(1, "get_stars_by_xy", sessionID, x1, y1);
		}
	}

}

