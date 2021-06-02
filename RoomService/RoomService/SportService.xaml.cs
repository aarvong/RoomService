using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SportService : ContentPage
    {
        public SportService()
        {
            InitializeComponent();
        }

        async private void TapGestureRecognizer_Gym(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingPage());
        }

        async private void TapGestureRecognizer_Snooker(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingPage());
        }
    }
}