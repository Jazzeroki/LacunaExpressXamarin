using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	

		public class Response
		{
			public int id;
			public String jsonrpc;
			public Result result;


			//Inner Class Definitions
			public class Result
			{
				public bool isStaff, isModerator;
				public String session_id, url, guid, number_of_ships_building, cost_to_subsidize, spy_count, fleet_send_limit, captured_count, gravatar_url, chat_name, chat_auth;
				public String[] success;
				public DockedShips docked_ships;
				public List<Spies> spies;
				public List<String> possible_assignments;
				public List<ShipsBuilding> ships_building;
				public Status status;
				public Error error;
				public Body body;
				public Dictionary<String, Building> buildings;
				public List<Messages> messages;
				//Messages messages[];//used when previewing multiple messages
				public Messages message; //used when reading a single message
				public String message_count;
				public List<Stars> stars;
				public List<Orbiting> orbiting;
				public List<Incoming> incoming;
				public List<Unavailable> unavailable; //comment out if this starts causing problems it has before
				public List<Available> available;
				public List<Prisoner> prisoners;
				public List<Excavators> excavators;
				public List<Ship> ships;
				public List<Glyph> glyphs;
				public List<Empires> empires;
				public List<string> sent; //used when sending messages, says who the messages went to.
			}
			public class Empires  //used with the find request from Empire
			{
				public string name, id;
			}
			public class Glyph
			{
				public String quantity, name, type, id;
			}
			public class Excavators
			{
				public String resource, artifact, date_landed, plan, id, glyph;
				public Body body;
			}
			public class Prisoner
			{
				public String level, name, task, id, sentence_expires;
			}
			public class Incoming
			{

			}
			public class Orbiting
			{

			}
			public class Unavailable
			{
				public Dictionary<String, String> reason;
				public Ship ship;
			}
			public class Ship
			{
				public String can_recall, fleet_speed, name, date_available, task, max_occupants, 
					combat, stealth, can_scuttle, speed, berth_level, hold_size, id, type, type_human, 
					date_started, number_of_docks, task, image, can_scuttle;
				//payload[]  Don't know how this would look like yet
			}
			public class Available
			{
				public String estimated_travel_time, can_recall, fleet_speed, name, date_available, task, max_occupants, combat, stealth, can_scuttle, speed, berth_level, hold_size, id, type, type_human, date_started;
				//payload[]  Don't know how this would look like yet
			}
			public class Stars
			{
				//Empire empire; //
				public String zone, name, x, y, color, id;
				public Station station;
				public List<Bodies> bodies;
			}
			public class Bodies
			{
				public Empire empire;
				public Station station;
				public Ore ore;
				public String star_id, zone, name, x, y, size, image, orbit, id, type, star_name;
			}
			public class DockedShips
			{
				public String excavator, observatory_seeker, spaceport_seeker, snark3, snark2, snark, short_range_colony_ship, sweeper, fighter, scow, scow_mega, probe, hulk, hulk_fast;
			}
			public class Spies
			{
				public String started_assignment, defense_rating, id, available_on, intel, offense_rating, politics, assignment, name, level, is_available, mayhem, seconds_remaining, theft, task, next_mission;
				public List<PossibleAssignments> possible_assignments;
				public AssignedTo assigned_to;
				public AssignedTo based_from;
				public class AssignedTo
				{ //can also be used for based from
					public String y, x, body_id, name;
				}
				public class PossibleAssignments
				{
					public String skill, recovery, task;
				}
			}
			public class Work
			{
				public String start, end, seconds_remaining;
			}
			public class ShipsBuilding
			{
				public String date_completed, id, type, type_human; //type is the server recognized name, type human is for human readibility
			}
			public class Ore
			{
				public double flourite, zircon, anthracite, gypsum, chromite, sulfur, chalcopyrite, gold, trona, methane, magnetite, halite, rutile, goethite, bauxite, kerogen, uraninite, beryl, galena, monazite;
			}
			public class Building
			{
				public int x, y;
				public String name, url, efficiency, level, image;
				public Work work;
			}
			public class Station
			{
				public String x, y, name, id;
			}
			public class IncomingShips
			{
				public String id, date_arrives;
				public int is_ally, is_own;
			}
			public class Body
			{

				public String surface_image, name, type, zone, x, y, surface_refresh, size, orbit, surface_version, image, num_incoming_own, num_incoming_ally, num_incoming_enemy, star_name, propaganda_boost, plots_available;
				public Double population, ore_capacity, water_stored, waste_stored, food_stored, ore_stored, ore_hour, energy_capacity, water_hour, happiness, happiness_hour, food_hour, building_count, water_capacity, energy_stored, energy_hour, waste_hour, food_capacity;
				public Ore ore;
				public Station station;
				public IncomingShips[] incoming_enemy_ships, incoming_own_ships;
			}
			public class Status
			{
				public Empire empire;
				public Body body;
				public Server server;
			}
			public class Empire
			{
				public int rpc_count, has_new_messages;
				public Dictionary<String, String> planets, space_stations, colonies, stations; //stations and colonies are seperated lists of planets and colonies planets is a combined list
				public String self_destruct_active, name, status_message, self_destruct_date, is_isolationist, latest_message_id, home_planet_id;
				public String tech_level, id, essentia, server, alignment, primary_embassy_id, next_station_cost, insurrect_value, alliance_id;
			}
			public class Server
			{
				public String rpc_limit, version, time;
			}

			public class Error
			{
				public int code;
				public Data data;
			}
			public class Data
			{
				public String guid, url;
			}
			public class Messages
			{
				public String from, to, subject, date, in_reply_to, body_preview, body, has_read, has_replied, has_archived, has_trashed, id, from_id, to_id;
				public String[] tags, recipients;
				//public int has_read, has_replied, has_archived, has_trashed, id, from_id, to_id;
			}

		}
	}

