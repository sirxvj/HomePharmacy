using HomePharmacy.Models;
using System.Collections.ObjectModel;

namespace HomePharmacy;

public partial class Register : ContentPage
{
    public ObservableCollection<User> Users { get; set; }
	public Register()
	{
		InitializeComponent();
        BindingContext = this;
        Users = new();
	}
    private async void OnLogClick(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("MainPage");
        //await Navigation.PushAsync(new Register());
    }
    private async void OnRegClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text)
            || string.IsNullOrEmpty(SecondPasswordEntry.Text))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Введите корректные данные!", "ОК");
            return;
        }
        if (PasswordEntry.Text != SecondPasswordEntry.Text)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Пароли не совпадают!", "ОК");
            return;
        }
        Users.Add(new User(EmailEntry.Text, PasswordEntry.Text));
        await Shell.Current.GoToAsync("Apteka");
        Shell.SetTabBarIsVisible(Application.Current.MainPage, true);
        // await Shell.Current.GoTosync("//Sign/Register");
        //await Navigation.PushAsync(new Register());
    }
}