namespace Interface_5
{

    public abstract class Component
    {
        protected double price;
        protected string id, name;
        protected int width, depth, height, quantity, quantityNeedBox;

        public Component(string id, int height, int width, int depth, double price, int quantity, int quantityNeedBox)
        {
            this.id = id;
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.price = price;
            this.quantity = quantity;
            this.quantityNeedBox = quantityNeedBox;
        }
        public void AddToDB(string furnitureNumber,int boxNumber)
        {
            Globals.MySQLCommandText += "("
                + Globals.componentIndex + ",'"
                + id + "',"
                + Globals.order.Id + ","
                + boxNumber + ",'"
                + furnitureNumber
                + "'),";
        }
        public double GetPrice
        {
            get { return this.price*this.quantityNeedBox; }
        }

        public int GetWidth
        {
            get { return this.width; }
        }

        public int GetHeight
        {
            get { return this.height; }
        }

        public int GetDepth
        {
            get { return this.depth; }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set { quantity = value; }

        }
        public int QuantityNeedBox
        {
            get { return this.quantityNeedBox; }
        }
    }
}