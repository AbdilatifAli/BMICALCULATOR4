using System;
using BMICALCULATOR3.Models;
using BMICALCULATOR3.Data;
using BMICALCULATOR3.ViewModels;
using BMICALCULATOR3.Views;

namespace BMICALCULATOR3
{
    public partial class MainPage : ContentPage
    {
        private UserViewModel _userViewModel;

        const double UnderweightThreshold = 20.5;
        const double NormalWeightTreshold = 25.9;
        const double OverweightThreshold = 30.9;

        public MainPage()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var age = double.Parse(Age.Text);
            var weight = double.Parse(Weight.Text);
            var height = double.Parse(Height.Text) / 100;

            var imc = weight / (height * height);

            BMI.Text = imc.ToString("F2");

            string result = GetBmiResultMessage(imc);
            await DisplayAlert("Result", result, "OK");

            var user = new Users
            {
                UserId = Guid.NewGuid(),
                Name = name,
                Age = age,
                Weight = weight,
                Height = height,
                Bmi = imc,
            };
            await _userViewModel.AddUserAsync(user);
        }
        private string GetBmiResultMessage(double imc)
        {
            if (imc < UnderweightThreshold)
            {
                return "Du är UnderVikt";
            }
            else if (imc <= NormalWeightTreshold)
            {
                return "Du är NormalVikt";
            }
            else if (imc <= OverweightThreshold)
            {
                return "Du är ÖverVikt";
            }
            else
            {
                return "Du har Fetma";
            }
        }
        private async void OnClickedGoWeatherPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.WeatherPage1());
        }
        private async void OnClickedGoHistorypage(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            var age = double.Parse(Age.Text);
            var weight = double.Parse(Weight.Text);
            var height = double.Parse(Height.Text) / 100;

            var imc = weight / (height * height);

            var user = new Users
            {
                UserId = Guid.NewGuid(),
                Name = name,
                Age = age,
                Weight = weight,
                Height = height,
                Bmi = imc,
            };

            await _userViewModel.AddUserAsync(user);
            await Navigation.PushAsync(new HPage(user));
        }
        private async void OnClickedGoEditUserpage(object sender, EventArgs e)
        {
            Users currentUser = new Users();
            await Navigation.PushAsync(new Views.EditUserpage(currentUser));
        }
    }
}
