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
                corner.quantity += 1;
        }
        public void RemoveDuplicadedFurniture()
        {
            foreach (Corner corner in cornerList)
                corner.quantity  +=1;
            foreach (Box box in boxList)
                box.RemoveRequiredComponents_1();
        }

        public void DuplicateFurniture()
        {
            foreach(Corner corner in cornerList)
                corner.quantity--;
            foreach (Box box in boxList)
                box.DuplicationFurniture();
        }

        public bool InStock()
        {
            foreach(Corner corner in cornerList)
            {
                if (corner.quantity <= 0)
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
                corner.quantity++;
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
                    cornerList.Add(corner);
                    cornerList.Add(corner);
                    cornerList.Add(corner);
                    corner.quantity -= 4;
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
    }
}
