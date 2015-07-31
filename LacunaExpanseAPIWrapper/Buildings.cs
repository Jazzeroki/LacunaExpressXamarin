using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	// sent to /warehouse
	//{"id":20,"method":"build","jsonrpc":"2.0","params":["7f4f0e88-596c-4ec1-b35f-97b1492b04f4","444504",-1,3]}

	/**
	 * Created by Alma on 12/23/2014.
	 */
	public class Buildings : CoreClass
	{
		//String for URL will be the same as the building name
		//public string url;
		//Buildings(string buildingName)
		//{
		//	url = buildingName.ToLower();
		//	url = url.Replace(" ", "");
		//	if (url == "archaeologyministry")
		//		url = "archaeology";
		//	if (url.Contains("beach"))
		//		url = "beach";
		//	if (url.Contains("herder"))
		//		url = "beeldeban";
		//	if (url.Contains("bean"))
		//		url = "bean";
		//	if (url.Contains("nest"))
		//		url = "beeldebannest";
		//	if (url.Contains("beach"))
		//		url = "beach";
		//	if (url.Contains("bread"))
		//		url = "bread";
		//	if (url.Contains("burger"))
		//		url = "burger";
		//	if (url.Contains("capitol"))
		//		url = "capitol";
		//	if (url.Contains("cheese"))
		//		url = "cheese";
		//	if (url.Contains("chip"))
		//		url = "chip";
		//	if (url.Contains("cider"))
		//		url = "cider";
		//	if (url.Contains("cornplantation"))
		//		url = "corn";
		//	if (url.Contains("cornmeal"))
		//		url = "meal";
		//	if (url.Contains("dairy"))
		//		url = "dairy";
		//	if (url.Contains("dentonroot"))
		//		url = "denton";
		//	if (url.Contains("development"))
		//		url = "development";
		//	if (url.Contains("espionageministry"))
		//		url = "espionage";
		//	if (url.Contains("fission"))
		//		url = "fission";
		//	if (url.Contains("fusion"))
		//		url = "fusion";
		//	if (url.Contains("geoenergy"))
		//		url = "geo";
		//	if (url.Contains("grove"))
		//		url = "grove";
		//	if (url.Contains("hydrocarbon"))
		//		url = "hydrocarbon";
		//	if (url.Contains("lapisorchard"))
		//		url = "lapis";
		//	if (url.Contains("lostcityoftyleona"))
		//		url = "lcota";
		//	if (url.Contains("lostcityoftyleonb"))
		//		url = "lcotb";
		//	if (url.Contains("lostcityoftyleonc"))
		//		url = "lcotc";
		//	if (url.Contains("lostcityoftyleond"))
		//		url = "lcotd";
		//	if (url.Contains("lostcityoftyleone"))
		//		url = "lcote";
		//	if (url.Contains("lostcityoftyleonf"))
		//		url = "lcotf";
		//	if (url.Contains("lostcityoftyleong"))
		//		url = "lcotg";
		//	if (url.Contains("lostcityoftyleonh"))
		//		url = "lcoth";
		//	if (url.Contains("lostcityoftyleoni"))
		//		url = "lcoti";
		//	if (url.Contains("malcudfungus"))
		//		url = "malcud";
		//	if (url.Contains("oversight"))
		//		url = "oversight";
		//	if (url.Contains("pancake"))
		//		url = "pancake";
		//	if (url.Contains("pie"))
		//		url = "pie";
		//	if (url.Contains("pilottraining"))
		//		url = "pilottraining";
		//	if (url.Contains("planetarycommand"))
		//		url = "planetarycommand";
		//	if (url.Contains("potatoe"))
		//		url = "potatoe";
		//	if (url.Contains("propulsion"))
		//		url = "propulsion";
		//	if (url.Contains("shieldagainst"))
		//		url = "saw";
		//	if (url.Contains("security"))
		//		url = "security";
		//	if (url.Contains("shake"))
		//		url = "shake";
		//	if (url.Contains("shipyard"))
		//		url = "shipyard";
		//	if (url.Contains("singularity"))
		//		url = "singularity";
		//	if (url.Contains("syrup"))
		//		url = "syrup";
		//	if (url.Contains("trade"))
		//		url = "trade";
		//	if (url.Contains("transporter"))
		//		url = "transporter";
		//	if (url.Contains("wasteenergy"))
		//		url = "wasteenergy";
		//	if (url == "entertainmentdistrict")
		//		url = "entertainment";
		//	if (url.Contains("wasterecycling"))
		//		url = "wasterecycling";
		//	if (url.Contains("wastesequestration"))
		//		url = "wastesequestration";
		//	if (url == "intelligenceministry")
		//		url = "intelligence";
		//	if (url == "wastetreatment")
		//		url = "wastetreatment";
		//	if (url == "waterproduction")
		//		url = "waterproduction";
		//	if (url == "waterpurification")
		//		url = "waterpurification";
		//	if (url == "waterreclamation")
		//		url = "waterreclamation";
		//	if (url == "waterstorage")
		//		url = "waterstorage";
		//	if (url == "wheat")
		//		url = "wheat";
		//	if (url == "spacestationlaba")
		//		url = "ssla";
		//	if (url == "spacestationlabb")
		//		url = "sslb";
		//	if (url == "spacestationlabc")
		//		url = "sslc";
		//	if (url == "spacestationlabd")
		//		url = "ssld";

		//}
		public static string Build(string sessionID, string bodyID, string x, string y)
		{
			return BasicRequest(1, "build", sessionID, bodyID, x, y);
		}
		public static string View(string sessionID, string buildingID)
		{
			return BasicRequest(1, "view", sessionID, buildingID);
		}
		public static string Upgrade(string sessionID, string buildingID)
		{
			return BasicRequest(1, "upgrade", sessionID, buildingID);
		}
		public static string Demolish(string sessionID, string buildingID)
		{
			return BasicRequest(1, "demolish", sessionID, buildingID);
		}
		public static string Downgrade(string sessionID, string buildingID)
		{
			return BasicRequest(1, "downgrade", sessionID, buildingID);
		}
		public static string Repair(string sessionID, string buildingID)
		{
			return BasicRequest(1, "repair", sessionID, buildingID);
		}

	}

}

