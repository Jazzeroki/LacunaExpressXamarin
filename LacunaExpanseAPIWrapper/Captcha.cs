using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Captcha : CoreClass
	{
		public static string url = "captcha";
		public static string Fetch(string sessionID)
		{
			return BasicRequest(1, "fetch", sessionID);
		}
		public static string Solve(string sessionID, string guid, string solution)
		{
			return BasicRequest(1, "solve", sessionID, guid, solution);
		}
	}

}
