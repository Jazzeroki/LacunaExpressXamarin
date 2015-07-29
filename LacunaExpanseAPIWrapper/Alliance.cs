using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Alliance : CoreClass
	{
		public static string ViewProfile(string sessionID, string allianceID)
		{
			return BasicRequest(1, "view_profile", sessionID, allianceID);
		}
		public static string Find(string sessionID, string allianceName)
		{
			return BasicRequest(1, "view_profile", sessionID, allianceName);
		}
	}
}
