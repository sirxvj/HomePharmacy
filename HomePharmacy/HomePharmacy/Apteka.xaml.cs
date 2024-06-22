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
            Name = "�������� �������",
            Medicines = new ObservableCollection<Medicine>
            {
                new Medicine ("��������","��������� ������",new DateTime(2018, 5, 12),"0 ����."),
                new Medicine ("���������","���������",new DateTime(2018, 5, 12),"5 ���.")
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
    //private async void OnAptekaClick(object sender, EventArgs e)
    //{
    //    //await Shell.Current.GoToAsync("AddApteku");
    //    await Navigation.PushAsync(new AptekaDetails());
    //}

    private void OnAptekaAdded(object sender, Models.Apteka e)
    {
        Aptekas.Add(e);
    }

    private async void AptekasCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedApteka = e.CurrentSelection.FirstOrDefault() as Models.Apteka;
        if (selectedApteka != null)
        {
            var aptekaDetailsPage = new AptekaDetails(selectedApteka);
            
            await Navigation.PushAsync(aptekaDetailsPage);

            // ������� ���������
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}