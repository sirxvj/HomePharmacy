using HomePharmacy.Models;
using Newtonsoft.Json;

namespace HomePharmacy;

public partial class AddRecept : ContentPage
{
	public List<Medicine> Medicines;
	public AddRecept(IEnumerable<Medicine> meds)
	{
		InitializeComponent();
		Medicines = meds.ToList();
		MedicinesCollectionView.ItemsSource = Medicines;

    }

    private async void OnOkButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NameEntry.Text))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Введите корректные данные!", "ОК");
        }

        TextReader reader = null;
        List<Models.Recept> recepts = new();
        var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "recepts.json");
        try
        {
            reader = new StreamReader(filePath);
            var fileContents = reader.ReadToEnd();
            recepts = JsonConvert.DeserializeObject<IEnumerable<Models.Recept>>(fileContents).ToList();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (reader != null)
                reader.Close();
        }



        TextWriter writer = null;
        var recept = new Models.Recept();
        recept.Name = NameEntry.Text;
        recept.Date = DateOnly.FromDateTime(DateTime.Now);
        recept.Medicines = Medicines.Where(x=>x.IsChecked).ToList();
        recepts.Add(recept);


        try
        {
            var contentsToWriteToFile = JsonConvert.SerializeObject(recepts);

            writer = new StreamWriter(filePath, false);
            writer.Write(contentsToWriteToFile);
        }
        finally
        {
            if (writer != null)
                writer.Close();
        }


       

        await Navigation.PopAsync();

    }
    private async void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(NameEntry.Text))
        //{
        //    await Shell.Current.DisplayAlert("Ошибка", "Введите корректные данные!", "ОК");
        //}

        //var newApteka = new Models.Apteka();
        //newApteka.Name = NameEntry.Text;

        ////  AptekaEdited?.Invoke(this, newApteka);
        //await Navigation.PopAsync();
        Console.WriteLine("sdfsdf");
    }
    
}