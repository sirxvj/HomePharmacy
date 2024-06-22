namespace HomePharmacy;

public partial class Apteka : ContentPage
{
	public Apteka()
	{
		InitializeComponent();

	}
    private async void OnAddClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddApteku");
    }
    private async void OnAptekaClick(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync("AddApteku");
        await Navigation.PushAsync(new AptekaDetails());
    }
}