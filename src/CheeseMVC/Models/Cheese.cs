namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CheeseCatagory Catagory { get; set; }
        public int ID { get; set; }
        public int CatagoryID { get; set; }
    }
}
