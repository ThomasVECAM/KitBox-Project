namespace Interface_5
{
    public class Corner
    {
        private string id, color;
        private int height;
        private double price;
        public int quantity;

        public Corner(string id, int height, double price, int quantity, string color)
        {
            this.id = id;
            this.height = height;
            this.price = price;
            this.quantity = quantity;
            this.color = color;
        }
        public double GetPrice
        {
            get { return this.price; }
        }
        public int GetHeight
        {
            get { return this.height; }
        }
        public string GetColor
        {
            get { return this.color; }
        }
    }
}
