using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ParamsModels
{
	public class OptionsLists
	{
        public static List<ParliamentProposalsModel> ParliamentLockDownProposals = new List<ParliamentProposalsModel>
        {
            new ParliamentProposalsModel { RequiredLevel=13, Proposition="Members Only Mining" },
            new ParliamentProposalsModel { RequiredLevel=18, Proposition="Members Only Colonization" },
            new ParliamentProposalsModel { RequiredLevel=23, Proposition="Neutralize BHG" },
            new ParliamentProposalsModel { RequiredLevel=20, Proposition="Members Only Excavators" },
            new ParliamentProposalsModel { RequiredLevel=18, Proposition="Members Only Stations" }
        };
        public static List<ParliamentProposalsModel> ParliamentProposals = new List<ParliamentProposalsModel>
        {
            new ParliamentProposalsModel { RequiredLevel=2, Proposition = "Drop module", Explanation= "Destroys a module on the station or removes a dent from the station." },
            new ParliamentProposalsModel { RequiredLevel=3, Proposition="Rename Station", Explanation="Note: While you need Parliament 3, the actual renaming is done in the SCC, rename tab." },
            new ParliamentProposalsModel { RequiredLevel=4, Proposition="Propose Writ ", Explanation="A law that is text only.The enforcement of it is up to the players." },
            new ParliamentProposalsModel { RequiredLevel=5, Proposition="Repeal Writ", Explanation=" Get rid of the laws from Level 4" },
            new ParliamentProposalsModel { RequiredLevel=6, Proposition="Transfer Station", Explanation="Give the station ownership to another alliance member" },
            new ParliamentProposalsModel { RequiredLevel=8, Proposition="Rename Star", Explanation= " Rename a star you control from Level 7" },
            new ParliamentProposalsModel { RequiredLevel=9, Proposition="Post to N19", Explanation= "Text on N19 Post anything on Network 19" },
            new ParliamentProposalsModel { RequiredLevel=10, Proposition="Induct Member", Explanation= "Induct a new member into the alliance.Once passed, an alliance invitation will be sent." },
            new ParliamentProposalsModel { RequiredLevel=10, Proposition="Expel Member", Explanation= "Expel a member from the alliance. Once passed, the member will be removed from the alliance." },
            new ParliamentProposalsModel { RequiredLevel=11, Proposition="Elect Leader", Explanation= "Elect a new leader of the alliance." },
            new ParliamentProposalsModel { RequiredLevel=12, Proposition="Rename Asteroid", Explanation= "Rename an asteroid that is around a star from Level 7" },
            new ParliamentProposalsModel { RequiredLevel=13, Proposition="Members Only Mining" },
            new ParliamentProposalsModel { RequiredLevel=14, Proposition="Evict mining platform Blow up a mining platform on an asteroid around a star from Level 7" },
            new ParliamentProposalsModel { RequiredLevel=15, Proposition = "Propose Taxation", Explanation= "Imposes a tax on all empires under the jurisdiction of the space station.Note: This option cannot currently be proposed in the webUI.There is a method of seeing who has paid taxes but not a method of paying them." },
            new ParliamentProposalsModel { RequiredLevel=16, Proposition = "Send Foreign Aid", Explanation= "Sends a foreign aid package to a planet in the jurisdiction of the station.The foreign aid is sent via supply pod. Currently non-functional." },
            new ParliamentProposalsModel { RequiredLevel=17, Proposition = "Rename Planet", Explanation= "Rename an uninhabited planet that is around a star from Level 7" },
            new ParliamentProposalsModel { RequiredLevel=18, Proposition="Members Only Colonization", Explanation= "If passed, only members of the alliance would be able to set up new colonies on planets in this station's jurisdiction. New empires will not spawn in systems that this proposition is in effect on. Black Hole Generators cannot be used by non-alliance members to move planets into systems with this proposition in effect. Note: They could swap with a different planet that they would normally be able to swap with.  (One of their colonies, or even a colony that is in a system seized by their alliance.) "},
            new ParliamentProposalsModel { RequiredLevel=18, Proposition="Members Only Stations" },            
            new ParliamentProposalsModel { RequiredLevel=20, Proposition="Members Only Excavators" },
            new ParliamentProposalsModel { RequiredLevel=23, Proposition="Nuetralize BHG", Explanation="All (non-alliance or non-passport holders) Black Hole Generator functions are neutralized within controlled systems.The neutralizing effect is limited to BHGs located within the controlled systems." },            
            new ParliamentProposalsModel { RequiredLevel=25, Proposition="Fire the BFG", Explanation= "Sends The Big Friendly Giant to a planet so he can explain frobscottle and whizzpoppers to the natives. (It is mildly possible that this is instead a reference to Doom and the BFG is a very large deadly gun that will destroy the planet it hits.) BFG sets all the non-resource and non-glyph buildings on a planet to zero efficiency. It also works on Isolationist empires.  The star however must be under control of the station. Firing requires adequite supplies to be on hand at the Space Station. Each firing consumes 100M Ore, 10M Electricity, 10M Water, 1M Food. If there is not enough supplies on hand the parliament will take damage and lose a level. Can't be fired at asteroids." },
            new ParliamentProposalsModel { RequiredLevel=28, Proposition="BHG Passport", Explanation= "This proposition will allow an alliance to grant passage of a different alliance thru the jurisdiction of the station. This would also allow the other alliance to setup stations and colonies, so care must be given to who is granted this right. Note: This law is not enabled yet in the UI, but is available via the API." },
        };






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
