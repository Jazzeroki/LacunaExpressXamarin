using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Parliament : Buildings
	{
		public static string URL = "parliament";
		public static string ViewLaws(string sessionID, string bodyID) //can this be used to view laws for non-allied SS?
		{
			return BasicRequest(1, "view_laws", sessionID, bodyID);
		}
		public static string ViewPropositions(string sessionID, string bodyID)
		{
			return BasicRequest(1, "view_propositions", sessionID, bodyID);
		}
		public static string ViewTaxesCollected(string sessionID, string bodyID)
		{
			return BasicRequest(1, "view_taxes_collected", sessionID, bodyID);
		}
		public static string GetStarsInJurisdiction(string sessionID, string bodyID)
		{
			return BasicRequest(1, "get_stars_in_jurisdiction", sessionID, bodyID);
		}
		public static string GetBodiesForStarInJurisdiction(string sessionID, string buildingID, string starID)
		{
			return BasicRequest(1, "get_bodies_for_star_in_jurisdiction", sessionID, buildingID, starID);
		}
		public static string GetMiningPlatformsForAsteroidInJurisdiction(string sessionID, string buildingID, string asteroidID)
		{
			return BasicRequest(1, "get_mining_platforms_for_asteroid_in_jurisdiction", sessionID, buildingID, asteroidID);
		}
		public static string CastVote(string sessionID, string buildingID, string propositionID, string vote) //vote 0 for no 1 for yes, cannot be used with sitter pass
		{
			return BasicRequest(1, "cast_vote", sessionID, buildingID, propositionID, vote);
		}
		public static string ProposeWrit(string sessionID, string buildingID, string title, string description)
		{
			return BasicRequest(1, "propose_writ", sessionID, buildingID, title, description);
		}
		public static string ProposeRepealLaw(string sessionID, string buildingID, string lawID)
		{
			return BasicRequest(1, "propose_repeal_law", sessionID, buildingID, lawID);
		}
		public static string ProposeTransferStationOwnership(string sessionID, string buildingID, string toEmpireID)
		{
			return BasicRequest(1, "propose_transfer_station_ownership", sessionID, buildingID, toEmpireID);
		}
		//public static string ProposeSeizeStar(string sessionID, string buildingID, string starID)
		//{
		//	return BasicRequest(1, "propose_seize_star", sessionID, buildingID, starID);
		//}
		public static string ProposeRenameStar(string sessionID, string buildingID, string starID)
		{
			return BasicRequest(1, "propose_rename_star", sessionID, buildingID, starID);
		}
		public static string ProposeBroadcastOnNetwork19(string sessionID, string buildingID, string message)
		{
			return BasicRequest(1, "propose_broadcast_on_network19", sessionID, buildingID, message);
		}
		public static string ProposeInductMember(string sessionID, string buildingID, string empireID)
		{
			return BasicRequest(1, "propose_induct_member", sessionID, buildingID, empireID);
		}
		public static string ProposeInductMember(string sessionID, string buildingID, string empireID, string message)//test message since in api docs it's enclosed in []
		{
			return BasicRequest(1, "propose_induct_member", sessionID, buildingID, empireID, message);
		}
		public static string ProposeExpelMember(string sessionID, string buildingID, string empireID) //message is in [] in api docs need to verify this implementation will work
		{
			return BasicRequest(1, "propose_expel_member", sessionID, buildingID, empireID);
		}
		public static string ProposeExpelMember(string sessionID, string buildingID, string empireID, string message) //message is in [] in api docs need to verify this implementation will work
		{
			return BasicRequest(1, "propose_expel_member", sessionID, buildingID, empireID, message);
		}
		public static string ProposeElectNewLeader(string sessionID, string buildingID, string toEmpireID)
		{
			return BasicRequest(1, "propose_elect_new_leader", sessionID, buildingID, toEmpireID);
		}
		public static string ProposeRenameAsteroid(string sessionID, string buildingID, string asteroidID, string newName)
		{
			return BasicRequest(1, "propose_rename_asteroid", sessionID, buildingID, asteroidID, newName);
		}
		public static string ProposeRenameUninhabited(string sessionID, string buildingID, string planetID, string newName)
		{
			return BasicRequest(1, "propose_rename_uninhabited", sessionID, buildingID, planetID, newName);
		}
		public static string ProposeMemberOnlyMiningRights(string sessionID, string buildingID)
		{
			return BasicRequest(1, "propose_member_only_mining_rights", sessionID, buildingID);
		}
		public static string ProposeEvictMiningPlatform(string sessionID, string buildingID, string platformID)
		{
			return BasicRequest(1, "propose_evict_mining_platform", sessionID, buildingID);
		}
		public static string ProposeTaxation(string sessionID, string buildingID, string taxes)//verify taxes format
		{
			return BasicRequest(1, "propose_taxation", sessionID, buildingID);			
		}
		public static string ProposeForeignAid(string sessionID, string buildingID, string planetID, string resources) //need to check on resources format
		{
			return BasicRequest(1, "propose_foreign_aid", sessionID, buildingID);
		}
		public static string ProposeMembersOnlyColonization(string sessionID, string buildingID)
		{
			return BasicRequest(1, "propose_members_only_colonization", sessionID, buildingID);
		}
		public static string ProposeNeutralizeBHG(string sessionID, string buildingID)
		{
			return BasicRequest(1, "propose_neutralize_bhg", sessionID, buildingID);
		}
		public static string ProposeFireBFG(string sessionID, string buildingID, string bodyID, string reason)
		{
			return BasicRequest(1, "propose_fire_bfg", sessionID, buildingID, bodyID, reason);
		}
	}
}
