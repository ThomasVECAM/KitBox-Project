namespace Interface_5
{
    public class Door : Component
    {
        private string color;
        public Door(string id, int height, int width, int depth,
            double price, int quantity, string color) : base(id, height, width, depth, price, quantity)
        {
            this.color = color;
        }
        public string GetColor
        {
            get { return this.color; }
        }
    }
}
