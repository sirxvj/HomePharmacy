using Maui.GoogleMaps;

namespace HomePharmacy;

public partial class Map : ContentPage
{
	public Map()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        PermissionStatus result = await CheckAndRequestLocationPermission();

        if (result == PermissionStatus.Granted)
        {

            Location location = await Geolocation.Default.GetLocationAsync();
            
            if (location != null)
            {
                Maui.GoogleMaps.Position myposition = new Maui.GoogleMaps.Position(location.Latitude, location.Longitude);


                await mymap.MoveCamera(CameraUpdateFactory.NewCameraPosition(
                           new CameraPosition(
                              myposition, // Tokyo
                               17d, // zoom
                               45d, // bearing(rotation)
                               60d // tilt
                               )));
                Pin _pinA = new Pin()
                {
                    Icon = BitmapDescriptorFactory.FromBundle("human1"), //don't use extension
                    Type = PinType.Place,
                    Label = "My position",
                    Address = myposition.Latitude.ToString() + myposition.Longitude.ToString(),
                    Position = myposition
                
        
                };
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "����� �103",
                    Address = "��. ��������� 16",
                    Position = new Position(53.95950452893426, 27.616673083899546)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "�����",
                    Address = "��������� ����� 7, �����, ������� �������, ��������",
                    Position = new Position(53.94408248768406, 27.605613162421353)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������ ADEL �2",
                    Address = "��. ��������� �. 40, �����, ������� �������, ��������",
                    Position = new Position(53.92426599323242, 27.578925091521043)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������ ������� ��������",
                    Address = "��. ������������� 48, �����, ������� ������� 220089, ��������",
                    Position = new Position(53.9154871099015, 27.579405957874535)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "��������� ������ �18 �������",
                    Address = "��. ����������� ������� 13, ���.2�, �����, ������� �������, ��������",
                    Position = new Position(53.908264386941276, 27.53949406732279)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������ ������� ��������",
                    Address = "��. ������������� 18, �����, ������� �������, ��������",
                    Position = new Position(53.902173669496605, 27.55848828029621)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������",
                    Address = "����� �������� 1, �����, ������� �������, ��������",
                    Position = new Position(53.90146538890196, 27.573395130984213)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������",
                    Address = "��. ������������� 7/1, ����� �������: 8 017 245-31-11 - ������� �� ����������, ��. ������������� 7, �����, ��������",
                    Position = new Position(53.90429843923455, 27.600083202377245)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������",
                    Address = "������� ������������������ 5, �����, ������� �������, ��������",
                    Position = new Position(53.89112312471876, 27.614509186914024)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������ �����������",
                    Address = "��. ������������ 11/5, �����, ������� �������, ��������",
                    Position = new Position(53.88389618803909, 27.54286013057929)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������ � 8 �����������",
                    Address = "����� ������� 17, �����, ������� �������, ��������",
                    Position = new Position(53.87893580282909, 27.533723673706)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������ ������� ��������",
                    Address = "����� ����������� 146, �����, ������� �������, ��������",
                    Position = new Position(53.8748253235276, 27.569788635047942)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "������ �����������",
                    Address = "����� ����������� 146, �����, ������� �������, ��������",
                    Position = new Position(53.92219461275831, 27.4793713042543)
                });
                mymap.Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin2"),
                    Label = "����������� ������ � 91",
                    Address = "����� ����������� 146, �����, ������� �������, ��������",
                    Position = new Position(53.90410274573088, 27.43528862354487)
                });

                mymap.Pins.Add(_pinA);
                //mymap.Pins.Add(_pinA);
            }

        }
    }



    async Task<PermissionStatus> CheckAndRequestLocationPermission()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings
            // On iOS once a permission has been denied it may not be requested again from the application
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        {
            // Prompt the user with additional information as to why the permission is needed
        }

        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        return status;
    }
}//api AIzaSyD3bLtZkNPObtKxnT7aa74Mh4qbcBYj8rU