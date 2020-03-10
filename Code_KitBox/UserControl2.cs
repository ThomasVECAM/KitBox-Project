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

        List<Button> listButtons = new List<Button>();
        int i = 1;
        int startPosition = 8;
        int endPosition = 162;
        int buttonNr = 0;

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
            Button Bdefault = new Button();
            Bdefault = addButtonFunction(0, 8, 112);
            listButtons.Add(Bdefault);
            boxesPannel.Controls.Add(Bdefault);



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
                Button B = new Button();
                B = addButtonFunction(i, startPosition, endPosition);
                listButtons.Add(B);
                foreach(Button b in listButtons)
                {
                    boxesPannel.Controls.Add(b);
                }
                i++;
                sideBarPanel.Top = listButtons[listButtons.Count-1].Top;
            }
            else
            {
                MessageBox.Show("You have reached the max number of boxes!");
            }

        }

        Button addButtonFunction(int i, int startPosition,int endPosition)
        {
            Button B = new Button();
            B.FlatAppearance.BorderSize = 0;
            B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            B.ForeColor = System.Drawing.Color.White;
            B.Image = global::Interface_5.Properties.Resources.boxes;
            B.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            Console.WriteLine(i.ToString());
            B.Location = new System.Drawing.Point(startPosition, (i*50)+112);
            B.Name = "button"+(i+1).ToString();
            B.Size = new System.Drawing.Size(195, 50);
            B.TabIndex = 8;
            B.Text = "Box"+(i+1).ToString();
            B.UseVisualStyleBackColor = true;
            B.Click += new EventHandler(this.Button_Click_Event);

            return B;
        }

        void Button_Click_Event(object sender,EventArgs e)
        {
            Button btnClicked = sender as Button;
            sideBarPanel.Top = btnClicked.Top;
            string btnName = btnClicked.Text;
            string b = string.Empty;

            
            for (int i = 0; i < btnName.Length; i++)
            {
                if (Char.IsDigit(btnName[i]))
                    b += btnName[i];
            }

            if (b.Length > 0)
            {
                buttonNr = int.Parse(b);
            }

        }

        private void RemoveBoxButton_Click(object sender, EventArgs e)
        {
            

            if(listButtons.Count>1)
            {
                
                foreach(Button j in listButtons)
                {
                    Console.WriteLine(j.Text);
        

                }
                Console.WriteLine("APPREESS");
                Console.WriteLine(buttonNr.ToString());
                boxesPannel.Controls.Remove(listButtons[buttonNr-1]);
                listButtons.RemoveAt(buttonNr - 1);


                foreach (Button j in listButtons)
                {
                    Console.WriteLine(j.Text);
          

                }
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
                Console.WriteLine(count.ToString());

            }
            else
            {
                MessageBox.Show("This is the minimum boxes for a furniture!");
            }
            i--;
        }
    }
}
