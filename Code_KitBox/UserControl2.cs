using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_5
{
    public partial class UserControl2 : UserControl
    {
        private static UserControl2 _instance;

        Dictionary<string, Dictionary<string, string>> allBoxesDico = new Dictionary<string, Dictionary<string, string>>();
        List<Button> listButtons = new List<Button>();//list of Boxes Buttons
        List<Button> colorButtons = new List<Button>();
        List<Label> colorLabels = new List<Label>();
        int i = 1;
        int startPosition = 8;
        int endPosition = 162;
        int buttonNr = 0;
        string height = "";

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
            
            //Create the first Box Button by default 
            Button Bdefault = new Button();
            Bdefault = addButtonFunction(0, 8, 112);
            listButtons.Add(Bdefault);
            boxesPannel.Controls.Add(Bdefault);

            //By default the two follow pannels are hidden.
            choicesBoxPanel.Hide();
            sideBarPanel.Hide();

            //Include the first Box Dico by default in allBoxesDico
            Dictionary<string, string> Ddefault = new Dictionary<string, string>();
            Ddefault = addBoxToDico();
            allBoxesDico.Add("Box1", Ddefault);


            //Box Colors labels and buttons
            colorButtons.Add(whiteBoxButton1);
            colorButtons.Add(brownBoxButton2);

            colorLabels.Add(whiteBoxLabel1);
            colorLabels.Add(brownBoxLabel2);
            //Cornel Colors labels and buttons
            colorButtons.Add(whiteCornerButton3);
            colorButtons.Add(blackCornerButton4);
            colorButtons.Add(galvanisedCornerButton5);
            colorButtons.Add(brownCornerButton6);

            colorLabels.Add(whiteCornerLabel3);
            colorLabels.Add(blackCornerLabel4);
            colorLabels.Add(galvanisedCornerLabel5);
            colorLabels.Add(brownCornerLabel6);
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
            foreach(Button b in colorButtons)
            {
                b.MouseEnter += MouseEnter_Event;
                b.MouseLeave += MouseLeave_Event;
            }
            //Boutons event attribute when clicked
            for(int i =0; i < colorButtons.Count; i++)
            {
                if (i <=1)
                {
                    colorButtons[i].MouseClick += BoxColor_Event;
                }
                else if (i>1 && i<=5)
                {
                    colorButtons[i].MouseClick += CornerColor_Event;
                }
                else if (i > 5)
                {
                    colorButtons[i].MouseClick += DoorColor_Event;
                }

            }
            //Checkbox 
            checkBoxYes.Checked = false;
            checkBoxNo.Checked = false;
            doorsPanel.Hide(); // hide the door pannel by default

            //Integer height data in ComboBox
            heightComboBox.Items.Add("330");
            heightComboBox.Items.Add("220");
            heightComboBox.Items.Add("440");


        }
        
        private  void BoxColor_Event(object sender, EventArgs e)
        {
           
            // take the buttons in the list coresponding to boxColor cliked buttons and create a BorderSize 
            for(int i = 0; i <= 1; i++)
            {
                colorButtons[i].FlatAppearance.BorderSize = 0;
            }
            var btnColor = (Button)sender;
            btnColor.FlatAppearance.BorderSize = 5;

            for (int j = 1; j <= listButtons.Count; j++)
            {
                if (buttonNr == j)
                {
                    allBoxesDico["Box" + j.ToString()]["boxColor"] = colorButtons.IndexOf(btnColor).ToString();
                 
                }

            }
            

        }
        private void CornerColor_Event(object sender, EventArgs e)
        {
            // take the buttons in the list coresponding to CornerColor cliked buttons and create a BorderSize 
            for (int i = 2; i <=5; i++)
            {
                colorButtons[i].FlatAppearance.BorderSize = 0;
            }
            var btnColor = (Button)sender;
            btnColor.FlatAppearance.BorderSize = 5;

            for (int j = 1; j <= listButtons.Count; j++)
            {
             
                if (buttonNr == j)
                {
                    allBoxesDico["Box" + j.ToString()]["cornerColor"] = colorButtons.IndexOf(btnColor).ToString();
 
                }

            }

        }
       

        private void CheckBoxYes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxYes.Checked == true)
            {
                checkBoxYes.Checked = false;
            }
     

            doorsPanel.Show();
            for (int j = 1; j <= listButtons.Count; j++)
            {
                if (buttonNr == j)
                {
                    allBoxesDico["Box" + j.ToString()]["doors"] = checkBoxYes.Checked.ToString();
                }
                Console.WriteLine("Box" + j.ToString());
                Console.WriteLine(allBoxesDico["Box" + j.ToString()]["doors"]);
            }
        }

        private void CheckBoxNo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNo.Checked == true)
            {
                checkBoxNo.Checked = false;
            }
         
            doorsPanel.Hide();
                for (int j = 1; j <= listButtons.Count; j++)
                {
                    if (buttonNr == j)
                    {
                        allBoxesDico["Box" + j.ToString()]["doors"] = checkBoxNo.Checked.ToString();
                    }
                Console.WriteLine("Box" + j.ToString());
                Console.WriteLine(allBoxesDico["Box" + j.ToString()]["doors"]);

            }
          }
        private void DoorColor_Event(object sender, EventArgs e)
        {
            // take the buttons in the list coresponding to DoorColor cliked buttons and create a BorderSize 
            for (int i = 6; i <= 8; i++)
            {
                colorButtons[i].FlatAppearance.BorderSize = 0;
            }
            var btnColor = (Button)sender;
            btnColor.FlatAppearance.BorderSize = 5;

            for (int j = 1; j <= listButtons.Count; j++)
            {
                if (buttonNr == j)
                {
                    allBoxesDico["Box" + j.ToString()]["doorsColor"] = colorButtons.IndexOf(btnColor).ToString();
                }

            }
        }
        private void MouseEnter_Event(object sender, EventArgs e)
        {// when mouse go over button:
            var colorBtne = (Button)sender;
            int indexButton=0;
            indexButton = colorButtons.IndexOf(colorBtne); // take index of the button in buttonlist
            colorLabels[indexButton].Show();//show label coresponding to the button index
            
            
        }
        private void MouseLeave_Event(object sender, EventArgs e)
        {// when mouse leave over the button:
            var colorBtnl = (Button)sender;
            int indexButton = 0;
            indexButton = colorButtons.IndexOf(colorBtnl); // take index of the button in buttonlist
            colorLabels[indexButton ].Hide();//hide label coresponding to the button index


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
            if (i <= 6)
            {
                //Create a button for each click on "Add"
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
                allBoxesDico.Add("Box" + (i + 1).ToString(), D);

                i++;
                //Move sideBarPanel next the new button created
                sideBarPanel.Top = listButtons[listButtons.Count - 1].Top;
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
            B.Location = new System.Drawing.Point(startPosition, (i * 50) + 112);// increment the position of each new button
            B.Name = "button" + (i + 1).ToString();
            B.Size = new System.Drawing.Size(195, 50);
            B.Text = "Box" + (i + 1).ToString();
            B.UseVisualStyleBackColor = true;
            B.Click += new EventHandler(this.Button_Click_Event); // this function is an eventcaled when a button is clicked  and send the button object to the Button_Click_Event function

            return B;
        }

     

        void Button_Click_Event(object sender, EventArgs e)
        {

      
            //Take the button object 
            Button btnClicked = sender as Button;
            string btnName = btnClicked.Text;
            string b = string.Empty;

            //This manipulation take the number of the box in the name of the box
            for (int i = 0; i < btnName.Length; i++)
            {
                if (Char.IsDigit(btnName[i]))
                    b += btnName[i];
            }

            if (b.Length > 0)
            {
                buttonNr = int.Parse(b);
            }


            // The choices box pannel and the side bar apear only when a box is selected.
            if (buttonNr != 0)
            {
                sideBarPanel.Show();
                sideBarPanel.Top = btnClicked.Top;
                choicesBoxPanel.Show();
            }

            int indexB = 0;
            int indexC = 0;
            int indexD = 0;

            for (int m = 1; m <= listButtons.Count; m++)
            {
                /*Console.WriteLine("Box" + m.ToString());
                Console.WriteLine(allBoxesDico["Box" + m.ToString()]["cornerColor"]);
                Console.WriteLine(allBoxesDico["Box" + m.ToString()]["boxColor"]);*/


                if (allBoxesDico["Box" + m.ToString()]["cornerColor"] == "")
                {
                    
                }
                else
                {
                    indexC= int.Parse(allBoxesDico["Box" + m.ToString()]["cornerColor"]);

                }
                if (allBoxesDico["Box" + m.ToString()]["boxColor"] == "")
                {

                }
                else
                {
                    indexB = int.Parse(allBoxesDico["Box" + m.ToString()]["boxColor"]);

                }
                if (allBoxesDico["Box" + m.ToString()]["doorsColor"] == "")
                {

                }
                else
                {
                    indexD = int.Parse(allBoxesDico["Box" + m.ToString()]["doorsColor"]);

                }

                

                if (buttonNr == m)
                {
                    heightComboBox.Text = allBoxesDico["Box" + m.ToString()]["height"];

                    if(allBoxesDico["Box" + m.ToString()]["doors"] == "")
                    {

                    }
                    else
                    {
                        if (allBoxesDico["Box" + m.ToString()]["doors"] == "True")
                        {

                            doorsPanel.Show();
                            checkBoxYes.Checked = true;
                            checkBoxNo.Checked = false;

                        }
                        else
                        {
                            doorsPanel.Hide();
                            checkBoxYes.Checked = false;
                            checkBoxNo.Checked = true;
                        }
                    }
                    

                    for (int u = 0; u <= 1; u++)
                    {
                        if (u != indexB)
                        {
                            colorButtons[u].FlatAppearance.BorderSize = 0;
                        }
                    }
                    for (int u = 2; u <= 5; u++)
                    {
                        if (u != indexC)
                        {
                            colorButtons[u].FlatAppearance.BorderSize = 0;
                        }
                    }
                    for (int u = 6; u <= 8; u++)
                    {
                        if (u != indexD)
                        {
                            colorButtons[u].FlatAppearance.BorderSize = 0;
                        }
                    }
                    colorButtons[indexC].FlatAppearance.BorderSize = 5;
                    colorButtons[indexB].FlatAppearance.BorderSize = 5;
                    colorButtons[indexD].FlatAppearance.BorderSize = 5;
                }
               
               
                
            }


       

        }

        private void RemoveBoxButton_Click(object sender, EventArgs e)
        {

    

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
                sideBarPanel.Top = listButtons[listButtons.Count - 1].Top;
                buttonNr = count;
          

            }
            else
            {
                MessageBox.Show("This is the minimum boxes for a furniture!");
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
                }
            }

        }
        Dictionary<string, string> addBoxToDico()
        {
            //Create a dicttionary type which can be multipiclated for each box whith initial values
            Dictionary<string, string> D = new Dictionary<string, string>();

            D.Add("height", "");
            D.Add("boxColor", "");
            D.Add("cornerColor","");
            D.Add("doors", "");
            D.Add("doorsColor", "");

            return D;

        }

        
    }
}

