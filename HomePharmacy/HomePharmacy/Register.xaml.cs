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
}