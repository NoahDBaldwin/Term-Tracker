using C971.ViewModels;

namespace C971;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel loginViewModel;

    public LoginPage()
	{
		InitializeComponent();
        BindingContext = loginViewModel = new LoginViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}