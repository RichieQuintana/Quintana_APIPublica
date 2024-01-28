using Newtonsoft.Json;
using Quintana_EjemploAPI.Models;

namespace Quintana_EjemploAPI.Views;

public partial class ClimaActual : ContentPage
{
    public ClimaActual()
	{
        InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string latitud = lat.Text;
		string longitud = lon.Text;

		if (Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			using (var client = new HttpClient()) 
			{
				string url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=b6061fb17251f168d842940a7ec5e622/r/n";

                var response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode) {
					var json = await response.Content.ReadAsStringAsync();
					var clima = JsonConvert.DeserializeObject<Rootobject>(json);

					weatherLabel.Text = clima.weather[0].main;
					cityLabel.Text = clima.name;

                }
			
			}
		}
    }
}