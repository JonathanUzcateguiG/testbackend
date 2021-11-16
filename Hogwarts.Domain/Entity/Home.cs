using Hogwarts.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hogwarts.Domain.Entity
{
    public class Home : BaseEntity
    {
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
    }
}
