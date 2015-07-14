using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class PoliceStation : Buildings
	{
		public static string URL = "policestation";
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
		public static string ViewForeignShips(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_foreign_ships", sessionID, buildingID, pageNumber);
		}
		public static string ViewShipsTravelling(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_ships_travelling", sessionID, buildingID, pageNumber);
		}
		public static string ViewShipsOrbiting(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_ships_orbiting", sessionID, buildingID, pageNumber);
		}
	}
}
