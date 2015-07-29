using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Capital : Buildings
	{
		public static string URL = "capital";

		public static string RenameEmpire(string sessionID, string buildingID, string newName)
		{
			return BasicRequest(1, sessionID, buildingID, newName);
		}
	}
}
