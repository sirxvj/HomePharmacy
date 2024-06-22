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
}