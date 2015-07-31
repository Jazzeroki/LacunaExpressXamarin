using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{



	/**
	 * Created by Alma on 1/27/2015.
	 */
	public class Intelligence : Buildings
	{
		public static string URL = "intelligence";

		public static string SubsidizeTraining(string sessionID, string buildingID)
		{
			return BasicRequest(1, "subsidize_training", sessionID, buildingID);
		}
		public static string ViewAllSpies(string sessionID, string buildingID)
		{
			return BasicRequest(1, "view_all_spies", sessionID, buildingID);
		}
		public static string AssignSpy(string sessionID, string buildingID, string spyID, string assignment)
		{
			return BasicRequest(1, "assign_spy", sessionID, buildingID, spyID, assignment);
		}
		public static string NameSpy(string sessionID, string buildingID, string spyID, string name)
		{
			return BasicRequest(1, "name_spy", sessionID, buildingID, spyID, name);
		}
		public static string BurnSpy(string sessionID, string buildingID, string spyID)
		{
			return BasicRequest(1, "burn_spy", sessionID, buildingID, spyID);
		}
		public static string TrainSpy(string sessionID, string buildingID, string quantity)
		{
			return BasicRequest(1, "train_spy", sessionID, buildingID, quantity);

		}

		public enum Assignments
		{
			//Idle, Bugout, "Counter Espionage", Security_Sweep, Intel Training, Mayhem Training, Politics Training, Theft Training, Political Propaganda,

		};

		/*
		A string containing the new assignment name. These are the possible assignments:

		Idle
		Don't do anything.

		Bugout
		Only visible on non-home planets. Immediately has agent go to their home base via spypod.

		Counter Espionage.
		Passively defend against all attackers.

		Security Sweep
		Round up attackers.

		Intel Training
		Train in Intelligence skill

		Mayhem Training
		Train in Mayhem skill

		Politics Training
		Train in Politics skill

		Theft Training
		Train in Theft skill

		Political Propaganda
		Give happiness generation a boost. Especially effective on unhappy colonies, but hastens an agent toward retirement. Only usuable on owned planets.

		Gather Resource Intelligence
		Find out what's up for trade, what ships are available, what ships are being built, where ships are travelling to, etc.

		Gather Empire Intelligence
		Find out what is built on this planet, the resources of the planet, what other colonies this Empire has, etc.

		Gather Operative Intelligence
		Find out what spies are on this planet, where they are from, what they are doing, etc.

		Hack Network 19
		Attempts to besmirch the good name of the empire controlling this planet, and deprive them of a small amount of happiness.

		Sabotage Probes
		Destroy probes controlled by this empire.

		Rescue Comrades
		Break spies out of prison.

		Sabotage Resources
		Destroy ships being built, docked, en route to mining platforms, etc.

		Appropriate Resources
		Steal empty ships, ships full of resources, ships full of trade goods, etc.

		Assassinate Operatives
		Kill spies.

		Sabotage Infrastructure
		Destroy buildings.

		Sabotage Defenses
		Destroy buildings that are used in defense.

		Sabotage BHG
		Prevent enemy planet from using Black Hole Generator.

		Incite Mutiny
		Turn spies. If successful they come work for you.

		Abduct Operatives
		Kidnap a spy and bring him back home.

		Appropriate Technology
		Steal plans for buildings that this empire has built, or has in inventory.

		Incite Rebellion
		Obliterate the happiness of a planet. If done long enough, it can shut down a planet.

		Incite Insurrection
		Steal a planet.

		NOTE: You can do bad things to allies using these assignments.


			 */
	}

}

