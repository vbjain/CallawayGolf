using Demo.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.CoreWeb.Models
{
    public class RootModel
    {
        public List<Category> Categories { get; set; }
        public IFormFile JsonFile { get; set; }
    }
}
