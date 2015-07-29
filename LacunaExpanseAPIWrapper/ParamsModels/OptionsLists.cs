using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ParamsModels
{
	public class OptionsLists
	{
		public static List<string> spyAssignments = new List<string>
		{
			"Idle", "Bugout", "Counter Espionage","Security Sweep","Intel Training",
"Mayhem Training",
"Politics Training",
"Theft Training",
"Political Propaganda",
"Gather Resource Intelligence",
"Gather Empire Intelligence",
"Gather Operative Intelligence",
"Hack Network 19",
"Sabotage Probes",
"Rescue Comrades",
"Sabotage Resources",
"Appropriate Resources",
"Assassinate Operatives",
"Sabotage Infrastructure",
"Sabotage Defenses",
"Sabotage BHG",
"Incite Mutiny",
"Abduct Operatives",
"Appropriate Technology",
"Incite Rebellion",
"Incite Insurrection"

		};

		public static Dictionary<string, string> GLYPHRECIPES = new Dictionary<string, string>
		{
			{"\"halls1\"", "\"goethite\",\"halite\",\"gypsum\",\"trona\""}
		};
	}
}
