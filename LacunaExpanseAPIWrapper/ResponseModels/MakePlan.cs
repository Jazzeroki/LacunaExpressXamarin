using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class MakePlan
	{
		public List<LevelCosts> level_costs;
		public List<Types> types;
		public string subsidy_cost;
		public string making; //what the lab is currently making
	}
}
