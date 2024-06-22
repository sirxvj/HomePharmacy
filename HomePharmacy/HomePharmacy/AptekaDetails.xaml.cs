using HomePharmacy.Models;
using System.Collections.ObjectModel;

namespace HomePharmacy;

public partial class AptekaDetails : ContentPage
{
	public AptekaDetails(Models.Apteka apteka)
	{
		InitializeComponent();
		BindingContext = apteka;
	}
}