namespace HomePharmacy;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}
    private async void OnLogClick(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("MainPage");
        //await Navigation.PushAsync(new Register());
    }
    private async void OnRegClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Apteka");
        Shell.SetTabBarIsVisible(Application.Current.MainPage, true);
        // await Shell.Current.GoTosync("//Sign/Register");
        //await Navigation.PushAsync(new Register());
    }
}