namespace Interface_5
{
    public class Corner
    {
        private string id, color;
        private int height, quantityNeedBox, quantity;
        private double price;

        public Corner(string id, int height, double price, int quantity, string color, int quantityNeedBox)
        {
            this.id = id;
            this.height = height;
            this.price = price;
            this.quantity = quantity;
            this.color = color;
            this.quantityNeedBox = quantityNeedBox;

        }
        public double GetPrice
        {
            get { return this.price*quantityNeedBox; }
        }
        public int GetHeight
        {
            get { return this.height; }
        }
        public string GetColor
        {
            get { return this.color; }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        public int GetQuantityNeedBox
        {
            get { return this.quantityNeedBox; }
        }
        public string GetID
        {
            get { return this.id; }
        }
    }
}
