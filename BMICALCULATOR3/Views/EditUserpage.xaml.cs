using System;
using BMICALCULATOR3.Models;
using BMICALCULATOR3.ViewModels;


namespace BMICALCULATOR3.Views
{
    public partial class EditUserpage : ContentPage
    {
        private readonly UserViewModel _userViewModel;
        private readonly Users _user;

        public EditUserpage(Users user)
        {
            InitializeComponent();
            _userViewModel = new UserViewModel();
            _user = user;

        }

 
        private async void OnClickedUpdateUser(object sender, EventArgs e)
        {
            UpdateUserData();
            await _userViewModel.UpdateUserAsync(_user);
            await DisplayAlert("Success", "User information updated successfully.", "OK");
            await Navigation.PopAsync();
        }

        private async void OnClickedDeleteUser(object sender, EventArgs e)
        {
            await _userViewModel.DeleteUserAsync(_user.UserId);
            await DisplayAlert("Success", "User deleted successfully.", "OK");
            await Navigation.PopAsync();
        }

        private void UpdateUserData()
        {
            _user.Name = NameEntry.Text;
            _user.Age = int.Parse(Age.Text);
            _user.Weight = double.Parse(Weight.Text);
            _user.Height = double.Parse(Height.Text);
        }
    }
}
