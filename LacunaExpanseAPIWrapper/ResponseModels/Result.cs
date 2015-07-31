using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper.ResponseModels
{
	public class Result
	{
		public bool isStaff, isModerator;
		public string session_id, url, guid, number_of_ships_building, cost_to_subsidize, spy_count, fleet_send_limit, captured_count, gravatar_url, chat_name, chat_auth;
		public string quantity, item_name;//these have values when combining glyphs
		public string rename_empire_cost;
		public string[] success;
		public DockedShips docked_ships;
		public List<Spies> spies;
		public List<string> possible_assignments;
		public List<ShipsBuilding> ships_building;
		public Status status;
		//public Error error;
		public Body body;
		public Dictionary<string, Building> buildings;
		public List<Messages> messages;
		//Messages messages[];//used when previewing multiple messages
		public Messages message; //used when reading a single message
		public string message_count;
		public List<Stars> stars;
		public List<Orbiting> orbiting;
		public List<Incoming> incoming;
		public List<Unavailable> unavailable; //comment out if this starts causing problems it has before
		public List<Available> available;
		public List<Prisoner> prisoners;
		public List<Excavators> excavators;
		public List<Ship> ships;
		public List<Glyph> glyphs;  //used when checking glyph quantities
		public List<Empires> empires;
		public List<string> sent; //used when sending messages, says who the messages went to.
		public Profile profile;
		public List<Laws> laws;
        
	}
}
