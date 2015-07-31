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
	public class Shipyard : Buildings
	{
		public static string URL = "shipyard";

		public static string BuildShip(string sessionID, string buildingID, string type)
		{
			return BasicRequest(1, "build_ship", buildingID, type);
		}
		public static string BuildShip(string sessionID, string buildingID, string type, string numberToBuild)
		{
			return BasicRequest(1, "build_ship", buildingID, type, numberToBuild);
		}
	}
	/*
	view_build_queue ( session_id, building_id, [page_number])

	subsidize_build_queue ( session_id, building_id )

	subsidize_ship ( parameter_hash )
	session_id (required)
	building_id (required)
	ship_id (required)
	RESPONSE
	get_buildable ( session_id, building_id, [ tag ] )

	build_ship ( session_id, building_id, type, [ quantity ] )
	 */
}

