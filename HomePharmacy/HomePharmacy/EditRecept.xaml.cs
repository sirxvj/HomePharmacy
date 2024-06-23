namespace HomePharmacy;

public partial class EditRecept : ContentPage
{
    public event EventHandler<Models.Recept?> ReceptEdited;
    public event EventHandler<Models.Recept?> ReceptDeleted;
    public EditRecept()
	{
		InitializeComponent();
        BindingContext = this;
	}
    private async void OnOkButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(StatusEntry.Text))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Введите корректные данные!", "ОК");
        }

        var newRecept = new Models.Recept();
        newRecept.Name = NameEntry.Text;
        newRecept.Status = StatusEntry.Text;
        newRecept.Date = DateOnly.FromDateTime(DatePick.Date);

        ReceptEdited?.Invoke(this, newRecept);
        await Navigation.PopAsync();

    }
    private async void OnDelButtonClicked(object sender, EventArgs e)
    {

        ReceptDeleted?.Invoke(this, new Models.Recept());
        await Navigation.PopAsync();
        //await Navigation.PopAsync();
    }
}