using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanseAPIWrapper
{
	public class Empire : CoreClass
	{
		public static string url = "empire";
		public static string Login(int requestID, string userName, string password)
		{	// a login request doesn't have a session id, but username in this place will serialize just fine
			return BasicRequest(requestID, "login", userName, password, "6266769d-1f73-4325-a40f-6660c4c6440d");
		}
	}
}
