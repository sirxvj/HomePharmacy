namespace HomePharmacy;

public partial class ReceptDetails : ContentPage
{
    Models.Recept LocalRecept { get; set; }
    public event EventHandler<Models.Recept?> ReceptEdited;
    public event EventHandler<Models.Recept?> ReceptDeleted;
    public ReceptDetails(Models.Recept recept)
	{
		InitializeComponent();
        BindingContext = recept;
        LocalRecept = recept;
        BindingContext = LocalRecept;
    }

    private async void OnEditClick(object sender, EventArgs e)
    {
        var addNewMedicinePage = new EditRecept();
        addNewMedicinePage.ReceptEdited += OnEdited;
        addNewMedicinePage.ReceptDeleted += OnDeleted;
        await Navigation.PushAsync(addNewMedicinePage);
        //await Shell.Current.GoToAsync("AddApteku");
    }

    private void OnEdited(object sender, Models.Recept e)
    {

        LocalRecept.Name = e.Name;
        LocalRecept.Date = e.Date;
        LocalRecept.Status=e.Status;
        BindingContext = LocalRecept;
        NameLabel.BindingContext = LocalRecept;
        ReceptEdited.Invoke(this, e);
    }
    private async void OnDeleted(object sender, Models.Recept e)
    {

        e.Name = LocalRecept.Name;
        e.Date = LocalRecept.Date;
        e.Status = LocalRecept.Status;
        ReceptDeleted.Invoke(this, e);
        await Navigation.PopAsync();
    }


}