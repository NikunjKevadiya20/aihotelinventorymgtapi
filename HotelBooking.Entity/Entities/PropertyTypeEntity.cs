using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entity.Entities
{
        public class PropertyTypeEntity
        {
            public int? ID { get; set; }
            public string? Title { get; set; }
            public Boolean? IsActive { get; set; }
            public Int32? CreatedBy { set; get; }
            public Int32? UpdatedBy { set; get; }
            public string? Details { get; set; }
            public string? Message { get; set; }

        }


        public class PropertyTypeIDEntity : MessageBaseEntity
        {
            public int? ID { get; set; }
            public string? Title { get; set; }
            public Int32? UpdatedBy { set; get; }
            public Boolean? IsActive { get; set; }
        }

        public class PropertyTypeViewEntity
        {
            public int? ID { get; set; }
            public string? Title { get; set; }
            public string? ImageUpload { get; set; }
            public Boolean? IsActive { get; set; }
            public string? Details { get; set; }
            public string? Message { get; set; }
            public int? Status { get; set; }
            public string? ErrorMessage { get; set; }

        }
}
