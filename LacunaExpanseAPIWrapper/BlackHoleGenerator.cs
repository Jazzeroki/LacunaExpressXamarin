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
	}
}
