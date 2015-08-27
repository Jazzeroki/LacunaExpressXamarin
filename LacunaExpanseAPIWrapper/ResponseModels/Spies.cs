using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Spies
	{
		public string started_assignment, defense_rating, id, available_on, intel, offense_rating, politics, assignment, name, level, is_available, mayhem, seconds_remaining, theft, task, next_mission;
		public List<PossibleAssignments> possible_assignments;
		public AssignedTo assigned_to;
		public AssignedTo based_from;
        public MissionCount mission_count;
	}
}
