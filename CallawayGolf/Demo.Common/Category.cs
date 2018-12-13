using System.Collections.Generic;

namespace Demo.Common
{
    public class Category
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public List<Model> Models { get; set; }

        public string ImageUrl { get; set; }
    }
}
