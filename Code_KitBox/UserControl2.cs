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
        List<Button> listButtons = new List<Button>();
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


            heightComboBox.Items.Add("330");
            heightComboBox.Items.Add("220");
            heightComboBox.Items.Add("440");



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
                foreach(Button b in listButtons)
                {
                    boxesPannel.Controls.Add(b);

                    
                }
                //Add a dictionary in the allBoxesDico for each box created 
                Dictionary<string, string> D = new Dictionary<string, string>();
                D = addBoxToDico();
                allBoxesDico.Add("Box" + (i + 1).ToString(), D);


                i++;
                //Move sideBarPanel next the new button created
                sideBarPanel.Top = listButtons[listButtons.Count-1].Top;
            }
            else
            {
                MessageBox.Show("You have reached the max number of boxes!");
            }



        }
        
    Button addButtonFunction(int i, int startPosition,int endPosition)
        {   
            //Create a Button type with him caracteristics, which can be multiplicated when function is called
            Button B = new Button();
            B.FlatAppearance.BorderSize = 0;
            B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            B.ForeColor = System.Drawing.Color.White;
            B.Image = global::Interface_5.Properties.Resources.boxes;
            B.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            B.Location = new System.Drawing.Point(startPosition, (i*50)+112);// increment the position of each new button
            B.Name = "button"+(i+1).ToString();
            B.Size = new System.Drawing.Size(195, 50);
            B.Text = "Box"+(i+1).ToString();
            B.UseVisualStyleBackColor = true;
            B.Click += new EventHandler(this.Button_Click_Event); // this function is an eventcaled when a button is clicked  and send the button object to the Button_Click_Event function

            return B;
        }

        Dictionary<string, string> addBoxToDico()
        {
            //Create a dicttionary type which can be multipiclated for each box whith initial values
            Dictionary<string, string> D = new Dictionary<string, string>();

            D.Add("height", "");
            D.Add("boxColor", "");
            D.Add("cornerColor", "");
            D.Add("doors", "");
            D.Add("doorsColor", "");

            return D;

        }

        void Button_Click_Event(object sender,EventArgs e)
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
            Console.WriteLine(buttonNr);
         

            for (int o=1; o <= listButtons.Count - 1; o++)
            {
                Console.WriteLine("Ooo" + o.ToString());
                if (buttonNr == o)
                {
                    heightComboBox.Text = allBoxesDico["Box" + o.ToString()]["height"];
                }
                Console.WriteLine(allBoxesDico["Box" + o.ToString()]["height"]);
            }

            /*if (buttonNr == 1)
            {
                heightComboBox.Text = allBoxesDico["Box1"]["height"];
            }
            if (buttonNr == 2)
            {
                heightComboBox.Text = allBoxesDico["Box2"]["height"];
            }
            
            }*/

        }

        private void RemoveBoxButton_Click(object sender, EventArgs e)
        {
           
         /*   foreach(KeyValuePair<string, Dictionary<string, string>> k in allBoxesDico)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine("APPRES");*/

            if (listButtons.Count>1)
            {
                // replacing values for each dicitionary removed by the values in the box +1  
                for(int j = buttonNr; j<= listButtons.Count-1; j++)
                {
                    allBoxesDico["Box" + j.ToString()] = allBoxesDico["Box" + (j+1).ToString()];
                }
                allBoxesDico.Remove("Box" + (listButtons.Count).ToString());
                

             // removing the button selected, from the list button and from the pannel
                boxesPannel.Controls.Remove(listButtons[buttonNr-1]);
                listButtons.RemoveAt(buttonNr - 1);

                //rename and repositioning of each box after removing
                int count = 0;
                foreach(Button BafterRemove in listButtons)
                {
                    BafterRemove.Name = "button" +(count+1).ToString();
                    BafterRemove.Text = "Box" + (count+1).ToString();
                    BafterRemove.Location = new System.Drawing.Point(startPosition, (count*50)+112);
                   
                    count++;
                }
                sideBarPanel.Top = listButtons[listButtons.Count-1].Top;
                buttonNr = count;
                /*foreach (KeyValuePair<string, Dictionary<string, string>> k in allBoxesDico)
                {
                    Console.WriteLine(k);
                }*/

            }
            else
            {
                MessageBox.Show("This is the minimum boxes for a furniture!");
            }
            i--;
        }

       
        private void heightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= listButtons.Count - 1; i++)
            {
                if (buttonNr == i)
                {
                    allBoxesDico["Box" + i.ToString()]["height"] = heightComboBox.SelectedItem.ToString();
                }
               
            }

        }
    }
}
