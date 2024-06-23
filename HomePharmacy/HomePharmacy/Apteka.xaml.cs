using System.Collections.ObjectModel;
using HomePharmacy.Models;
namespace HomePharmacy;

public partial class Apteka : ContentPage
{
    public ObservableCollection<Models.Apteka> Aptekas { get; set; }
	public Apteka()
	{
		InitializeComponent();
        Aptekas = new ObservableCollection<Models.Apteka>();
        AptekasCollectionView.ItemsSource = Aptekas;
        Aptekas.Add(new Models.Apteka
        {
            Name = "Домашняя аптечка",
            Medicines = new ObservableCollection<Medicine>
            {
                new Medicine ("Анальгин","Метамизол натрия",new DateTime(2018, 5, 12),"0 табл."),
                new Medicine ("Ибупрофен","Ибупрофен",new DateTime(2018, 5, 12),"5 свч.")
            }
        });

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
        var apteka = Aptekas.Where(x => x.Name == ((TappedEventArgs)e).Parameter?.ToString()).FirstOrDefault();
        var detailsPage = new AptekaDetails(apteka);
        detailsPage.AptekaEdited += OnAptekaEdited;
        detailsPage.AptekaDeleted += OnAptekaDeleted;
        if (apteka is not null)
            await Navigation.PushAsync(detailsPage);
    }

    private void OnAptekaAdded(object sender, Models.Apteka e)
    {
        Aptekas.Add(e);
    }
    private void OnAptekaEdited(object sender, Models.Apteka e)
    {
        var old = Aptekas.Where(x => x.Name == e.Name).First();
        e.Medicines = old.Medicines;
        Aptekas.Remove(old);
        Aptekas.Add(e);
    }
    private void OnAptekaDeleted(object sender, Models.Apteka e)
    {
        var old = Aptekas.Where(x => x.Name == e.Name).First();
        
        Aptekas.Remove(old);
        
    }

    private async void AptekasCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedApteka = e.CurrentSelection.FirstOrDefault() as Models.Apteka;
        if (selectedApteka != null)
        {
            var aptekaDetailsPage = new AptekaDetails(selectedApteka);
            
            await Navigation.PushAsync(aptekaDetailsPage);

            // Снимите выделение
            ((CollectionView)sender).SelectedItem = null;
        }
    }

}