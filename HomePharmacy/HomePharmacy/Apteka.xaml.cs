using System.Collections.ObjectModel;
using HomePharmacy.Models;
namespace HomePharmacy;

public partial class Apteka : ContentPage
{
    public ObservableCollection<Apteka> Aptekas { get; set; }
	public Apteka()
	{
		InitializeComponent();
        Aptekas = new ObservableCollection<Apteka>();
        AptekasCollectionView.ItemsSource = Aptekas;
	}
    private async void OnAddClick(object sender, EventArgs e)
    {
        var addNewAptekaPage = new AddApteku();
        addNewAptekaPage.AptekaAdded += OnAptekaAdded;
        await Navigation.PushAsync(addNewAptekaPage);
        //await Shell.Current.GoToAsync("AddApteku");
    }
    private async void OnAptekaClick(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync("AddApteku");
        await Navigation.PushAsync(new AptekaDetails());
    }

    private void OnAptekaAdded(object sender, Models.Apteka e)
    {
        Aptekas.Add(e);
    }
}