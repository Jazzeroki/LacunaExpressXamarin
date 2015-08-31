using LacunaExpanseAPIWrapper.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.Scripts
{
    public class StatusCheckers
    {
        public static Boolean PlanetOk(Response r)
        {
            if (Convert.ToDouble(r.result.status.body.num_incoming_enemy) > 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.plots_available) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.water_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.ore_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.energy_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.food_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.happiness_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.happiness_hour) < Convert.ToDouble(r.result.status.body.waste_hour))
                return false;
            if (Convert.ToDouble(r.result.status.body.waste_stored) == 0)
                return false;
            foreach (var p in r.result.buildings)
            {
                if (Convert.ToDouble(p.Value.efficiency) < 100)
                    return false;
                if (p.Value.name.Contains("leeder"))
                    return false;
                if (p.Value.name.Contains("issure"))
                    return false;
            }
            return true;
        }
        public static Boolean StationOk(Response r)
        {
            if (Convert.ToDouble(r.result.status.body.num_incoming_enemy) > 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.plots_available) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.water_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.ore_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.energy_hour) < 0)
                return false;
            if (Convert.ToDouble(r.result.status.body.food_hour) < 0)
                return false;
            foreach (var p in r.result.buildings)
            {
                if (Convert.ToDouble(p.Value.efficiency) < 100)
                    return false;
                if (p.Value.name.Contains("leeder"))
                    return false;
                if (p.Value.name.Contains("issure"))
                    return false;
            }
            return true;
        }
    }
}
