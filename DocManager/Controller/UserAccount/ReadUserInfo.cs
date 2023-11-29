using System.Text.Json;

namespace DocManager.Controller.UserAccount
{
	/// <summary>
	/// Class for reading user account information from a Json file
	/// </summary>
	public class ReadUserInfo
	{
		private Account? account;

		//path to the json file containing username and password 
		private string jsonFilePath = "JSON/userAccountInfo.json";


		//Constructor
		public ReadUserInfo()
		{
			//Read the content of the Json file and deserialize it into an Account object
			string jsonFileContent = File.ReadAllText(jsonFilePath);
			account = JsonSerializer.Deserialize<Account>(jsonFileContent);

		}

		/// <summary>
		/// Get the user account information
		/// </summary>
		/// <returns>The user account object, or null if not available</returns>
		public Account? getAccount()
		{
			return account;
		}
	}
}
