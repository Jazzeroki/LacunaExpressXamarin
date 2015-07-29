using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.Scripts
{
	class MapScripts
	{
		public static async Task<List<Stars>> GetAllBodiesInRange30(AccountModel account, int x, int y)
		{
			int x1, x2, y1, y2;
			x1 = x - 15;
			x2 = x + 15;
			y1 = y - 15;
			y2 = y + 15;
			//Map map = new Map();
			var json = Map.GetStars(account.SessionID, Convert.ToString(x1), Convert.ToString(y1), Convert.ToString(x2), Convert.ToString(y2));
			var server = new LacunaExpress.Data.Server();
			var reply = await server.GetHttpResultAsync(account.Server, Map.URL, json);
			if (reply.result != null)
			{
				return reply.result.stars;
			}
			else
				return null;
		}
		//static List<Stars> GetAllBodiesInRange(int centerx, int centery, int range){
		//	//method to support getting stars by a much larger range still in development

		//	int x1, x2, y1, y2;
		//	x1 = centerx-15;
		//	x2 = centerx+15;
		//	y1 = centery-15;
		//	y2 = centery+15;
		//	//Map map = new Map();
		//	String request = map.GetStars(sessionID, Integer.toString(x1), Integer.toString(y1), Integer.toString(x2), Integer.toString(y2));
		//	String reply = server.ServerRequest(gameServer, map.url, request);
		//	Response r = gson.fromJson(reply, Response.class);
		//	return r.result.stars;
		//}
		static bool CheckSystemHostile(List<Bodies> bodies){
    	
    	foreach(var b in bodies)
		{
    		if(b.empire != null){
    			if(b.empire.alignment.Equals("hostile"))
    				return true;
    		}
    	}
    	return false;
    }
	}
}
