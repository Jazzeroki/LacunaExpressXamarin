using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.StarMapJson
{
	public class Alliances
	{
		public string alliance_id { get; set; }
		public string label { get; set; }
		public List<string> info { get; set; }
		// example of List
		//"Zordane (Plan Z) -- Cap : (1447,633) [5|2]",
		//"Zordane (Plan Z) -- SS : (1451,640) [5|2]",
		//"Zordane (Plan Z) -- SS : (625,371) [2|1]"
		//public Data data { get; set; }
		//example of data
		//"1447","633"
		//suggested deserialize ilist<ilist<string>> data
	}
}
