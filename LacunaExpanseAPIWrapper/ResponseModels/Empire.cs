using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Empire
	{
		public string rpc_count, has_new_messages;
		public Dictionary<String, String> planets, space_stations, colonies, stations; //stations and colonies are seperated lists of planets and colonies planets is a combined list
		public String self_destruct_active, name, status_message, self_destruct_date, is_isolationist, latest_message_id, home_planet_id;
		public String tech_level, id, essentia, server, alignment, primary_embassy_id, next_station_cost, insurrect_value, alliance_id;
			
	}
}
