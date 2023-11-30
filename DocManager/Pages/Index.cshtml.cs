
using DocManager.Controller.UserAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DocManager.Pages
{
    public class IndexModel : PageModel
    {
        //Static fields to store the username and password across all instances of this class
        private static string? storedUsername { get; set; } = String.Empty;
        private static string? storedPassword { get; set; } = String.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/>
        /// </summary>
        public IndexModel()
        {
            //Create an instance of ReadUserInfo to retrieve user account information
            ReadUserInfo readUserInfo = new ReadUserInfo();

            //Get the user account information
            Account? account = readUserInfo.getAccount();

            //Store the username and password in static fields
            storedUsername = account.username;
            storedPassword = account.password;
        }



        //This method is executed when the form is submitted 
        public IActionResult OnPost()
        {
            //Retrieve the values submitted in the form
            string username = Request.Form["Username"];
            string password = Request.Form["Password"];

            //check if the provided username and password are valid
            if (ValidateAccount(username, password))
            {
                return RedirectPermanent("/App");
			}
            else
            {
                //Incorrect username and password
                string errorMessage = "The username or password that you have entered to login is incorrect.";
                return RedirectToPage("/Error", new {message = errorMessage});
			}
			
		}

        //Validate the provided username and password
        private bool ValidateAccount(string username, string password)
        {
            //Check if the username is a specific value
            if(username == storedUsername)
            {
                //check if the password matches the expected value
                if(password == storedPassword)
                {
                    //valid username and password
                    return true;
                }
                else
                {
                    //Incorrect password
                    return false;
                }
            }
            else
            {
                //Incorrect username
                return false;
            }
        }
    }
}