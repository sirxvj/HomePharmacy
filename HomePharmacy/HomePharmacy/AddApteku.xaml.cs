using HomePharmacy.Models;

namespace HomePharmacy;

public partial class AddApteku : ContentPage
{
    public event EventHandler<Models.Apteka> AptekaAdded;
    public AddApteku()
	{
		InitializeComponent();
	}
    private async void OnOkButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NameEntry.Text))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Введите корректные данные!", "ОК");
        }

        var newApteka = new Models.Apteka();
        newApteka.Name = NameEntry.Text; 

        AptekaAdded?.Invoke(this, newApteka);
        await Navigation.PopAsync();
    }
}