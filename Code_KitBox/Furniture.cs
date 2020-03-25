using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Interface_5
{
    //[Serializable]

    class Furniture
    {
        private string name, cornerColor;
        private List<Box> boxList;
        private List<Corner> cornerList;
        private int depth, width;

        public Furniture(int width, int depth)
        {
            this.name = "";
            this.depth = depth;
            this.width = width;
            this.boxList = new List<Box>();
            this.cornerList = new List<Corner>();
            this.cornerColor = "";
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
            int box_height = 0;
            foreach (Box box in boxList)
            {
                box_height += box.GetHeight;
            }
            return box_height;
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
    }
}
