using System;
using System.Collections.Generic;
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
		static void RepairList(int requestID, string sessionID, string bodyID, params string[] buildings) { }
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
