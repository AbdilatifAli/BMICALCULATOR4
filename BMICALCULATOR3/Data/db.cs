using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using MongoDB;
using MongoDB.Driver;

namespace BMICALCULATOR3.Data
{
    public class Db
    {
        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://mayezmaa:601151Ab@cluster0.xxfb3fg.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            return mongoClient;
        }

        public static IMongoCollection<Models.Users> UserCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("Myusers");

            var UserCollection = database.GetCollection<Models.Users>("Myusers");

            return UserCollection;
        }

    }
}

