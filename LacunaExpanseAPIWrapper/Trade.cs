using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Trade : Buildings
	{
        public static string URL = "trade";
		public static string GetShips(string sessionID, string buildingID) { return BasicRequest (1, "get_ships", sessionID, buildingID);}
		public static string GetPrisoners(string sessionID, string buildingID) { return BasicRequest (1, "get_prisoners", sessionID, buildingID);}
		public static string GetPlans(string sessionID, string buildingID) { return BasicRequest (1, "get_plans", sessionID, buildingID);}
		public static string GetPlanSummary(string sessionID, string buildingID) { return BasicRequest (1, "get_plan_summary", sessionID, buildingID);}
		public static string GetGlyphs(string sessionID, string buildingID) { return BasicRequest (1, "get_glyphs", sessionID, buildingID);}
		public static string GetGlyphSummary(string sessionID, string buildingID) { return BasicRequest (1, "get_glyph_summary", sessionID, buildingID);}
		public static string WithdrawFromMarket(string sessionID, string buildingID) { return BasicRequest (1, "withdraw_from_market", sessionID, buildingID);}

        /*
		 * add_to_market ( session_id, building_id, offer, ask, options )
session_id
building_id
offer
ask
options


withdraw_from_market ( session_id, building_id, trade_id )
session_id
building_id
trade_id
accept_from_market ( session_id, building_id, trade_id )
session_id
building_id
trade_id
view_market ( session_id, building_id, [ page_number, filter ] )
session_id
building_id
page_number
filter
view_my_market ( session_id, building_id, [ page_number ] )
session_id
building_id
page_number
get_trade_ships ( session_id, building_id, [ target_body_id ] )
session_id
building_id
target_body_id
get_waste_ships ( session_id, building_id )
session_id
building_id
get_supply_ships ( session_id, building_id )
session_id
building_id
view_supply_chains ( session_id, building_id )
view_waste_chains ( session_id, building_id )
create_supply_chain (session_id, building_id, target_id, resource_type, resource_hour)
delete_supply_chain (session_id, building_id, supply_chain_id)
update_supply_chain ( session_id, building_id, supply_chain_id, resource_type, resource_hour)
update_waste_chain ( session_id, building_id, waste_chain_id, waste_hour)
add_supply_ship_to_fleet (session_id, building_id, ship_id )
session_id
building_id
ship_id
add_waste_ship_to_fleet (session_id, building_id, ship_id )
session_id
building_id
ship_id
remove_supply_ship_from_fleet (session_id, building_id, ship_id )
session_id
building_id
ship_id
remove_waste_ship_from_fleet (session_id, building_id, ship_id )
session_id
building_id
ship_id
get_stored_resources ( session_id, building_id )
session_id
building_id
push_items ( session_id, building_id, target_id, items, options )
session_id
building_id
target_id
items
options
report_abuse ( session_id, building_id, trade_id )
session_id
building_id
trade_id
		 */
    }
}
