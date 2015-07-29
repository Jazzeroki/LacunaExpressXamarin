using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Embassy : Buildings
	{
		public static string URL = "embassy";
		/*
		 * create_alliance ( session_id, building_id, name )
session_id
building_id
name
dissolve_alliance ( session_id, building_id )
session_id
building_id
get_alliance_status ( session_id, building_id )
session_id
building_id
send_invite ( session_id, building_id, invitee_id, [ message ] )
session_id
building_id
invitee_id
message
withdraw_invite ( session_id, building_id, invite_id, [ message ] )
session_id
building_id
invite_id
message
accept_invite ( session_id, building_id, invite_id, [ message ] )
session_id
building_id
invite_id
message
reject_invite ( session_id, building_id, invite_id, [ message ] )
session_id
building_id
invite_id
message
get_pending_invites ( session_id, building_id )
session_id
building_id
get_my_invites ( session_id, building_id )
session_id
building_id
assign_alliance_leader ( session_id, building_id, new_leader_id )
session_id
building_id
new_leader_id
update_alliance ( session_id, building_id, params )
session_id
building_id
params
leave_alliance ( session_id, building_id, [ message ] )
session_id
building_id
message
expel_member ( session_id, building_id, empire_id, [ message ] )
session_id
building_id
empire_id
message
view_stash ( session_id, building_id )
session_id
building_id
donate_to_stash ( session_id, building_id, donation )
session_id
building_id
donation
exchange_with_stash ( session_id, building_id, donation, request )
session_id
building_id
donation
request
		 */
	}
}
