using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Domain.Configuration
{

    public class Settings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string AzureHogwartsContext { get; set; }
    }

}
