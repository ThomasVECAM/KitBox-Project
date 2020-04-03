using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


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
        public void Remove(Box box)
        {
            boxList.Remove(box);
        }
        public double GetPrice()
        {
            double totalPrice = 0;
            foreach (Box box in boxList)
            {
                totalPrice += box.GetPrice();
            }
            return totalPrice;
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
        public int GetHeight()
        {
            int furnitureHeight = 0;
            foreach (Box box in boxList)
            {
                furnitureHeight += box.GetHeight;
            }
            return furnitureHeight;
        }
        public void WriteFacture(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(name + " : " + GetPrice());
            }
            foreach (Box box in boxList)
            {
                box.WriteFacture(path);
            }
        }
        public int GetBoxListLength()
        {
            return boxList.Count;
        }
        public List<Box> GetBoxList
        {
            get { return boxList; }
        }
        public string GetCornerColor
        {
            get { return cornerColor; }
            set { cornerColor = value; }
        }

        public void DuplicateBox(int boxNumber)
        {
            Box copy = new Box(0, 0);
            Box.Copy(boxList[boxNumber - 1], copy);
            boxList.Add(copy);
        }

        public void RemoveBoxes()
        {
            for(int i=0; i < nbFurnitures -1; i++)
            {
                foreach (Box box in boxList)
                {
                    box.RemoveRequiredComponents_1();
                }
            }
            foreach(Box box in boxList)
            {
                box.RemoveRequiredComponents();
            }

        }
        public void RemoveBoxes_1()
        {
            foreach (Box box in boxList)
            {
                box.RemoveRequiredComponents_1();
            }
        }
        public void AddBoxes()
        {
            foreach (Box box in boxList)
            {
                box.DuplicationFurniture();
            }
        }

        public bool InStock()
        {
            foreach(Box box in boxList)
            {
                if(box.InStock()==false)
                {
                    return false;
                }
            }
            return true;
        }
        public static void Copy(Furniture sourceFurniture, Furniture destinationFurniture)
        {
            destinationFurniture.name = sourceFurniture.name;
            destinationFurniture.width = sourceFurniture.width;
            destinationFurniture.depth = sourceFurniture.depth;
            destinationFurniture.boxList = sourceFurniture.boxList;
            destinationFurniture.cornerColor = sourceFurniture.cornerColor;
        }

    }
}
