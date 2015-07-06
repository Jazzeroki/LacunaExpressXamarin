using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.AccountManagement
{
	public class AccountCollection
	{
		public AccountCollection(){
			AccountList = new List<AccountModel>();
		}
		public List<AccountModel> AccountList { get; set; }
	}
}
