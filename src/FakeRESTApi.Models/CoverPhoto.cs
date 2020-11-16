using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeRestAPI.Models
{
    public class CoverPhoto
    {

        public int ID { get; set; }

        public int IDBook { get; set; }

        public Uri Url { get; set; }

    }
}