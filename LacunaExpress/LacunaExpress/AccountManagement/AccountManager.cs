using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using LacunaExpanseAPIWrapper;
using LacunaExpress.Data;
using Xamarin.Forms;

namespace LacunaExpress.AccountManagement
{
	class AccountManager
	{
		private string AccountFile { get { return "Acnt.Jazz"; } }
		IIsolatedStorage Storage = DependencyService.Get<IIsolatedStorage>();

        public static bool CaptchaStillValid(AccountModel account)
        {
            var captchaValidUntil = DateTime.Now.AddMinutes(-25);
            if (account.CaptchaLastRenewed > captchaValidUntil)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		public async void ModifyAccountAsync(AccountModel modifiedAccount, AccountModel originalAccount)
		{
			var accounts = await LoadAccountsAsync();
			if (accounts != null)
			{
				var index = accounts.AccountList.Find(x => x.DisplayName.Equals(originalAccount.DisplayName));
				accounts.AccountList.Remove(index);

				
				if (modifiedAccount.ActiveAccount)
				{

					var updatedList = MakeAllAccountsNotActive(accounts);
					accounts.AccountList.Clear();
					accounts.AccountList = updatedList.AccountList;
				}
				accounts.AccountList.Add(modifiedAccount);
			}
			
			await Storage.SaveTextAsync(AccountFile, Newtonsoft.Json.JsonConvert.SerializeObject(accounts));
		}

		private static AccountCollection MakeAllAccountsNotActive(AccountCollection accounts)
		{
			var accountCollection = new AccountCollection();
			foreach (var a in accounts.AccountList)
			{
				a.ActiveAccount = false;
				accountCollection.AccountList.Add(a);
			}
			return accountCollection;
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
						//a.ActiveAccount = true;
						if (a.ActiveAccount)
						{
							if (a.SessionRenewed < DateTime.Now.AddHours(-2))
							{
								var oldAccount = a;
								string json = Empire.Login(1, a.EmpireName, a.Password);
								var s = new Server();
								var response = await s.GetHttpResultAsync(a.Server, Empire.url, json);
								s = null;
								a.SessionID = response.result.session_id;
								a.SessionRenewed = DateTime.Now;
								ModifyAccountAsync(a, oldAccount);
							}
							return a;
						}
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

		public async Task<bool> CreateAndAddAccountAsync(string username, string password, string server, bool setAsActive)
		{
			string json = Empire.Login(1, username, password);
			var s = new Server();
			var response = await s.GetHttpResultAsync(server, Empire.url, json);
			if (response.result != null)
			{
				var account = new AccountModel(username, password, server, response.result.session_id, setAsActive);
				account.SessionRenewed = DateTime.Now;
				account.ActiveAccount = setAsActive;
				account.Colonies = response.result.status.empire.colonies;
				account.Stations = response.result.status.empire.stations;
				account.AllBodies = response.result.status.empire.planets;
				account.Capital = response.result.status.empire.colonies[response.result.status.empire.home_planet_id];

				account.Colonies.OrderBy(x => x.Value);
				account.Stations.OrderBy(x => x.Value);
				account.AllBodies.OrderBy(x => x.Value);
				var accounts = await LoadAccountsAsync();
				if (accounts != null)
				{
					var accountCollection = new AccountCollection();
					if (setAsActive)
					{
						accountCollection = MakeAllAccountsNotActive(accounts);
					}
					accountCollection.AccountList.Add(account);
					await Storage.SaveTextAsync(AccountFile, Newtonsoft.Json.JsonConvert.SerializeObject(accountCollection));
					return true;
				}
				else
				{
					var accountCollection = new AccountCollection();
					account.ActiveAccount = true;
					accountCollection.AccountList.Add(account);
					await Storage.SaveTextAsync(AccountFile, Newtonsoft.Json.JsonConvert.SerializeObject(accountCollection));
					return true;
				}

			}
			else
				return false;

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
