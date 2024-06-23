using Newtonsoft.Json;

namespace HomePharmacy;

public partial class Recept : ContentPage
{
    List<Models.Recept> recepts; 
	public Recept()
	{
		InitializeComponent();
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
        ReceptsCollection.ItemsSource = recepts;
    }
    private async void OnReceptClick(object sender, EventArgs e)
    {

        //await Shell.Current.GoToAsync("AddApteku");
        var recept = recepts.Where(x => x.Name == ((TappedEventArgs)e).Parameter?.ToString()).FirstOrDefault();
        var detailsPage = new ReceptDetails(recept);
        //detailsPage.AptekaEdited += OnAptekaEdited;
        //detailsPage.AptekaDeleted += OnAptekaDeleted;
        if (recept is not null)
            await Navigation.PushAsync(detailsPage);
    }
    
}