using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMongoDb.Dto
{
    public class GuestbookPostDto
    {
        //Wtf, mongo
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
