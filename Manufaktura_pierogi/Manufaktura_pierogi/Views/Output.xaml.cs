using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Manufaktura_pierogi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Output : ContentPage
    {
        public Output()
        {
            InitializeComponent();

        }

        private async void OnBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manufaktura_pierogi.Views.Input());
        }
    }
}