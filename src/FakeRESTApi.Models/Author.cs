using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeRestAPI.Models
{
    public class Author
    {

        public int ID { get; set; }

        public int IDBook { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}