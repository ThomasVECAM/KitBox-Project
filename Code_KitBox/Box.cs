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
            foreach (Component component in Globals.requiredComponents.componentStock)
            {
                //Ajout des panneaux
                if (component.GetId.Contains("PA"))
                {
                    PanelClass panel = (PanelClass)component;

                    //Ajout des panneaux horizontaux
                    if (panel.GetOrientation == "horizontal" && this.GetWidth == panel.GetWidth
                        && this.GetDepth == panel.GetDepth && this.GetColor == panel.GetColor)
                    {
                        if (panel.quantity >= 2)
                        {
                            panel.quantity -= 2;
                            this.AddComponent(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                2, panel.GetColor));
                        }
                    }

                    //Ajout des panneaux arrière
                    if (panel.GetOrientation == "back" && this.GetWidth == panel.GetWidth
                        && this.GetHeight == panel.GetHeight && this.GetColor == panel.GetColor)
                    {
                        if (panel.quantity >= 1)
                        {
                            panel.quantity -= 1;
                            this.AddComponent(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                1, panel.GetColor));
                        }
                    }

                    //Ajout des panneaux de cotés
                    if (panel.GetOrientation == "side" && this.GetDepth == panel.GetDepth
                        && this.GetHeight == panel.GetHeight && this.GetColor == panel.GetColor)
                    {
                        if (panel.quantity >= 2)
                        {
                            panel.quantity -= 2;
                            this.AddComponent(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                2, panel.GetColor));
                        }
                    }
                }
                //Ajout des traverse
                else if (component.GetId.Contains("TR"))
                {
                    Traverse traverse = (Traverse)component;

                    //Ajout de la traverse avant et arrière
                    if (this.GetWidth == traverse.GetWidth)
                    {
                        if (traverse.quantity >= 1)
                        {
                            traverse.quantity -= 1;
                            this.AddComponent(new Traverse(traverse.GetId, traverse.GetHeight,
                                traverse.GetWidth, traverse.GetDepth, traverse.GetPrice, 1));
                        }
                    }

                    //Ajout des traverses de cotés
                    else if (this.GetDepth == traverse.GetDepth)
                    {
                        if (traverse.quantity >= 2)
                        {
                            traverse.quantity -= 2;
                            this.AddComponent(new Traverse(traverse.GetId, traverse.GetHeight,
                                traverse.GetWidth, traverse.GetDepth, traverse.GetPrice, 2));
                        }
                    }
                }

                //Ajout des tasseaux
                else if (component.GetId.Contains("TAS") && this.GetHeight == component.GetHeight)
                {
                    if (component.quantity >= 4)
                    {
                        component.quantity -= 4;
                        this.AddComponent(new Bracket(component.GetId, component.GetHeight,
                            component.GetWidth, component.GetDepth, component.GetPrice, 4));
                    }
                }

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
                    }
                }
            }
        }

        public void UpdateRequiredComponents()
        {
            // to do
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
            destinationBox.AddRequiredComponents();
        }
    }
}
