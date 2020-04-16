namespace Interface_5
{
    public class Door : Component
    {
        private string color;
        public Door(string id, int height, int width, int depth,
            double price, int quantity, string color, int quantityNeedBox) : base(id, height, width, depth, price, quantity, quantityNeedBox)
        {
            this.color = color;
        }
        public string GetColor
        {
            get { return this.color; }
        }
    }
}
