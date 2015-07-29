using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Propositions
	{
		public string stations, status, name, description, votes_no, votes_yes, id, date_ends, votes_needed;
		public ProposedBy proposed_by;
	}
}
