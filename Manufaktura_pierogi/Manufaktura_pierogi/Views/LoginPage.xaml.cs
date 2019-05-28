using Manufaktura_pierogi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Manufaktura_pierogi.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial  class LoginPage : ContentPage
	{
		public  LoginPage ()
		{
			InitializeComponent ();
            Init();
        }

        void Init()
        {
            BackgroundColor = Globals.BackgroundColor;
            Lbl_Username.TextColor = Globals.MainTextColor;
            Lbl_Password.TextColor = Globals.MainTextColor;          
            LogInIcon.HeightRequest = Globals.LogInIconHeight;         

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();           
        }

        List<Items> item = new List<Items>();

        public async Task<List<Items>> ReadData()
        {
           HttpClient client = new HttpClient();
           Uri uri = new Uri("http://quivery-delegate.000webhostapp.com/database_select_login.php");

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<List<Items>>(content);
            }
            else
            {
                Lbl_Username.Text = "Failed to connect";
            }
            return item;
        }

        public class Items
        {
            public string username { get; set; }
            public string password { get; set; }
        }


        async Task SignInProcedureAsync(object sender, EventArgs e)
        {
            List<Items> Login_list = await ReadData();
            
            for (int i = 0; i < Login_list.Count; i++)
            {
                if (Login_list[i].username == Entry_Username.Text)
                {                   
                    if(Login_list[i].password==Entry_Password.Text)
                    {
                        Navigation.PushAsync(new Manufaktura_pierogi.Views.Input());
                        break;
                    }
                }
                else
                {
                    Lbl_Username.Text = "Fail";
                }
            }
        }

        private  async Task Send_credentials_php(object sender, EventArgs e)
        {
            Uri url = new Uri("http://quivery-delegate.000webhostapp.com/database_check_login.php");
            WebClient client = new WebClient();
            NameValueCollection parameter = new NameValueCollection();
            string username = Entry_Username.Text;
            string password = Entry_Password.Text;
            parameter.Add("user_login", username);
            parameter.Add("user_password", password);

            byte[] response=client.UploadValues(url, parameter);

            string check = System.Text.Encoding.UTF8.GetString(response);
            check = check.Trim();
            if (check == "true")
            {
                Navigation.PushAsync(new Manufaktura_pierogi.Views.Input());
            }
            else
            {
                var v = check;
            }
        }
    }
}