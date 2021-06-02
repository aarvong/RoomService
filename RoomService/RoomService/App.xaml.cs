using Xamarin.Forms;
using RoomService.Class;

namespace RoomService
{
    public partial class App : Application
    {
        static RoomServiceDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static RoomServiceDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RoomServiceDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
