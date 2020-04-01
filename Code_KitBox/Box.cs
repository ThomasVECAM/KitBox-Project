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
                        // Si il y en a suffisement en stock
                        if (panel.quantity >= 2)
                        {
                            panel.quantity -= 2;
                            this.AddComponent(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                2, panel.GetColor));
                        }
                        // Si il y en a plus du tou en stock
                        else if (panel.quantity == 0)
                        {
                            this.inStock = false;
                            this.componentToOrder.Add(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                2, panel.GetColor));
                            panel.quantity = 0;
                        }
                        // Si il y en a plus suffisement en stock
                        else
                        {
                            this.inStock = false;
                            // Si il en reste au moins un
                            if (panel.quantity > 0)
                            {
                                this.AddComponent(new PanelClass(panel.GetId, panel.GetHeight,
                                  panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                  panel.quantity, panel.GetColor));
                            }
                            this.componentToOrder.Add(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                2 - panel.quantity, panel.GetColor));
                            panel.quantity = 0;
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
                        else
                        {
                            this.inStock = false;
                            this.componentToOrder.Add(new PanelClass(panel.GetId, panel.GetHeight,
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
                        else
                        {
                            this.inStock = false;
                            if (panel.quantity > 0)
                            {
                                this.AddComponent(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                panel.quantity, panel.GetColor));
                            }
                            this.componentToOrder.Add(new PanelClass(panel.GetId, panel.GetHeight,
                                panel.GetWidth, panel.GetDepth, panel.GetPrice,
                                2 - panel.quantity, panel.GetColor));
                            panel.quantity = 0;
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
                        else
                        {
                            this.inStock = false;
                            this.componentToOrder.Add(new Traverse(traverse.GetId, traverse.GetHeight,
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
                        else
                        {
                            this.inStock = false;
                            if (traverse.quantity > 0)
                            {
                                this.AddComponent(new Traverse(traverse.GetId, traverse.GetHeight,
                                traverse.GetWidth, traverse.GetDepth, traverse.GetPrice, traverse.quantity));
                            }
                            this.componentToOrder.Add(new Traverse(traverse.GetId, traverse.GetHeight,
                                traverse.GetWidth, traverse.GetDepth, traverse.GetPrice, 2 - traverse.quantity));
                            traverse.quantity = 0;
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
                    else
                    {
                        this.inStock = false;
                        if (component.quantity > 0)
                        {
                            this.AddComponent(new Bracket(component.GetId, component.GetHeight,
                            component.GetWidth, component.GetDepth, component.GetPrice, component.quantity));
                        }
                        this.componentToOrder.Add((new Bracket(component.GetId, component.GetHeight,
                            component.GetWidth, component.GetDepth, component.GetPrice, 4 - component.quantity)));
                        component.quantity = 0;
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
                }
            }
        }

        public void UpdateRequiredComponents()
        {
            this.RemoveRequiredComponents();
            this.inStock = true;
            this.AddRequiredComponents();
        }
        public void RemoveRequiredComponents()
        {
            foreach (Component component in this.componentList)
            {
                foreach (Component stockComponent in Globals.requiredComponents.componentStock)
                {
                    if (component.GetId == stockComponent.GetId)
                        stockComponent.quantity += component.quantity;
                }
                this.componentList.Remove(component);
            }
            this.componentToOrder.Clear();
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
