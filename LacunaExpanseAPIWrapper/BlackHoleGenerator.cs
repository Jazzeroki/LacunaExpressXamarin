using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	class BlackHoleGenerator : Buildings
	{
        public static string URL = "blackholegenerator";
        public static string SubsidizeCooldown(string sessionID, string buildingID)
		{
			return BasicRequest (1, "subsidize_cooldown", sessionID, buildingID);
		}

        //public void GenerateSingularity(string buildingID, string target, BHGTask task, params string[] param)
        //{
        //	int id = 800;
        //	string method = "generate_singularity";
        //	JsonTextWriter r = Request(id, method, buildingID.ToString());
        //	AddHashedParameters(r, "body_name", target);
        //	r.WriteString(task.ToString().Replace("_", " "));
        //	if (param.Length == 1)
        //		AddHashedParameters(r, "new_type", param[0]);
        //	Post(BHGURL, r);
        //}

        /*
        generate_singularity
fixed argument list (original calling method)
named arguments
session_id
building_id
target
body_name
body_id
x | y
star_name
star_id
zone
task_name
params
get_actions_for ( session_id, building_id, target )

        */
    }
}
