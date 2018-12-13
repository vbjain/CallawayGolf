using System.Collections.Generic;

namespace Demo.Common
{
    public class Model
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public List<Product> Products { get; set; }
    }
}
