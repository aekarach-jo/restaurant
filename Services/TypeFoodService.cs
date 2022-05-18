using MongoDB.Driver;
using restertaunt.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace restertaunt.Services
{
    public class TypeFoodService
    {
        private readonly IMongoCollection<TypeFood> _typefood;
        public TypeFoodService(DatabaseSettings settings)
        {
            var Client = new MongoClient(settings.ConnectionString);
            var database = Client.GetDatabase(settings.DatabaseName);
            _typefood = database.GetCollection<TypeFood>(settings.TypeFoodCollection);
        }

        public TypeFood CreateTypeFood(TypeFood typeFood)
        {
             _typefood.InsertOne(typeFood);
             return typeFood;
        }

        public List<TypeFood> GetTypeFood() => _typefood.Find(tf => tf.status != "deleted").ToList();
        public List<TypeFood> GetTypeFoodForApi() => _typefood.Find(tf => true).ToList();
    }
}