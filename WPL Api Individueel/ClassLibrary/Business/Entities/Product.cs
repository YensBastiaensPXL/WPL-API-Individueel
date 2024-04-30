namespace ClassLibrary.Business.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int PricePerUnit { get; set; }
        public int Stock { get; set; }
        public int Category { get; set; }
        public string Size { get; set; }
    }
}
