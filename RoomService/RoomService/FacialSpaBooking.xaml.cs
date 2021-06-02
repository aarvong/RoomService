using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoomService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacialSpaBooking : ContentPage
    {
        readonly string name;
        readonly DateTime checkValue;

        public FacialSpaBooking(string shopName)
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(10, 20, 10, 0);
                    break;
                case Device.Android:
                    Padding = new Thickness(10, 0, 10, 0);
                    break;
                case Device.UWP:
                    Padding = new Thickness(10, 0, 10, 0);
                    break;
            }

            name = shopName;
            BindingContext = shopName;
            Title = string.Format("{0} Booking", shopName);

            checkValue = SetCheckValue();

            datePicker.MinimumDate = DateTime.Now;
            
            SetTimeToNow();

        }

        private void SetTimeToNow()
        {
            if (DateTime.Now.Minute > 0)
            {
                if (DateTime.Now.Hour == 23)
                {
                    timePicker.Time = new TimeSpan(0, 0, 0);
                    datePicker.Date = CheckDate();
                }
                else
                {
                    timePicker.Time = new TimeSpan(DateTime.Now.Hour + 1, 0, 0);
                }
            }
            else
            {
                timePicker.Time = new TimeSpan(DateTime.Now.Hour, 0, 0);
            }
        }

        private DateTime CheckDate()
        {
            int lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            if (DateTime.Now.Month == 12 && DateTime.Now.Day == 31)
            {
                return new DateTime(DateTime.Now.Year + 1, 1, 1);
            }
            else if (DateTime.Now.Day == lastDayOfMonth)
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
            }
            else
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
            }
        }

        private DateTime SetCheckValue()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, 0, 0);
        }

        private void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (timePicker.Time.Minutes != 0)
            {
                timePicker.Time = new TimeSpan(timePicker.Time.Hours, 0, 0);
            }

            DateTime selectedDate = datePicker.Date + timePicker.Time;
            if (selectedDate < checkValue)
            {
                DisplayAlert("Warning", "You cannot select time earlier than current time!", "OK");
                SetTimeToNow();
            }
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            numofppl.Text = string.Format("Number of People: {0:F0}", value);
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            DateTime selectedDate = datePicker.Date + timePicker.Time;
            var data = new ConfirmData(name, selectedDate, stpr.Value);
            var bkconf = new BookingConfirmation(data);
            await Navigation.PushAsync(bkconf);
        }
    }
}