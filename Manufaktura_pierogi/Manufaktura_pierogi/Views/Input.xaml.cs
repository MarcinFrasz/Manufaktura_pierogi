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
    public partial class Input : ContentPage
    {
        public Input()
        {
            InitializeComponent();
        }

        private async void Onbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Manufaktura_pierogi.Views.Output());
        }

    }
}