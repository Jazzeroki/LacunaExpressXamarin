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
		public static string URL = "map";
		public static string CheckStarForIncomingProbe(string sessionID, string starID)
		{
			return BasicRequest(1, "check_star_for_incoming_probe", sessionID, starID);
		}
		public static string GetStar(string sessionID, string starID)
		{
			return BasicRequest(1, "get_star", sessionID, starID);
		}
		public static string GetStarByName(string sessionID, string name)
		{
			return BasicRequest(1, "get_star_by_name", sessionID, name);
		}
		public static string SearchStars(string sessionID, string name)
		{
			return BasicRequest(1, "search_stars", sessionID, name);
		}
		public static string GetStars(string sessionID, string x1, string x2, string y1, string y2)
		{
			return BasicRequest(1, "get_stars", sessionID, x1, x2, y1, y2);
		}
		public static string GetStarsByXY(string sessionID, string x1, string y1)
		{
			return BasicRequest(1, "get_stars_by_xy", sessionID, x1, y1);
		}
	}

}

/*
get_stars ( session_id, x1, y1, x2, y2 )
session_id
x1
y1
x2
y2
check_star_for_incoming_probe ( session_id, star_id )
session_id
star_id
get_star (session_id, star_id)
session_id
star_id
get_star_by_name (session_id, name)
session_id
name
get_star_by_xy (session_id, x, y)
session_id
x
y
search_stars (session_id, name)
session_id
name
probe_summary_fissures
session_id (required)
zone (optional)
RESPONSE
view_laws (session_id, star_id )
session_id
star_id
*/