﻿namespace Interface_5
{
    public class Traverse : Component
    {
        private string orientation;
        public Traverse(string id, int height, int width, int depth,
            double price, int quantity) : base(id, height, width, depth, price, quantity)
        {
            if (id.Contains("TRR"))
            {
                this.orientation = "back";
            }
            else if (id.Contains("TRF"))
            {
                this.orientation = "front";
            }
            else
            {
                this.orientation = "side";
            }
            this.name = "Traverse";
        }
    }
}