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
        }

        public bool HasDoor
        {
            get { return hasDoor; }
            set { hasDoor = value; }
        }
        
        public void AddRequiredComponents()
        {
            //Ajout des panneaux
            //Horizontaux
            foreach (PanelClass panel in Globals.requiredComponents.horizontalPanelList)
            {
                if (this.width == panel.GetWidth
                    && this.depth == panel.GetDepth && this.color == panel.GetColor)
                {
                    componentList.Add(panel);
                    componentList.Add(panel);
                    panel.quantity -= 2;
                }
            }
            //Panneau arrière
            foreach (PanelClass panel in Globals.requiredComponents.backPanelList)
            {
                if (this.width == panel.GetWidth
                    && this.height == panel.GetHeight && this.color == panel.GetColor)
                {
                    componentList.Add(panel);
                    panel.quantity -= 1;
                }
            }

            foreach (PanelClass panel in Globals.requiredComponents.sidePanelList)
            {

                if (this.depth == panel.GetDepth
                       && this.height == panel.GetHeight && this.color == panel.GetColor)
                {
                    componentList.Add(panel);
                    componentList.Add(panel);
                    panel.quantity -= 2;
                }
            }

            foreach(Traverse traverse in Globals.requiredComponents.backTraverseList)
            {
                if (this.width == traverse.GetWidth)
                {
                    componentList.Add(traverse);
                    traverse.quantity -= 1;
                }
            }

            foreach (Traverse traverse in Globals.requiredComponents.forwardTraverseList)
            {
                if (this.width == traverse.GetWidth)
                {
                    componentList.Add(traverse);
                    traverse.quantity -= 1;
                }
            }

            foreach (Traverse traverse in Globals.requiredComponents.sideTraverseList)
            {
                if (this.depth == traverse.GetDepth)
                {
                    componentList.Add(traverse);
                    componentList.Add(traverse);
                    traverse.quantity -= 2;
                }
            }


            foreach(Bracket bracket in Globals.requiredComponents.bracketList)
            {
                if(this.height == bracket.GetHeight)
                {
                    componentList.Add(bracket);
                    componentList.Add(bracket);
                    componentList.Add(bracket);
                    componentList.Add(bracket);
                    bracket.quantity -= 4;
                }
            }


            /*
                //Ajout des portes
                else if (component.GetId.Contains("POR") && this.hasDoor)
                {
                    Door door= (Door)component;

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
                        else
                        {
                            this.inStock = false;
                            if (door.quantity > 0)
                            {
                                this.AddComponent(new Door(door.GetId, door.GetHeight,
                                door.GetWidth, door.GetDepth, door.GetPrice,
                                door.quantity, door.GetColor));
                            }
                            this.componentToOrder.Add(new Door(door.GetId, door.GetHeight,
                                door.GetWidth, door.GetDepth, door.GetPrice,
                                2 - door.quantity, door.GetColor));
                            door.quantity = 0;
                        }
                    }
                }*
            }*/
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
                component.quantity += 1;
            }
            componentList.Clear();
        }

        public void RemoveRequiredComponents_1()
        {
            foreach (Component component in componentList)
            {
                component.quantity += 1;
            }
        }
        public void DuplicationFurniture()
        {
            foreach (Component component in componentList)
            {
                component.quantity -= 1;
            }
        }
        public bool InStock()
        {
            foreach (Component component in componentList)
            {
                if (component.quantity <= 0)
                {
                    return false;
                }
            }
            return true;
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
            destinationBox.AddRequiredComponents();
        }
    }
}