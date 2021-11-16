using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Domain.Model.RequestLogin
{
    public class CreateRequestLoginDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Identification { get; set; }

        public int Age { get; set; }

        public long HomeId { get; set; }
    }
}
