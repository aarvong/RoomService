using RoomService.Class;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingConfirmation : ContentPage
    {
        ConfirmData cData;

        public BookingConfirmation(ConfirmData confirmData)
        {
            InitializeComponent();

            cData = confirmData;

            BindingContext = confirmData;
            confirmDate.Text = confirmData.chosenDate.ToString("d");
            confirmTime.Text = confirmData.chosenTime.ToString(@"hh\:mm");
            confirmNum.Text = confirmData.finalNumOfPpl.ToString("F0");
        }

        async private void ButtonConfirm_Clicked(object sender, EventArgs e)
        {
            BookingData bookingData = new BookingData()
            {
                ItemName = cData.shopName,
                BookingTime = cData.chosenDate,
                Quantity = cData.finalNumOfPpl
            };
            await App.Database.SaveItemAsync(bookingData);

            await DisplayAlert("", "Thank You!!", "Back to Home");
            await Navigation.PopToRootAsync();
        }

        async private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}