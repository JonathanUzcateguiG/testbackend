using Hogwarts.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hogwarts.Domain.Entity
{
    public class RequestLogin : BaseEntity
    {
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }

        public int Identification { get; set; }

        public int Age { get; set; }

        public Home Home { get; set; }
        public long HomeId { get; set; }
    }
}
