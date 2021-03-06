﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KitBox_Console
{
    class Furniture
    {
        private string name;
        private List<Box> boxList;
        private List<Corner> cornerList;
        private int depth, width;

        public Furniture(int width, int depth )
        {
            this.name = "";
            this.depth = depth;
            this.width = width;
            this.boxList = new List<Box>();
            this.cornerList = new List<Corner>();
        }                             

        public void AddBox(Box box)
        {
            boxList.Add(box);
        }
        public void Remove(Box box)
        {
            boxList.Remove(box);
        }
        public double GetPrice()
        {
            double totalPrice = 0;
            foreach(Box box in boxList)
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
            foreach(Box box in boxList)
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
    }
}