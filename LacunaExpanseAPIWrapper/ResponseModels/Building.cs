using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Building
	{
		public string x, y, id;
		public string name, url, efficiency, level, image;
		public Work work;
		public PendingBuild pending_build;
	}
}
