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

        Dictionary<string, Dictionary<string, string>> allBoxesDico = new Dictionary<string, Dictionary<string, string>>();
        List<Button> listButtons = new List<Button>();//list of Boxes Buttons
        List<Button> colorButtons = new List<Button>();
        List<Label> colorLabels = new List<Label>();

        string cornerColorChoosed = "";
        int i = 1;
        int remove = 2;
        int startPosition = 8;
        int endPosition = 162;
        int buttonNr = 0;
        int AddOrDupli = 0;

        public static UserControl2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl2();
                return _instance;
            }
        }

        public UserControl2()
        {
            InitializeComponent();
      
            //By default the two follow pannels are hidden.
            choicesBoxPanel.Hide();
            sideBarPanel.Hide();

            //Include the first Box Dico by default in allBoxesDico
            Dictionary<string, string> Ddefault = new Dictionary<string, string>();
            Ddefault = addBoxToDico();
            allBoxesDico.Add("Box1", Ddefault);


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
            // when click duplicate button, call the add function
            duplicateBoxButton.Click += AddBoxButton_Click;

            // when remove a button , reclick the button
            removeBoxButton.Click += Button_Click_Event;

            //Checkbox Event attribute when mouseClick
            checkBoxNo.MouseClick += DoorCheckBox_Event;
            checkBoxYes.MouseClick += DoorCheckBox_Event;
            doorsPanel.Hide(); // hide the door pannel by default

            //Integer height data in ComboBox
            MySqlConnection db = new MySqlConnection("SERVER=db4free.net;PORT=3306;DATABASE=groupe5;UID=groupe5;PWD=4c66dfc7; old guids=true");
            db.Open();
            MySqlCommand cmd2 = db.CreateCommand();
            cmd2.CommandText = "SELECT Hauteur FROM `Composants` WHERE `Ref`='Panneau GD' AND `Profondeur`=" + Globals.order.GetFurnitureList[0].GetDepth;
            //N.B. : j'aurais aussi pu faire la recherche sur le panneau arrière

            MySqlDataReader reader2 = cmd2.ExecuteReader();
            List<int> heightList = new List<int>();
            while (reader2.Read())
            {
                heightList.Add(Convert.ToInt32(reader2["Hauteur"]));
            }
            heightList = heightList.Distinct().ToList(); //enlever les objets qui ont les mêmes hauteur
            foreach (int value in heightList)
            {
                heightComboBox.Items.Add(value.ToString());
            }
            db.Close();
            AddInterfaceBox();
        }

        private void BoxColor_Event(object sender, EventArgs e)
        {
            var btnColor = (Button)sender;            
            //déselectionner tous les boutons
            for (int i = 4; i <= 5; i++)
            {
                colorButtons[i].FlatAppearance.BorderSize = 0;
            }
            btnColor.FlatAppearance.BorderSize = 5;
            Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].GetColor = btnColor.Name;
        }
        private void CornerColor_Event(object sender, EventArgs e)
        {
            var btnColor = (Button)sender;
            for (int i = 0; i <= 3; i++)
            {
                colorButtons[i].FlatAppearance.BorderSize = 0;
            }
            btnColor.FlatAppearance.BorderSize = 5;
            Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].GetCornerColor = btnColor.Name;
        }
        private void DoorCheckBox_Event(object sender, EventArgs e)
        {
            checkBoxNo.Checked = false;
            checkBoxYes.Checked = false;
            var check = (CheckBox)sender;
            check.Checked = true;
            if (check.Name == "checkBoxYes")
            {
                Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].HasDoor = true;
                doorsPanel.Show();
            }
            else if (check.Name == "checkBoxNo")
            {
                Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].HasDoor = false;
                doorsPanel.Hide();
            }
        }
        private void DoorColor_Event(object sender, EventArgs e)
        {
            var btnColor = (Button)sender;
            for (int i = 6; i <= colorButtons.Count - 1; i++)
            {
                colorButtons[i].FlatAppearance.BorderSize = 0;
            }
            btnColor.FlatAppearance.BorderSize = 5;
            Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].GetDoorColor = btnColor.Name;
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
        
        
        private void Button11_Click(object sender, EventArgs e)
        {

        }
        private void Button12_Click(object sender, EventArgs e)
        {
            if (!boxesPannel.Controls.Contains(UserControl3.Instance))
            {
                boxesPannel.Controls.Add(UserControl3.Instance);
                UserControl3.Instance.Dock = DockStyle.Fill;
                UserControl3.Instance.BringToFront();
            }
            else
                UserControl3.Instance.BringToFront();
        }
        private void AddBoxButton_Click(object sender, EventArgs e)
        {
            AddInterfaceBox();
        }

        private void AddInterfaceBox()
        {
            int boxCounter = Globals.order.GetFurnitureList[0].GetBoxListLength();
            if (boxCounter <= 7)
            {
                Globals.order.GetFurnitureList[0].AddBox(boxCounter);


                Button B = new Button();
                B = addButtonFunction(i, startPosition, endPosition);
                listButtons.Add(B);
                foreach (Button b in listButtons)
                {
                    boxesPannel.Controls.Add(b);
                }
                //Add a dictionary in the allBoxesDico for each box created 
                Dictionary<string, string> D = new Dictionary<string, string>();
                D = addBoxToDico();
                allBoxesDico.Add("Box" + (i+1).ToString(), D);


                if (AddOrDupli == 1)
                {
                    for (int j = listButtons.Count - 1; j >= buttonNr; j--)
                    {
                        allBoxesDico["Box" + (j + 1).ToString()] = allBoxesDico["Box" + (j).ToString()];
                    }
                    AddOrDupli = 0;

                    // acutalizeDimensions();
                }
                i++;
            }
            else
            {
                MessageBox.Show("You have reached the max number of boxes!");
            }
        }

        Button addButtonFunction(int i, int startPosition, int endPosition)
        {
            //Create a Button type with him caracteristics, which can be multiplicated when function is called
            Button B = new Button();
            B.FlatAppearance.BorderSize = 0;
            B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            B.ForeColor = System.Drawing.Color.White;
            B.Image = global::Interface_5.Properties.Resources.boxes;
            B.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            B.Location = new System.Drawing.Point(startPosition, (i * 50)+64);// increment the position of each new button
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

            
            // The choices box pannel and the side bar apear only when a box is selected.
            if (remove == 1)
            {
                sideBarPanel.Top = listButtons[buttonNr-1].Top;
                remove = 0;
            }
            else if (buttonNr != 0)
            {
                sideBarPanel.Show();
                sideBarPanel.Top = btnClicked.Top; //Move sideBarPanel to the clicked button
                choicesBoxPanel.Show();
            }

            heightComboBox.Text = allBoxesDico["Box" + buttonNr.ToString()]["height"];

            //Door configuration
            if (Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].HasDoor)
            {
                checkBoxYes.Checked = true;
                checkBoxNo.Checked = false;
                doorsPanel.Show();
            }
            else
            {
                checkBoxNo.Checked = true;
                checkBoxYes.Checked = false;
                doorsPanel.Hide();
            }
            //Box color
            string boxColor = Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].GetColor;
            string doorColor = Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].GetDoorColor;
            string cornerColor = Globals.order.GetFurnitureList[0].GetBoxList[buttonNr - 1].GetCornerColor; ;
            foreach (Button button in colorButtons)
            {
                if (button.Name == boxColor)
                    button.FlatAppearance.BorderSize = 5;
                else if(button.Name == cornerColor)
                    button.FlatAppearance.BorderSize = 5;

                else if(button.Name == doorColor)
                    button.FlatAppearance.BorderSize = 5;
                else
                    button.FlatAppearance.BorderSize = 0;
            }
        }
        
        private void RemoveBoxButton_Click(object sender, EventArgs e)
        {
            remove = 1;// put at 1 when passed by remove function for after can move the sideBarPanel

            if (listButtons.Count > 1)
            {
                // replacing values for each dicitionary removed by the values in the box +1  
                for (int j = buttonNr; j <= listButtons.Count - 1; j++)
                {
                    allBoxesDico["Box" + j.ToString()] = allBoxesDico["Box" + (j + 1).ToString()];
                }
                allBoxesDico.Remove("Box" + (listButtons.Count).ToString());


                // removing the button selected, from the list button and from the pannel
                boxesPannel.Controls.Remove(listButtons[buttonNr - 1]);
                listButtons.RemoveAt(buttonNr - 1);

                //rename and repositioning of each box after removing
                int count = 0;
                foreach (Button BafterRemove in listButtons)
                {
                    BafterRemove.Name = "button" + (count + 1).ToString();
                    BafterRemove.Text = "Box" + (count + 1).ToString();
                    BafterRemove.Location = new System.Drawing.Point(startPosition, (count * 50) + 112);

                    count++;
                }

                buttonNr = count;
               // acutalizeDimensions();
            }
            else
            {
                MessageBox.Show("This is the minimum boxes for a furniture!");
                i = 2;// when going in add function , we add box(i+1). This statement avoid to readd box1 in the alldicobox 
            }
            i--;
        }
        private void heightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            for (int i = 1; i <= listButtons.Count; i++)
            {
                if (buttonNr == i)
                {
                    allBoxesDico["Box" + i.ToString()]["height"] = heightComboBox.SelectedItem.ToString();
                    //Globals.box.
                }
            }
           acutalizeDimensions();
        }
      
        Dictionary<string, string> addBoxToDico()
        {
            //Create a dicttionary type which can be multipiclated for each box whith initial values
            Dictionary<string, string> D = new Dictionary<string, string>();

            D.Add("height", "");
            D.Add("boxColor", "");
            D.Add("doors", "");
            D.Add("doorsColor", "");
            return D;
        }
       
        void acutalizeDimensions()
        {
            string height = (Globals.order.GetFurnitureList[0].GetHeight()).ToString();
            string width = (Globals.order.GetFurnitureList[0].GetWidth).ToString();
            string depth = (Globals.order.GetFurnitureList[0].GetDepth).ToString();
            
            heightLabel.Text = height + "x" + width + "x" + depth;   
        }
      
        private void duplicatBoxButton_Click(object sender, EventArgs e)
        {
            AddOrDupli = 1;
        }
        private void BoxCompositionPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void whiteCornerButton1_Click(object sender, EventArgs e)
        {

        }
    }
}