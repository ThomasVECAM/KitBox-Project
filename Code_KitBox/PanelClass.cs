namespace Interface_5
{
    public class PanelClass : Component
    {
        private string orientation, color;

        public PanelClass(string id, int height, int width, int depth,
        double price, int quantity, string color, int quantityNeedBox) : base(id, height, width, depth, price, quantity, quantityNeedBox)
        {
            this.color = color;
            if (height == 0)
                this.orientation = "horizontal";

            else if (depth == 0)
                this.orientation = "back";

            else
                this.orientation = "side";

            this.name = "Panel";
        }
        public string GetColor
        {
            get { return this.color; }
        }
    }
}
