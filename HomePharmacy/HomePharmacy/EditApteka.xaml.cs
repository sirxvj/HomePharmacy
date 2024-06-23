namespace HomePharmacy;

public partial class EditApteka : ContentPage
{
    public event EventHandler<Models.Apteka?> AptekaEdited;
    public event EventHandler<Models.Apteka?> AptekaDeleted;
    public EditApteka()
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

        AptekaEdited?.Invoke(this, newApteka);
        await Navigation.PopAsync();
       
    }
    private async void OnDelButtonClicked(object sender, EventArgs e)
    {
       
        AptekaDeleted?.Invoke(this, new Models.Apteka());
        await Navigation.PopAsync();
        //await Navigation.PopAsync();
    }
}