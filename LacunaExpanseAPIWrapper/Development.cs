using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Development : Buildings
	{
	}

	/*
	 * subsidize_build_queue ( session_id, building_id )
session_id (required)
building_id (required)
RESPONSE
subsidize_one_build ( parameter_hash )
session_id (required)
building_id (required)
scheduled_id (required)
RESPONSE
cancel_build ( parameter hash )
session_id (required)
building_id (required)
scheduled_id (required)
RESPONSE
	 * 
	 * {
   "session_id" : 1234-123-123,
   "building_id" : 4566,
   "scheduled_id" : 56767,
 }
	 * */
}
