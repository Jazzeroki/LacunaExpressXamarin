using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Profile
	{
		public string leader_id, date_created, name, description, id, influence;
		public List<Members> members;
		public List<SpaceStations> space_stations;
	}
}
