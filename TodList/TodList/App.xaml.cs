using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodList.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodList
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new ToDoListView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
