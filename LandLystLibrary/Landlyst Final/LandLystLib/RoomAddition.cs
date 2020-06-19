namespace LandLystLib
{
    public class RoomAddition
    {
        private string addtion;
        private double price;

        public string Addtion
        {
            get { return addtion; }
        }
        public double Price
        {
            get { return price; }
        }

        public RoomAddition(string addtion, double price)
        {
            this.addtion = addtion;
            this.price = price;
        }
    }
}