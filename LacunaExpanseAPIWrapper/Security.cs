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
		public static String URL = "security";

		public static String ViewPrisoners(String sessionID, String buildingID, String pageNumber)
		{
			return BasicRequest(1, "view_prisoners", sessionID, buildingID, pageNumber);
		}
		public static String ExecutePrisoner(String sessionID, String buildingID, String prisonerID)
		{
			return BasicRequest(1, "execute_prisoner", sessionID, buildingID, prisonerID);
		}
		public static String ReleasePrisoner(String sessionID, String buildingID, String prisonerID)
		{
			return BasicRequest(1, "release_prisoner", sessionID, buildingID, prisonerID);
		}
		public static String ViewForeignSpies(String sessionID, String buildingID, String pageNumber)
		{
			return BasicRequest(1, "view_foreign_spies", sessionID, buildingID, pageNumber);
		}
	}

}

