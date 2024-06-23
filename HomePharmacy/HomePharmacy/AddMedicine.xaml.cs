namespace HomePharmacy;

public partial class AddMedicine : ContentPage
{
    public event EventHandler<Models.Medicine> MedAdded;
    public AddMedicine()
	{
		InitializeComponent();
	}
    private async void OnOkButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NameEntry.Text))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Введите корректные данные!", "ОК");
        }

        var newMedicine = new Models.Medicine(NameEntry.Text,SubsEntry.Text,DateEntry.Date,qEntry.Text);
        

        MedAdded?.Invoke(this, newMedicine);
        await Navigation.PopAsync();
    }
}