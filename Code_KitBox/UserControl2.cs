using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Interface_5
{
    public partial class UserControl2 : UserControl
    {
        private static UserControl2 _instance;

        List<Button> listButtons = new List<Button>();//list of Boxes Buttons
        List<Button> colorButtons = new List<Button>();
        List<Label> colorLabels = new List<Label>();

        private int i = 1;
        private int buttonNr = 1;

        public UserControl2()
        {
            InitializeComponent();
      
            //By default the two follow pannels are hidden.
            //choicesBoxPanel.Hide();
            //sideBarPanel.Hide();

            //Cornel Colors labels and buttons
            colorButtons.Add(whiteCornerButton1);
            colorButtons.Add(blackCornerButton2);
            colorButtons.Add(galvanisedCornerButton3);
            colorButtons.Add(brownCornerButton4);

            colorLabels.Add(whiteCornerLabel1);
            colorLabels.Add(blackCornerLabel2);
            colorLabels.Add(galvanisedCornerLabel3);
            colorLabels.Add(brownCornerLabel4);

            //Box Colors labels and buttons
            colorButtons.Add(whiteBoxButton5);
            colorButtons.Add(brownBoxButton6);

            colorLabels.Add(whiteBoxLabel5);
            colorLabels.Add(brownBoxLabel6);

            //Doors Colors labels and buttons
            colorButtons.Add(whiteDoorButton7);
            colorButtons.Add(brownDoorButton8);
            colorButtons.Add(glassDoorButton9);

            colorLabels.Add(whiteDoorLabel7);
            colorLabels.Add(brownDoorLabel8);
            colorLabels.Add(glassDoorLabel9);

            //Colors label hidden by default
            foreach (Label l in colorLabels)
            {
                l.Hide();
            }
            //Button event attribute when mouse enter and leave
            foreach (Button b in colorButtons)
            {
                b.MouseEnter += MouseEnter_Event;
                b.MouseLeave += MouseLeave_Event;
            }
            //Boutons event attribute when clicked ( box and doors buttons)
            for (int i = 0; i < colorButtons.Count; i++)
            {
                if (i <= 3)
                {
                    colorButtons[i].MouseClick += CornerColor_Event;
                }
                else if (i > 3 && i <= 5)
                {
                    colorButtons[i].MouseClick += BoxColor_Event;
                }
                else
                {
                    colorButtons[i].MouseClick += DoorColor_Event;
                }
            }

            //Checkbox Event attribute when mouseClick
            checkBoxNo.MouseClick += DoorCheckBox_Event;
            checkBoxYes.MouseClick += DoorCheckBox_Event;
            doorsPanel.Hide(); // hide the door pannel by default

            List<int> heightList = new List<int>();

            foreach (Component component in Globals.requiredComponents.componentStock)
            {
                if (component.GetId.Contains("PAG")
                    && component.GetDepth == Globals.order.GetFurnitureList[Globals.furnitureIndex].GetDepth)
                    heightList.Add(component.GetHeight);
            }
            
            heightList = heightList.Distinct().ToList(); //enlever les objets qui ont les mêmes hauteur
            foreach (int value in heightList)
            {
                heightComboBox.Items.Add(value.ToString());
            }

          if (Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList.Count == 0)
          {
                Globals.order.GetFurnitureList[Globals.furnitureIndex].AddBox();
                AddInterfaceBox();
          }
            else
            {
                foreach (Box box in Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList)
                {
                    furnitureName.Text = Globals.order.GetFurnitureList[Globals.furnitureIndex].Name;
                    AddInterfaceBox();
                }
            }
        }
        private void BoxColor_Event(object sender, EventArgs e)
        {
            var btnColor = (Button)sender;            
            Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].GetColor = btnColor.AccessibleDescription;
            UpdateBoxPannel();
        } 
        private void CornerColor_Event(object sender, EventArgs e)
        {
            var btnColor = (Button)sender;
            Globals.order.GetFurnitureList[Globals.furnitureIndex].GetCornerColor = btnColor.AccessibleDescription;
            UpdateBoxPannel();
        }
        private void DoorCheckBox_Event(object sender, EventArgs e)
        {
            var check = (CheckBox)sender;
            if (check.Name == "checkBoxYes")
            {
                Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].HasDoor = true;
            }
            else if (check.Name == "checkBoxNo")
            {
                Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].HasDoor = false;
            }
            UpdateBoxPannel();
        }   
        private void DoorColor_Event(object sender, EventArgs e)
        {
            var btnColor = (Button)sender;
            Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].GetDoorColor = btnColor.AccessibleDescription;
            UpdateBoxPannel();
        } 
        private void MouseEnter_Event(object sender, EventArgs e)
        {// when mouse go over button:
            var colorBtne = (Button)sender;
            int indexButton = 0;
            indexButton = colorButtons.IndexOf(colorBtne); // take index of the button in buttonlist
            colorLabels[indexButton].Show();//show label coresponding to the button index
        }
        private void MouseLeave_Event(object sender, EventArgs e)
        {// when mouse leave over the button:
            var colorBtnl = (Button)sender;
            int indexButton = 0;
            indexButton = colorButtons.IndexOf(colorBtnl); // take index of the button in buttonlist
            colorLabels[indexButton].Hide();//hide label coresponding to the button index
        }  
        private void AddBoxButton_Click(object sender, EventArgs e)
        {
            int boxCounter = Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxListLength();
            if(boxCounter <7)
            {
                Globals.order.GetFurnitureList[Globals.furnitureIndex].AddBox();
                AddInterfaceBox();
            }
            else
                MessageBox.Show("Maximum of 7 boxes reached");
        }
        private void AddInterfaceBox()
        {
            Button B = new Button();
            B = addButtonFunction(i);
            listButtons.Add(B);
            foreach (Button b in listButtons)
            {
                boxesPannel.Controls.Add(b);
            }
            i++;
            buttonNr = listButtons.Count;
            Globals.order.GetFurnitureList[Globals.furnitureIndex].Name = furnitureName.Text;
            sideBarPanel.Top = listButtons[listButtons.Count - 1].Top;
            UpdateBoxPannel();
        }
        Button addButtonFunction(int i)
        {
            //Create a Button type with him caracteristics, which can be multiplicated when function is called
            Button B = new Button();
            B.FlatAppearance.BorderSize = 0;
            B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            B.ForeColor = System.Drawing.Color.White;
            B.Image = global::Interface_5.Properties.Resources.boxes;
            B.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            B.Location = new System.Drawing.Point(8, (i * 50)+64);// increment the position of each new button
            B.Name = (i).ToString();
            B.Size = new System.Drawing.Size(195, 50);
            B.Text = "Box" + (i).ToString();
            B.UseVisualStyleBackColor = true;
            B.Click += new EventHandler(this.Button_Click_Event); 
            // this function is an eventcaled when a button is clicked  and send the button object to the Button_Click_Event function
            return B;
        }
        void Button_Click_Event(object sender, EventArgs e)
        {
            //Take the button object 
            Button btnClicked = sender as Button;

            //Get the number of the button that is clicked
            buttonNr = int.Parse(btnClicked.Name);
            sideBarPanel.Show();
            sideBarPanel.Top = btnClicked.Top; //Move sideBarPanel to the clicked button
            choicesBoxPanel.Show();
            UpdateBoxPannel();
        }
        private void UpdateBoxPannel()
        { 
            heightComboBox.Text = (Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].GetHeight).ToString();
            furnitureName.Text = Globals.order.GetFurnitureList[Globals.furnitureIndex].Name;
            Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].UpdateRequiredComponents();
            if (Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].inStock)
                stockLabel.BackColor = Color.Lime;
            else
                stockLabel.BackColor = Color.Red;
            //Door configuration
            if (Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].HasDoor)
            {
                checkBoxYes.Checked = true;
                checkBoxNo.Checked = false;
                doorsPanel.Show();
            }
            else
            {
                checkBoxYes.Checked = false;
                checkBoxNo.Checked = true;
                doorsPanel.Hide();
            }
            //Box color
            string boxColor = Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].GetColor;
            string doorColor = Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].GetDoorColor;
            string cornerColor = Globals.order.GetFurnitureList[Globals.furnitureIndex].GetCornerColor; ;
            
            for (int i = 0; i < colorButtons.Count; i++)
            {
                if (i <= 3 && colorButtons[i].AccessibleDescription == cornerColor)
                {
                    colorButtons[i].FlatAppearance.BorderSize = 5;
                }
                else if (i > 3 && i <= 5 && colorButtons[i].AccessibleDescription == boxColor)
                {
                    colorButtons[i].FlatAppearance.BorderSize = 5;
                }
                else if (i>5 && colorButtons[i].AccessibleDescription == doorColor)
                {
                    colorButtons[i].FlatAppearance.BorderSize = 5;
                }
                else
                    colorButtons[i].FlatAppearance.BorderSize = 0;
            }
        } 
        private void RemoveBoxButton_Click(object sender, EventArgs e)
        {
            int boxListLength = Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxListLength(); 
            if (boxListLength > 1)
            {
                Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].RemoveRequiredComponents();
                i = 1;
                //Enlever l'objet supprimé
                Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList.RemoveAt(buttonNr - 1);

                //Enlever tout les boutons
                boxesPannel.Controls.Clear();
                listButtons.Clear();

                //Rajouter les boutons des box qui existent encore
                foreach (Box box in Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList)
                {
                    AddInterfaceBox();
                }
                this.boxesPannel.Controls.Add(this.sideBarPanel);
                this.boxesPannel.Controls.Add(this.addBoxButton);
                if(buttonNr == boxListLength)//lorsqu'on retire le deuxième élement de la liste;
                {
                    sideBarPanel.Top = listButtons[listButtons.Count - 1].Top;//la side 
                    buttonNr--;
                }
                UpdateBoxPannel();
            }

            else
                MessageBox.Show("You need at least 1 Box");
        }
        private void heightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxList[buttonNr - 1].GetHeight =
                            Convert.ToInt32(heightComboBox.SelectedItem);
           acutalizeDimensions();
        } 
        void acutalizeDimensions()
        {
            string height = (Globals.order.GetFurnitureList[Globals.furnitureIndex].GetHeight()).ToString();
            string width = (Globals.order.GetFurnitureList[Globals.furnitureIndex].GetWidth).ToString();
            string depth = (Globals.order.GetFurnitureList[Globals.furnitureIndex].GetDepth).ToString();
            heightLabel.Text = height + "x" + width + "x" + depth;   
        }
        private void duplicatBoxButton_Click(object sender, EventArgs e)
        {
            int boxCounter = Globals.order.GetFurnitureList[Globals.furnitureIndex].GetBoxListLength();
            if (boxCounter < 7)
            {
                Globals.order.GetFurnitureList[Globals.furnitureIndex].DuplicateBox(buttonNr);
                AddInterfaceBox();
            }
            else
                MessageBox.Show("Maximum of 7 boxes reached");
        }
        private void finishFurnitureButton_Click(object sender, EventArgs e)
        {
            UserControl3 ThirdUser = new UserControl3();
            boxCompositionPanel.Controls.Clear();
            boxCompositionPanel.Controls.Add(ThirdUser);
        }
        private void furnitureName_TextChanged(object sender, EventArgs e)
        {
            Globals.order.GetFurnitureList[Globals.furnitureIndex].Name = furnitureName.Text;
        }
    }
}