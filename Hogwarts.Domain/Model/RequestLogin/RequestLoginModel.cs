using Hogwarts.Domain.Model.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Domain.Model.RequestLogin
{
    public class RequestLoginModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Identification { get; set; }

        public int Age { get; set; }

        public HomeModel Home { get; set; }
        public long HomeId { get; set; }
    }
}
