using HomePharmacy.Models;
using System.Collections.ObjectModel;

namespace HomePharmacy;

public partial class AptekaDetails : ContentPage
{
	Models.Apteka LocalApteka { get; set; }
    public event EventHandler<Models.Apteka?> AptekaEdited;
    public event EventHandler<Models.Apteka?> AptekaDeleted;
    
    public AptekaDetails(Models.Apteka apteka)
	{
		InitializeComponent();
       
        BindingContext = apteka;
		LocalApteka = apteka;
        BindingContext = LocalApteka;
    }
    private async void OnAddClick(object sender, EventArgs e)
    {
        var addNewMedicinePage = new AddMedicine();
        addNewMedicinePage.MedAdded += OnMedAdded;
        await Navigation.PushAsync(addNewMedicinePage);
        //await Shell.Current.GoToAsync("AddApteku");
    }
    private void OnMedAdded(object sender, Models.Medicine e)
    {
        LocalApteka.Medicines.Add(e);
    }
    private async void OnEditClick(object sender, EventArgs e)
    {
        var addNewMedicinePage = new EditApteka();
        addNewMedicinePage.AptekaEdited += OnEdited;
        addNewMedicinePage.AptekaDeleted += OnDeleted;
        await Navigation.PushAsync(addNewMedicinePage);
        //await Shell.Current.GoToAsync("AddApteku");
    }
    private async void OnReceptClick(object sender, EventArgs e)
    {
        var recept = new AddRecept(LocalApteka.Medicines);
        await Navigation.PushAsync(recept);
    }
    private void OnEdited(object sender, Models.Apteka e)
    {
        
        LocalApteka.Name = e.Name;
        BindingContext = LocalApteka;
        NameLabel.BindingContext = LocalApteka;
        AptekaEdited.Invoke(this, e);
    }
    private async void OnDeleted(object sender, Models.Apteka e)
    {

       e.Name = LocalApteka.Name;
        AptekaDeleted.Invoke(this, e);
        await Navigation.PopAsync();
    }

}