using SimpleGuestbookMongoDb.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMongoDb.Models
{
    public class GuestbookViewModel
    {
        public List<GuestbookPostDto> Posts { get; set; }
    }
}
