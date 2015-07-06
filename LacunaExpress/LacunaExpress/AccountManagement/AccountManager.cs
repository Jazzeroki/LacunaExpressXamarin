using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft;

using LacunaExpanseAPIWrapper;
using LacunaExpress.Data;
using LacunaExpress.AccountManagement;
//using LacunaExpress.Data;

using Xamarin.Forms;

namespace LacunaExpress.AccountManagement
{/*
  * Method setup public
  * AddAccount()
  * checks file exists
  * checks if account exists
  * 
  * DeleteAccount()
  * searches accounts removes and saves
  * 
  * GetActiveAccount()
  * loads all accounts and returns the active account
  * 
  * GetAllAccounts()
  * 
  * ModifyAccount(oldAccount, newAccount)
  * 
  * 
  * private 
  * 
  * Load()
  * 
  * Save()
  * 
  * FileExists()
  */
	class AccountManager
	{
		private string AccountFile { get { return "Account.Jazz"; } }
		IIsolatedStorage Storage = DependencyService.Get<IIsolatedStorage>();



		public async void ModifyAccount(AccountModel modifiedAccount, AccountModel originalAccount)
		{
			var accounts = await LoadAccountsAsync();
			if (accounts != null)
			{
				var acc = from a in accounts.AccountList
						  where a.EmpireName == originalAccount.EmpireName && a.Server == originalAccount.Server
						  select a;
				foreach (var a in acc)
					accounts.AccountList.Remove(a);
			}
			accounts.AccountList.Add(modifiedAccount);
			await Storage.SaveTextAsync(AccountFile, Newtonsoft.Json.JsonConvert.SerializeObject(accounts));
		}
		
		public async Task<AccountModel> GetActiveAccountAsync() 
		{
			if (Storage.Exists(AccountFile))
			{
				var accounts = await LoadAccountsAsync();
				if (accounts != null)
				{

					foreach (var a in accounts.AccountList)
					{
						a.ActiveAccount = true;
						if (a.ActiveAccount)
						{
							if (a.SessionRenewed < DateTime.Now.AddHours(-2))
							{
								string json = Empire.Login(1, a.EmpireName, a.Password);
								var s = new Server();
								var response = await s.GetHttpResultAsync(a.Server, Empire.url, json);
								s = null;
								a.SessionID = response.result.session_id;
								a.SessionRenewed = DateTime.Now;
								SaveAccountAsync(a);
							}
							return a;
						}
						else
							return null;  //no accounts are active

					}
				}
				else
					return null;

			}
			
				return null;
		}
		//public void ChangeActiveAccount() { }
		public async void DeleteAccountAsync(AccountModel account) 
		{
			var accounts = await LoadAccountsAsync();
			if (accounts != null)
			{
				accounts.AccountList.Remove(account);
				await Storage.SaveTextAsync(AccountFile, Newtonsoft.Json.JsonConvert.SerializeObject(accounts));
			}
		}
		public async void ClearAccount()
		{
			await Storage.SaveTextAsync(AccountFile, "");
		}
		public async Task<bool> CreateAndAddAccountAsync(string username, string password, string server, bool? setAsActive) 
		{
			string json = Empire.Login(1, username, password);
			var s = new Server();
			var response = await  s.GetHttpResultAsync(server, Empire.url, json);
			if (response != null)
			{
				var account = new AccountModel(username, password, server, response.result.session_id, setAsActive);
				account.SessionRenewed = DateTime.Now;
				account.Colonies = response.result.status.empire.planets;
				account.Stations = response.result.status.empire.stations;
				account.AllBodies = response.result.status.empire.colonies;
				SaveAccountAsync(account);
				return true;
			}
			else
				return false;
			
		}
		private async void SaveAccountAsync(AccountModel account)
		{
			Boolean accountNotFound = true;
			String accountIndex = null;
			if (Storage.Exists(AccountFile))
			{
				var accounts = await LoadAccountsAsync();
				if (accounts != null)
				{
					foreach (var a in accounts.AccountList)
					{
						if (a.EmpireName == account.EmpireName && a.Server == account.Server)
						{
							accountIndex = accounts.AccountList.IndexOf(a).ToString();
							accountNotFound = false;
							break;
						}				
					}
				}
				if (accounts == null || accountNotFound)
				{
					accounts = new AccountCollection();
					accounts.AccountList.Add(account);
				}
				if (accountIndex != null)
				{
					accounts.AccountList[Convert.ToInt32(accountIndex)] = account;
					
				}
				await Storage.SaveTextAsync(AccountFile, Newtonsoft.Json.JsonConvert.SerializeObject(accounts));
			}
		}
		public async Task<AccountCollection> LoadAccountsAsync()
		{
			if (Storage.Exists(AccountFile))
			{
				var file = await Storage.LoadTextAsync(AccountFile);
				if (file.Length > 0)
				{
					var des = Newtonsoft.Json.JsonConvert.DeserializeObject<AccountCollection>(file);
					return des;
				}
				else
					return null;
			}
			else
				return null;
		}
		
	}
}
