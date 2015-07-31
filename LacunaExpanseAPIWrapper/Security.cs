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
	public class Security : Buildings
	{
		public static string URL = "security";

		public static string ViewPrisoners(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_prisoners", sessionID, buildingID, pageNumber);
		}
		public static string ExecutePrisoner(string sessionID, string buildingID, string prisonerID)
		{
			return BasicRequest(1, "execute_prisoner", sessionID, buildingID, prisonerID);
		}
		public static string ReleasePrisoner(string sessionID, string buildingID, string prisonerID)
		{
			return BasicRequest(1, "release_prisoner", sessionID, buildingID, prisonerID);
		}
		public static string ViewForeignSpies(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_foreign_spies", sessionID, buildingID, pageNumber);
		}
	}

}

