using System;
namespace BMICALCULATOR3.Views;

public partial class WeatherPage1 : ContentPage
{
	public WeatherPage1()
	{
		InitializeComponent();
	}

    private async void OnClickedGetWeather(object sender, EventArgs e)

    {
        try
        {
            string WeatherInput = MyInput.Text;
            Models.Weather weatherData = await ViewModels.WeatherViewModel.GetWeatherAsync(WeatherInput);
            if (weatherData != null)
            {
                Temperature.Text = $"Temperatur: {weatherData.temp}°C";
                FeelsLike.Text = $"Känns som: {weatherData.feels_like}°C";
                MinMaxTemp.Text = $"Min/Max Temperatur: {weatherData.min_temp}°C / {weatherData.max_temp}°C";
                Hum.Text = $"Luftfuktighet: {weatherData.humidity}%";
            }
            else
            {

                Console.WriteLine("Väder hittades inte eller GetWeatherAsync returnerade null.");
            }
        }

        catch (Exception ex)
        {
           
            Console.WriteLine($"Error i metoden OnClickedGetWeatherInfo: {ex.Message}");
        }
    }
}