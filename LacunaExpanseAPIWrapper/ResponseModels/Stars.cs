using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Stars
	{
		public string zone, name, x, y, color, id, influence;
		public Station station;
		public List<Bodies> bodies;
	}
}
