using MongoDB.Driver;
using SimpleGuestbookMongoDb.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMongoDb
{
    public class GuestbookRepository
    {
        private readonly IMongoCollection<GuestbookPostDto> _posts;

        public GuestbookRepository(GuestbookDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _posts = database.GetCollection<GuestbookPostDto>("Posts");
        }

        public void Add(GuestbookPostDto post)
        {
            post.CreatedOn = DateTime.UtcNow;
            _posts.InsertOne(post);
        }

        public List<GuestbookPostDto> GetAll()
        {
            var result = _posts.Find(x => true);
            return result.ToList();
        }
    }
}
