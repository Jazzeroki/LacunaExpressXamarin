using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Empire : CoreClass
	{
        private static string US1APIKEY = "6266769d-1f73-4325-a40f-6660c4c6440d";
        private static string PTAPIKEY = "anonymous";
        public static string url = "empire";
		public static string Login(int requestID, string userName, string password)
		{	// a login request doesn't have a session id, but username in this place will serialize just fine
			return BasicRequest(requestID, "login", userName.Trim(), password.Trim(), US1APIKEY);
		}
		public static string Find(string sessionID, string accountNameToFind)
		{
			return BasicRequest(1, "find", sessionID, accountNameToFind);
		}
	}
}


/*
is_name_available ( name )
name
logout ( session_id )
session_id
login ( name, password, api_key )
name
password
api_key
fetch_captcha ( )
create ( params )
params
name
password
password1
captcha_guid
captcha_solution
email
facebook_uid
facebook_token
invite_code
found ( empire_id, api_key, [ invite_code ] )
empire_id
api_key
invite_code
get_invite_friend_url ( session_id )
session_id
invite_friend ( session_id, email, [ custom_message ] )
session_id
email
custom_message
get_status ( session_id )
session_id
view_profile ( session_id )
session_id
edit_profile ( session_id, profile )
session_id
profile
description
email
sitter_password
status_message
city
country
notes
skype
player_name
public_medals
skip_happiness_warnings
skip_resource_warnings
skip_pollution_warnings
skip_medal_messages
skip_facebook_wall_posts
skip_found_nothing
skip_excavator_resources
skip_excavator_glyph
skip_excavator_plan
skip_spy_recovery
skip_probe_detected
skip_attack_messages
skip_incoming_ships
view_public_profile (session_id, empire_id)
session_id
empire_id
send_password_reset_message ( params )
params
empire_id
empire_name
email
reset_password ( reset_key, password1, password2, api_key )
reset_key
password1
password2
api_key
change_password ( session_id, password1, password2 )
session_id
password1
password2
find ( session_id, name )
session_id
name
set_status_message ( session_id, message )
session_id
message
view_boosts ( session_id )
session_id
boost_storage ( session_id )
session_id
boost_food ( session_id )
session_id
boost_water ( session_id )
session_id
boost_energy ( session_id )
session_id
boost_ore ( session_id )
session_id
boost_happiness ( session_id )
session_id
boost_building ( session_id )
session_id
spy_training_boost ( session_id )
session_id
enable_self_destruct ( session_id )
session_id
disable_self_destruct ( session_id )
session_id
redeem_essentia_code ( session_id, code )
session_id
code
update_species ( empire_id, params )
empire_id
params
name
description
min_orbit
max_orbit
manufacturing_affinity
deception_affinity
research_affinity
management_affinity
farming_affinity
mining_affinity
science_affinity
environmental_affinity
political_affinity
trade_affinity
growth_affinity
redefine_species_limits ( session_id )
session_id
redefine_species ( session_id, params )
session_id
params
view_species_stats ( session_id )
get_species_templates ( )
*/