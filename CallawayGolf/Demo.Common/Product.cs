using Demo.Common.Enumerations;

namespace Demo.Common
{
    public class Product
    {
        public string Description { get; set; }
        public Hand Hand { get; set; }
        public int SortOrder { get; set; }
        public Gender Gender { get; set; }
        public int Inventory { get; set; }
    }
}
