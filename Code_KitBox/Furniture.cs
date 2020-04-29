using System.Collections.Generic;
using System.IO;

namespace Interface_5
{
    class Furniture
    {
        private string name, cornerColor;
        private List<Box> boxList;
        private List<Corner> cornerList;
        private int depth, width;
        public int nbFurnitures;

        public Furniture(int width, int depth)
        {
            this.name = "";
            this.depth = depth;
            this.width = width;
            this.boxList = new List<Box>();
            this.cornerList = new List<Corner>();
            this.cornerColor = "";
            this.nbFurnitures = 1;
        }

        public void AddBox()
        {
            boxList.Add(new Box(width, depth));
        }
      
        public double GetUnitPrice()
        {
            double unitPrice = 0;
            foreach (Box box in boxList)
                unitPrice += box.GetPrice();
            foreach(Corner corner in cornerList)
                unitPrice += corner.GetPrice;
            return unitPrice;
        }

        public double GetPrice()
        {
            return nbFurnitures * GetUnitPrice();
        }

        public int GetHeight()
        {
            int furnitureHeight = 0;
            foreach (Box box in boxList)
            {
                furnitureHeight += box.GetHeight;
            }
            return furnitureHeight;
        }

        public void DuplicateBox(int boxNumber)
        {
            Box copy = new Box(0, 0);
            Box.Copy(boxList[boxNumber - 1], copy);
            boxList.Add(copy);
        }

        public void RemoveEntireFurniture()
        {
            for(int i=0; i < nbFurnitures -1; i++)
                RemoveDuplicadedFurniture();

            foreach(Box box in boxList)
                box.RemoveRequiredComponents();
            foreach (Corner corner in cornerList)
                corner.Quantity += corner.GetQuantityNeedBox;
        }
        public void RemoveDuplicadedFurniture()
        {
            foreach (Corner corner in cornerList)
                corner.Quantity  +=corner.GetQuantityNeedBox;
            foreach (Box box in boxList)
                box.RemoveRequiredComponents_1();
        }

        public void DuplicateFurniture()
        {
            foreach(Corner corner in cornerList)
                corner.Quantity -= corner.GetQuantityNeedBox;
            foreach (Box box in boxList)
                box.DuplicationFurniture();
        }

        public bool InStock()
        {
            foreach(Corner corner in cornerList)
            {
                if (corner.Quantity <= 0)
                    return false;
            }
            foreach(Box box in boxList)
            {
                if(box.InStock()==false)
                    return false;
            }
            return true;
        }

    public void AddRequiredCorners()
        {
            //Remove the old corners configuration
            foreach (Corner corner in cornerList)
                corner.Quantity++;
            cornerList.Clear();


            List<Corner> possibleCorner = new List<Corner>();
            int maxHeight = 10000; 
            foreach(Corner corner in Globals.dataBaseComponents.cornerList)
            {
                if (corner.GetHeight >= this.GetHeight() && corner.GetHeight <= maxHeight && corner.GetColor == cornerColor)
                {
                    possibleCorner.Add(corner);
                    maxHeight = corner.GetHeight;
                }
            }
            foreach(Corner corner in possibleCorner)
            {
                if(corner.GetHeight == maxHeight)
                {
                    cornerList.Add(corner);
                    corner.Quantity -= corner.GetQuantityNeedBox;
                }
            }
        }
        public bool IsFurnitureCompleted()
        {
            if (cornerColor == "")
                return false;
            foreach(Box box in boxList)
            {
                if (!box.IsBoxCompleted())
                    return false;
            }
            return true;
        }

        public void AddToDB(string furnitureNumber)
        {
            for(int i=0; i < nbFurnitures; i++)
            {
                furnitureNumber = furnitureNumber + (i+1).ToString();
                int boxNumber = 1;
                foreach (Box box in boxList)
                {
                    box.AddToDB(furnitureNumber, boxNumber);
                    boxNumber++;
                }
                foreach(Corner corner in cornerList)
                {
                    Globals.MySQLCommandText += "("
                        + Globals.componentIndex + ",'"
                        + corner.GetID + "',"
                        + Globals.commandId + ","
                        + boxNumber + ",'"
                        + furnitureNumber
                        + "'),";
                    Globals.componentIndex += 1;
                }
            }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int GetDepth
        {
            get { return this.depth; }
        }
        public int GetWidth
        {
            get { return this.width; }
        }
        public string CornerColor
        {
            get { return cornerColor; }
            set { cornerColor = value; }
        }
        public List<Box> GetBoxList
        {
            get { return boxList; }
        }
        public string Bill()
        {
            string billText = this.name + "            " + this.nbFurnitures + "    " + this.GetPrice() + "\n";
            billText += "    Cornière " + this.cornerColor + " " + this.cornerList[0].GetQuantityNeedBox 
                + "      " + this.cornerList[0].GetPrice + "\n";
            int i = 1;
            foreach (Box box in this.boxList)
            {
                billText += "    Box " + i + box.Bill();
                i++;
            }
            return billText;
        }
    }
}
