using RoomService.Class;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FADConfirmation : ContentPage
    {
        FADConfirmData cData;

        public FADConfirmation(FADConfirmData fADConfirmData)
        {
            InitializeComponent();

            cData = fADConfirmData;

            BindingContext = fADConfirmData;
            steakQty.Text = fADConfirmData.steakQty.ToString("F0");
            wineQty.Text = fADConfirmData.wineQty.ToString("F0");
            Total.Text = fADConfirmData.total.ToString("F2");
        }

        async private void OnConfirmClicked(object sender, EventArgs e)
        {
            BookingData bookingData = new BookingData()
            {
                ItemName = "Food and Drinks",
                BookingTime = DateTime.Now,
                Quantity = cData.total
            };
            await App.Database.SaveItemAsync(bookingData);

            await DisplayAlert(null, "Thank You!!", "BACK TO HOME");
            await Navigation.PopToRootAsync();
        }

        async private void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}