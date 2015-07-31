using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Spaceport : Buildings
	{

		/**
		 * Created by Alma on 1/27/2015.
		 */

		public static string URL = "spaceport";

		public static string ViewAllShips(string sessionID, string buildingID)
		{
			return BasicRequest(1, "view_all_ships", sessionID, buildingID);
		}
		public static string ViewAllShips(string sessionID, string buildingID, string shipType)
		{
			return "{\"id\":11,\"method\":\"view_all_ships\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",\"" + buildingID + "\",{\"no_paging\":1},{\"type\":\"" + shipType + "\"},null]}";
		}
		public static string RecallAll(string sessionID, string buildingID)
		{
			return BasicRequest(1, "recall_all", sessionID, buildingID);
		}
		public static string ViewForeignShips(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_foreign_ships", sessionID, buildingID, pageNumber);
		}
		public static string GetFleetFor(string sessionID, string bodyID, string target)
		{
			return BasicRequest(1, "get_fleet_for", sessionID, bodyID, target);
		}
		public static string GetShipsFor(string sessionID, string bodyID, Target target)
		{
            string t = "";
			if (target.bodyID.Length == 0)
			{
				t = "body_id\":\"" + target.bodyID;
			}
			else if (target.bodyName.Length == 0)
			{
				t = "body_name\":\"" + target.bodyName;
			}
			else if (target.starID.Length == 0)
			{
				t = "star_id\":\"" + target.starID;
			}
			else if (target.starName.Length == 0)
			{
				t = "star_name\":\"" + target.starName;
			}
			else
			{
				t = "x\":\"" + target.x + "\",\"y\":\"" + target.y;
			}
            string b = "{\"id\":8,\"method\":\"get_ships_for\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",\"" + bodyID + "\",{\"" + t + "\"}]}";
			return b;
		}

		public static string SendShip(string sessionID, string bodyID, Target target)
		{
            string t = "";
			if (target.bodyID.Length == 0)
			{
				t = "body_id\":\"" + target.bodyID;
			}
			else if (target.bodyName.Length == 0)
			{
				t = "body_name\":\"" + target.bodyName;
			}
			else if (target.starID.Length == 0)
			{
				t = "star_id\":\"" + target.starID;
			}
			else if (target.starName.Length == 0)
			{
				t = "star_name\":\"" + target.starName;
			}
			else
			{
				t = "x\":\"" + target.x + "\",\"y\":\"" + target.y;
			}
            string b = "{\"id\":8,\"method\":\"send_ship\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",\"" + bodyID + "\",{\"" + t + "\"}]}";
			return b;
		}
		public static string RecallShip(string sessionID, string buildingID, string shipID)
		{
			return BasicRequest(1, "recall_ship", sessionID, buildingID, shipID);
		}
		public static string PrepareSendSpies(string sessionID, string onBodyID, string toBodyID)
		{
			return BasicRequest(1, "prepare_send_spies", sessionID, onBodyID, toBodyID);
		}
		public static string PrepareFetchSpies(string sessionID, string onBodyID, string toBodyID)
		{
			return BasicRequest(1, "prepare_fetch_spies", sessionID, onBodyID, toBodyID);
		}
		public static string ViewBattleLogs(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_battle_logs", sessionID, buildingID, pageNumber);
		}
		public static string NameShip(string sessionID, string buildingID, string shipID, string name)
		{
			return BasicRequest(1, "name_ship", sessionID, buildingID, shipID, name);
		}
		public static string ScuttleShip(string sessionID, string buildingID, string shipID, string name)
		{
			return BasicRequest(1, "scuttle_ship", sessionID, buildingID, shipID, name);
		}
		public static string ViewShipsTraveling(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_ships_travelling", sessionID, buildingID, pageNumber);
		}
		public static string ViewShipsOrbiting(string sessionID, string buildingID, string pageNumber)
		{
			return BasicRequest(1, "view_ships_orbiting", sessionID, buildingID, pageNumber);
		}
		public static string SendSpies(string sessionID, string onBodyID, string toBodyID, string shipID, List<string> spyIDs){
            string b = "0";
		//try{
		//	StringWriter w = new StringWriter();
		//	JsonWriter writer = new JsonWriter(w);
		//	writer.beginObject();
		//	writer.name("jsonrpc").value(2);
		//	writer.name("id").value(1);
		//	writer.name("method").value("send_spies");
		//	writer.name("params").beginArray();
		//	writer.value(sessionID);
		//	writer.value(onBodyID);
		//	writer.value(toBodyID);
		//	writer.value(shipID);
		//	writer.beginArray();
		//	for(String j: spyIDs)
		//		writer.value(j);
		//	writer.endArray();
		//	writer.endArray();
		//	writer.endObject();
		//	writer.close();
		//	b = gson.toJson(writer);
		//	b = CleanJsonObject(b);
		//}catch(IOException e){
		//	System.out.println("ioexception");
		//}catch(NullPointerException e){
		//	System.out.println("null pointer exception");
		//}finally{
		//} */
        return b;
    }
		public static string FetchSpies(string sessionID, string onBodyID, string fromBodyID, string shipID, List<string> spyIDs){
            string b = "0";
		//try{
		//	StringWriter w = new StringWriter();
		//	JsonWriter writer = new JsonWriter(w);
		//	writer.beginObject();
		//	writer.name("jsonrpc").value(2);
		//	writer.name("id").value(1);
		//	writer.name("method").value("fetch_spies");
		//	writer.name("params").beginArray();
		//	writer.value(sessionID);
		//	writer.value(onBodyID);
		//	writer.value(fromBodyID);
		//	writer.value(shipID);
		//	writer.beginArray();
		//	for(String j: spyIDs)
		//		writer.value(j);
		//	writer.endArray();
		//	writer.endArray();
		//	writer.endObject();
		//	writer.close();
		//	b = gson.toJson(writer);
		//	b = CleanJsonObject(b);
		//}catch(IOException e){
		//	System.out.println("ioexception");
		//}catch(NullPointerException e){
		//	System.out.println("null pointer exception");
		//}finally{
		//}
        return b;
    }
		//String SendShipTypes(String sessionID, String fromBodyID, Target target, Set<Type> types, Arrival arrival){
		public static string SendShipTypes(string sessionID, string fromBodyID, Target target, Type types, Arrival arrival)
		{
            string t = "";
			if (target.bodyID.Length == 0)
			{
				t = "body_id\":\"" + target.bodyID;
			}
			else if (target.bodyName.Length == 0)
			{
				t = "body_name\":\"" + target.bodyName;
			}
			else if (target.starID.Length == 0)
			{
				t = "star_id\":\"" + target.starID;
			}
			else if (target.starName.Length == 0)
			{
				t = "star_name\":\"" + target.starName;
			}
			else
				t = "x\":\"" + target.x + "\",\"y\":\"" + target.y;
            string a = "{\"day\":\"" + arrival.day + "\",\"hour\":\"" + arrival.hour + "\",\"minute\":\"" + arrival.minute + "\",\"second\":\"" + arrival.second + "\"}";
            string type = "";
			//type += "{\"type\":\"sweeper\",\"quantity\":\"1\"}";
			type += "{\"type\":\"" + types.type + "\",\"speed\":\"" + types.speed + "\",\"stealth\":\"" + types.stealth + "\",\"combat\":\"" + types.combat + "\",\"quantity\":\"" + types.quantity + "\"}";

            string b = "{\"id\":8,\"method\":\"send_ship_types\",\"jsonrpc\":\"2.0\",\"params\":[\"" + sessionID + "\",\"" + fromBodyID + "\",{\"" + t + "\"},[" + type + "]," + a + " ]}";
			return b;
		}
		public static string SendFleet(string sessionID, List<string> ships, Target target){
            string t = ""; //Sets the target
        if(target.bodyID.Length == 0){
            t = "body_id\":\""+target.bodyID;
        }
        else if(target.bodyName.Length == 0){
            t = "body_name\":\""+target.bodyName;
        }
        else if(target.starID.Length == 0){
            t = "star_id\":\""+target.starID;
        }
        else if(target.starName.Length == 0){
            t = "star_name\":\""+target.starName;
        }
        else{
            t = "x\":\""+target.x+"\",\"y\":\""+target.y;
        }

            string s =""; //Creates the ships list to send
        int count = ships.Count();
        int counter = 0;
        foreach(var j in  ships){
            s+=j;
            counter++;
            if(counter == count)
                s+= "\"";
            else
                s+= "\",\"";
        }
            string i = "{\"id\":15,\"method\":\"send_fleet\",\"jsonrpc\":\"2.0\",\"params\":[\""+sessionID+"\",[\""+s+"],{\""+t+"\"},0]}";
        return i;
    }
		public class Target
		{
			Target()
			{
				bodyName = "";
				bodyID = "";
				starName = "";
				starID = "";
				x = "";
				y = "";
			}
			public string bodyName, bodyID, starName, starID, x, y;
		}
		public class Type
		{
			Type()
			{
				type = "";
				speed = "";
				stealth = "";
				combat = "";
				quantity = "";
			}
			public string type, speed, stealth, combat, quantity;
		}
		public class Arrival
		{
			Arrival()
			{
				day = "";
				hour = "";
				minute = "";
				second = "";
			}
			public string day, hour, minute, second;
		}
	}

}

