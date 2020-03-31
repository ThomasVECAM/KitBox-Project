using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Interface_5
{
    class Box
    {
        private List<Component> componentList;
        private int width, depth, height;
        private string color, doorColor;
        private bool hasDoor;

        public Box(int width, int depth)
        {
            componentList = new List<Component>();
            this.height = 0;
            this.width = width;
            this.depth = depth;
            this.color = "";
            this.hasDoor = false;
        }

        public bool HasDoor
        {
            get { return hasDoor; }
            set { hasDoor = value; }
        }
        public int Name
        {
            get { return height; }
            set { height = value; }
        }

        public void AddRequiredComponents()
        {
            //Ajout des panneaux horizontaux
            foreach (PanelClass horizontalPanel in Globals.requiredComponents.horizontalPanelList)
            {
                if (this.GetWidth == horizontalPanel.GetWidth && this.GetDepth == horizontalPanel.GetDepth
                    && this.GetColor == horizontalPanel.GetColor)
                {
                    if (horizontalPanel.quantity >= 2)
                    {
                        horizontalPanel.quantity -= 2;
                        this.AddComponent(new PanelClass(horizontalPanel.GetId, horizontalPanel.GetHeight,
                            horizontalPanel.GetWidth, horizontalPanel.GetDepth, horizontalPanel.GetPrice,
                            2, horizontalPanel.GetColor));
                    }
                }
            }

            //Ajout du panneau arrière
            foreach (PanelClass backPanel in Globals.requiredComponents.backPanelList)
            {
                if (this.GetWidth == backPanel.GetWidth && this.GetHeight == backPanel.GetHeight
                    && this.GetColor == backPanel.GetColor)
                {
                    if (backPanel.quantity >= 1)
                    {
                        backPanel.quantity -= 1;
                        this.AddComponent(new PanelClass(backPanel.GetId, backPanel.GetHeight,
                            backPanel.GetWidth, backPanel.GetDepth, backPanel.GetPrice,
                            1, backPanel.GetColor));
                    }
                }
            }

            //Ajout des panneaux de cotés
            foreach (PanelClass sidePanel in Globals.requiredComponents.sidePanelList)
            {
                if (this.GetHeight == sidePanel.GetHeight && this.GetDepth == sidePanel.GetDepth
                    && this.GetColor == sidePanel.GetColor)
                {
                    if (sidePanel.quantity >= 1)
                    {
                        sidePanel.quantity -= 1;
                        this.AddComponent(new PanelClass(sidePanel.GetId, sidePanel.GetHeight,
                            sidePanel.GetWidth, sidePanel.GetDepth, sidePanel.GetPrice,
                            1, sidePanel.GetColor));
                    }
                }
            }

            //Ajout de la traverse avant
            foreach (Traverse forwardTraverse in Globals.requiredComponents.forwardTraverseList)
            {
                if (this.GetWidth == forwardTraverse.GetWidth)
                {
                    if (forwardTraverse.quantity >= 1)
                    {
                        forwardTraverse.quantity -= 1;
                        this.AddComponent(new Traverse(forwardTraverse.GetId, forwardTraverse.GetHeight,
                            forwardTraverse.GetWidth, forwardTraverse.GetDepth, forwardTraverse.GetPrice, 1));
                    }
                }
            }

            //Ajout de la traverse arrière
            foreach (Traverse backTraverse in Globals.requiredComponents.backTraverseList)
            {
                if (this.GetWidth == backTraverse.GetWidth)
                {
                    if (backTraverse.quantity >= 1)
                    {
                        backTraverse.quantity -= 1;
                        this.AddComponent(new Traverse(backTraverse.GetId, backTraverse.GetHeight,
                            backTraverse.GetWidth, backTraverse.GetDepth, backTraverse.GetPrice, 1));
                    }
                }
            }

            //Ajout des traverses de cotés
            foreach (Traverse sideTraverse in Globals.requiredComponents.sideTraverseList)
            {
                if (this.GetDepth == sideTraverse.GetDepth)
                {
                    if (sideTraverse.quantity >= 2)
                    {
                        sideTraverse.quantity -= 2;
                        this.AddComponent(new Traverse(sideTraverse.GetId, sideTraverse.GetHeight,
                            sideTraverse.GetWidth, sideTraverse.GetDepth, sideTraverse.GetPrice, 2));
                    }
                }
            }

            //Ajout des tasseaux
            foreach (Bracket bracket in Globals.requiredComponents.bracketList)
            {
                if (this.GetHeight == bracket.GetHeight)
                {
                    if (bracket.quantity >= 4)
                    {
                        bracket.quantity -= 4;
                        this.AddComponent(new Bracket(bracket.GetId, bracket.GetHeight,
                            bracket.GetWidth, bracket.GetDepth, bracket.GetPrice, 4));
                    }
                }
            }

            //Ajout des portes
            if (this.hasDoor)
            {
                foreach (Door door in Globals.requiredComponents.doorList)
                {
                    if (this.GetHeight == door.GetHeight && this.GetWidth == door.GetWidth
                        && this.GetDoorColor == door.GetColor)
                    {
                        if (door.quantity >= 2)
                        {
                            door.quantity -= 2;
                            this.AddComponent(new Door(door.GetId, door.GetHeight,
                                door.GetWidth, door.GetDepth, door.GetPrice,
                                2, door.GetColor));
                        }
                    }
                }
            }
        }

        public void AddComponent(Component component)
        {
            componentList.Add(component);
        }
        public void RemoveComponent(Component component)
        {
            componentList.Remove(component);
        }
        public double GetPrice()
        {
            double totalPrice = 0;
            foreach (Component component in componentList)
            {
                totalPrice += component.GetPrice;
            }
            return totalPrice;
        }
        public int GetHeight
        {
            get { return this.height; }
            set { height = value; }
        }
        public int GetDepth
        {
            get { return this.depth; }
        }
        public int GetWidth
        {
            get { return this.width; }
        }
        public string GetColor
        {
            get { return this.color; }
            set { color = value; }
        }
        public void WriteFacture(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("          Box :" + GetPrice());
            }
            /*foreach (Component component in componentList)
            {
                component.WriteFacture(path);
            }*/
        }

        public string GetDoorColor
        {
            get { return doorColor; }
            set { doorColor = value; }
        }

        // Copy a Box
        public static void Copy(Box sourceBox, Box destinationBox)
        {
            destinationBox.width = sourceBox.width;
            destinationBox.depth = sourceBox.depth;
            destinationBox.height = sourceBox.height;
            destinationBox.color = sourceBox.color;
            destinationBox.doorColor = sourceBox.doorColor;
            destinationBox.hasDoor = sourceBox.hasDoor;
        }
    }
}
