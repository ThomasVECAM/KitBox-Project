using System.Collections.Generic;
using System.IO;

namespace Interface_5
{
    class Box
    {
        private List<Component> componentList, componentToOrder;
        private int width, depth, height;
        private string color, doorColor;
        public bool inStock;
        private bool hasDoor;

        public Box(int width, int depth)
        {
            componentList = new List<Component>();
            componentToOrder = new List<Component>();
            this.height = 0;
            this.width = width;
            this.depth = depth;
            this.color = "";
            this.hasDoor = false;
            this.inStock = true;
            this.doorColor = "";
        }

        public void AddRequiredComponents()
        {
            foreach (PanelClass panel in Globals.dataBaseComponents.horizontalPanelList)
            {
                if (this.width == panel.GetWidth
                    && this.depth == panel.GetDepth && this.color == panel.GetColor)
                {
                    componentList.Add(panel);
                    panel.Quantity -= panel.QuantityNeedBox;
                }
            }
            foreach (PanelClass panel in Globals.dataBaseComponents.backPanelList)
            {
                if (this.width == panel.GetWidth
                    && this.height == panel.GetHeight && this.color == panel.GetColor)
                {
                    componentList.Add(panel);
                    panel.Quantity -= panel.QuantityNeedBox;
                }
            }
            foreach (PanelClass panel in Globals.dataBaseComponents.sidePanelList)
            {
                if (this.depth == panel.GetDepth
                       && this.height == panel.GetHeight && this.color == panel.GetColor)
                {
                    componentList.Add(panel);
                    panel.Quantity -= panel.QuantityNeedBox;
                }
            }
            foreach(Traverse traverse in Globals.dataBaseComponents.backTraverseList)
            {
                if (this.width == traverse.GetWidth)
                {
                    componentList.Add(traverse);
                    traverse.Quantity -= traverse.QuantityNeedBox;
                }
            }
            foreach (Traverse traverse in Globals.dataBaseComponents.forwardTraverseList)
            {
                if (this.width == traverse.GetWidth)
                {
                    componentList.Add(traverse);
                    traverse.Quantity -= traverse.QuantityNeedBox;
                }
            }
            foreach (Traverse traverse in Globals.dataBaseComponents.sideTraverseList)
            {
                if (this.depth == traverse.GetDepth)
                {
                    componentList.Add(traverse);
                    traverse.Quantity -= traverse.QuantityNeedBox;
                }
            }
            foreach(Bracket bracket in Globals.dataBaseComponents.bracketList)
            {
                if(this.height == bracket.GetHeight)
                {
                    componentList.Add(bracket);
                    bracket.Quantity -= bracket.QuantityNeedBox;
                }
            }
            if(this.hasDoor)
            {
                foreach(Door door in Globals.dataBaseComponents.doorList)
                {

                    if(this.height == door.GetHeight && this.width == door.GetWidth && door.GetColor == this.doorColor)
                    {
                        componentList.Add(door);
                        door.Quantity -= door.QuantityNeedBox;
                        if(this.doorColor != "Verre")
                        {
                            componentList.Add(Globals.dataBaseComponents.cupList[0]);
                            Globals.dataBaseComponents.cupList[0].Quantity -= Globals.dataBaseComponents.cupList[0].QuantityNeedBox;
                        }
                    }
                }
            }
        }
        public void UpdateRequiredComponents()
        {
            this.RemoveRequiredComponents();
            this.AddRequiredComponents();
        }
        public void RemoveRequiredComponents()
        {
            foreach(Component component in componentList)
            {
                component.Quantity += component.QuantityNeedBox;
            }
            componentList.Clear();
        }

        public void RemoveRequiredComponents_1() //when we remove a duplicaded furniture
        {
            foreach (Component component in componentList)
            {
                component.Quantity += component.QuantityNeedBox;
            }
        }
        public void DuplicationFurniture()
        {
            foreach (Component component in componentList)
            {
                component.Quantity -= component.QuantityNeedBox;
            }
        }
        public bool InStock()
        {
            foreach (Component component in componentList)
            {
                if (component.Quantity <= 0)
                    return false;
            }
            return true;
        }

        public double GetPrice()
        {
            double totalPrice = 0;
            foreach (Component component in componentList)
                totalPrice += component.GetPrice;
            return totalPrice;
        }

        public bool IsBoxCompleted()
        {
            if (color == "" | height == 0)
                return false;
            if(hasDoor)
            {
                if (doorColor == "")
                    return false;
            }
            return true;
        }

        public string GetDoorColor
        {
            get { return doorColor; }
            set { doorColor = value; }
        }

        public void AddToDB(string furnitureNumber,int boxNumber)
        {
            foreach(Component component in componentList)
            {
                component.AddToDB(furnitureNumber, boxNumber);
                Globals.componentIndex++;
            }
        }

        public static void Copy(Box sourceBox, Box destinationBox)
        {
            destinationBox.width = sourceBox.width;
            destinationBox.depth = sourceBox.depth;
            destinationBox.height = sourceBox.height;
            destinationBox.color = sourceBox.color;
            destinationBox.doorColor = sourceBox.doorColor;
            destinationBox.hasDoor = sourceBox.hasDoor;
            destinationBox.AddRequiredComponents();
        }
        public bool HasDoor
        {
            get { return hasDoor; }
            set { hasDoor = value; }
        }
        public int GetHeight
        {
            get { return this.height; }
            set { height = value; }
        }

        public string GetColor
        {
            get { return this.color; }
            set { color = value; }
        }
    }
}