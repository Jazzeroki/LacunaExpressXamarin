using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Body
	{
		public string surface_image, name, type, zone, x, y, surface_refresh, size, orbit, surface_version, image, num_incoming_own, num_incoming_ally, num_incoming_enemy, star_name, star_id, propaganda_boost, plots_available, id, build_queue_size;
		public Double population, ore_capacity, water_stored, waste_stored, food_stored, ore_stored, ore_hour, energy_capacity, water_hour, happiness, happiness_hour, food_hour, building_count, water_capacity, energy_stored, energy_hour, waste_hour, food_capacity;
		public Ore ore;
		public Station station;
		public IncomingShips[] incoming_enemy_ships, incoming_own_ships;
        public Empire empire;	
	}
}
