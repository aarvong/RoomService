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
    public partial class FoodAndDrink : ContentPage
    {
        public FoodAndDrink()
        {
            InitializeComponent();
        }

        private void steakStpr_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            steakQty.Text = string.Format("Quantity: {0:F0}", value);
        }

        private void wineStpr_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            wineQty.Text = string.Format("Quantity: {0:F0}", value);
        }

        async private void OnButtonClicked(object sender, EventArgs e)
        {
            FADConfirmData data = new FADConfirmData(steakStpr.Value, wineStpr.Value);
            var conf = new FADConfirmation(data);
            await Navigation.PushAsync(conf);
        }
    }
}