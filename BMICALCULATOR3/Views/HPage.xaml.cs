using MongoDB.Driver;
using BMICALCULATOR3.Data;
using BMICALCULATOR3.Models;
using BMICALCULATOR3.ViewModels;

namespace BMICALCULATOR3.Views;

public partial class HPage : ContentPage
{
    private readonly Users _user;

    public HPage(Users user)
    {
        InitializeComponent();
        _user = user;
        BindingContext = _user;
    }
}
