﻿namespace HomePharmacy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Shell.Current.GoToAsync("MainPage");
        }
    }
}
