
using C971.Database;
using C971.Models;
using C971.ViewModels;
using Plugin.LocalNotification;
using System.Diagnostics;

namespace C971
{

    // Get the userID from login page current user
    [QueryProperty("UserId", "userId")]

    public partial class MainPage : ContentPage
    {
        //private readonly MainPageViewModel mainPageViewModel;


        
        public int UserId { get; set; }

        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            //BindingContext = mainPageViewModel = new MainPageViewModel();
        }

        protected override async void OnAppearing()
        {

            //base.OnAppearing();
            //await mainPageViewModel.GetCurrentUser(UserId);
            //mainPageViewModel.OnAppearing(UserId);

            ViewModel = new MainPageViewModel();
            await ViewModel.GetCurrentUser(UserId);
            BindingContext = ViewModel;
            base.OnAppearing();
            ViewModel.OnAppearing(UserId);

        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            int termId = Convert.ToInt32(e.Parameter);
     
            await Shell.Current.GoToAsync("TermContentPage?termId=" + termId);
        }

        
       
    }

}
