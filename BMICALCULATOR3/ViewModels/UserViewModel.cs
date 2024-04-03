using BMICALCULATOR3.Data;
using BMICALCULATOR3.Models;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace BMICALCULATOR3.ViewModels
{
    public class UserViewModel
    {
        private readonly IMongoCollection<Users> _userCollection;
        public UserViewModel()
        {
            _userCollection = Db.UserCollection();
        }
        public async Task AddUserAsync(Users user)
        {
            await _userCollection.InsertOneAsync(user);
        }
        public async Task UpdateUserAsync(Users user)
        {
            var filter = Builders<Users>.Filter.Eq("_id", user.UserId);
            var update = Builders<Users>.Update
                .Set(u => u.Name, user.Name)
                .Set(u => u.Age, user.Age)
                .Set(u => u.Weight, user.Weight)
                .Set(u => u.Height, user.Height)
                .Set(u => u.Bmi, user.Bmi);

            await _userCollection.UpdateOneAsync(filter, update);
        }
        public async Task DeleteUserAsync(Guid id)
        {
            var filter = Builders<Users>.Filter.Eq("_id", id);
            await _userCollection.DeleteOneAsync(filter);
        }
    }
}
