using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class SpaceStationLab : Buildings
	{
		public static string URL = "ssla";
		public static string MakePlan(string sessionID, string buildingID, string plan, string level)
		{
			return BasicRequest(1, "make_plan", sessionID, buildingID, plan, level);
		}
		public static string SubsidizePlan(string sessionID, string buildingID)
		{
			return BasicRequest(1, "subsidize_plan", sessionID, buildingID);
		}
	}
}

