using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace HomePharmacy;

public partial class Recept : ContentPage
{
    public ObservableCollection<Models.Recept> Recepts { get; set; }
    List<Models.Recept> recepts; 
	public Recept()
	{
		InitializeComponent();
        Recepts = new();
        TextReader reader = null;
        recepts = new List<Models.Recept>();
        var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "recepts.json");
        try
        {
            reader = new StreamReader(filePath);
            var fileContents = reader.ReadToEnd();
            recepts  = JsonConvert.DeserializeObject<IEnumerable<Models.Recept>>(fileContents).ToList();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
        if (recepts.Count() != 0)
        {
            foreach(var recept in recepts)
            {
                Recepts.Add(recept);
            }
        }
        ReceptsCollection.ItemsSource = Recepts;
    }
    private async void OnReceptClick(object sender, EventArgs e)
    {

        //await Shell.Current.GoToAsync("AddApteku");
        var recept = Recepts.Where(x => x.Name == ((TappedEventArgs)e).Parameter?.ToString()).FirstOrDefault();
        var detailsPage = new ReceptDetails(recept);
        detailsPage.ReceptEdited += OnReceptEdited;
        detailsPage.ReceptDeleted += OnReceptDeleted;
        if (recept is not null)
            await Navigation.PushAsync(detailsPage);
    }

    private void OnReceptEdited(object sender, Models.Recept e)
    {
        var old = Recepts.Where(x => x.Name == e.Name).First();
        e.Medicines = old.Medicines;
        recepts.Remove(old);
        recepts.Add(e);
        Recepts.Remove(old);
        Recepts.Add(e);
    }
    private void OnReceptDeleted(object sender, Models.Recept e)
    {
        var old = Recepts.Where(x => x.Name == e.Name).First();

        Recepts.Remove(old);
        recepts.Remove(old);
    }

}