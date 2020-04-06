namespace Interface_5
{
    partial class UserControl4
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelFurnitureName = new System.Windows.Forms.Label();
            this.modifyButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.LabelNrOfBoxes = new System.Windows.Forms.Label();
            this.LabelFurnitureDimensions = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.furniturePrice = new System.Windows.Forms.Label();
            this.stockLabel = new System.Windows.Forms.Button();
            this.addnbButton = new System.Windows.Forms.Button();
            this.removenbButton = new System.Windows.Forms.Button();
            this.nbFurnitureLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelFurnitureName
            // 
            this.LabelFurnitureName.AutoSize = true;
            this.LabelFurnitureName.Location = new System.Drawing.Point(13, 11);
            this.LabelFurnitureName.Name = "LabelFurnitureName";
            this.LabelFurnitureName.Size = new System.Drawing.Size(208, 30);
            this.LabelFurnitureName.TabIndex = 0;
            this.LabelFurnitureName.Text = "FurnitureName1:";
            // 
            // modifyButton
            // 
            this.modifyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.modifyButton.FlatAppearance.BorderSize = 0;
            this.modifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modifyButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyButton.ForeColor = System.Drawing.Color.White;
            this.modifyButton.Location = new System.Drawing.Point(18, 95);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(135, 47);
            this.modifyButton.TabIndex = 7;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = false;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click_1);
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.removeButton.FlatAppearance.BorderSize = 0;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.ForeColor = System.Drawing.Color.White;
            this.removeButton.Location = new System.Drawing.Point(394, 95);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(130, 47);
            this.removeButton.TabIndex = 8;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // LabelNrOfBoxes
            // 
            this.LabelNrOfBoxes.AutoSize = true;
            this.LabelNrOfBoxes.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.LabelNrOfBoxes.Location = new System.Drawing.Point(14, 57);
            this.LabelNrOfBoxes.Name = "LabelNrOfBoxes";
            this.LabelNrOfBoxes.Size = new System.Drawing.Size(21, 23);
            this.LabelNrOfBoxes.TabIndex = 12;
            this.LabelNrOfBoxes.Text = "0";
            // 
            // LabelFurnitureDimensions
            // 
            this.LabelFurnitureDimensions.AutoSize = true;
            this.LabelFurnitureDimensions.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.LabelFurnitureDimensions.Location = new System.Drawing.Point(139, 57);
            this.LabelFurnitureDimensions.Name = "LabelFurnitureDimensions";
            this.LabelFurnitureDimensions.Size = new System.Drawing.Size(133, 23);
            this.LabelFurnitureDimensions.TabIndex = 13;
            this.LabelFurnitureDimensions.Text = "Dimensions : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.furniturePrice);
            this.panel2.Controls.Add(this.stockLabel);
            this.panel2.Controls.Add(this.addnbButton);
            this.panel2.Controls.Add(this.removenbButton);
            this.panel2.Controls.Add(this.nbFurnitureLabel);
            this.panel2.Controls.Add(this.LabelFurnitureDimensions);
            this.panel2.Controls.Add(this.LabelNrOfBoxes);
            this.panel2.Controls.Add(this.modifyButton);
            this.panel2.Controls.Add(this.removeButton);
            this.panel2.Controls.Add(this.LabelFurnitureName);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 157);
            this.panel2.TabIndex = 14;
            // 
            // furniturePrice
            // 
            this.furniturePrice.AutoSize = true;
            this.furniturePrice.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.furniturePrice.Location = new System.Drawing.Point(366, 57);
            this.furniturePrice.Name = "furniturePrice";
            this.furniturePrice.Size = new System.Drawing.Size(115, 23);
            this.furniturePrice.TabIndex = 36;
            this.furniturePrice.Text = "Unit Price : ";
            // 
            // stockLabel
            // 
            this.stockLabel.AccessibleDescription = "";
            this.stockLabel.BackColor = System.Drawing.Color.Lime;
            this.stockLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stockLabel.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.stockLabel.FlatAppearance.BorderSize = 0;
            this.stockLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stockLabel.ForeColor = System.Drawing.Color.White;
            this.stockLabel.Location = new System.Drawing.Point(414, 11);
            this.stockLabel.Name = "stockLabel";
            this.stockLabel.Size = new System.Drawing.Size(26, 25);
            this.stockLabel.TabIndex = 35;
            this.stockLabel.UseVisualStyleBackColor = false;
            // 
            // addnbButton
            // 
            this.addnbButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.addnbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addnbButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.addnbButton.Location = new System.Drawing.Point(477, 6);
            this.addnbButton.Name = "addnbButton";
            this.addnbButton.Size = new System.Drawing.Size(35, 35);
            this.addnbButton.TabIndex = 16;
            this.addnbButton.Text = "+";
            this.addnbButton.UseVisualStyleBackColor = false;
            this.addnbButton.Click += new System.EventHandler(this.addnbButton_Click);
            // 
            // removenbButton
            // 
            this.removenbButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.removenbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removenbButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.removenbButton.Location = new System.Drawing.Point(446, 6);
            this.removenbButton.Name = "removenbButton";
            this.removenbButton.Size = new System.Drawing.Size(35, 35);
            this.removenbButton.TabIndex = 15;
            this.removenbButton.Text = "-";
            this.removenbButton.UseVisualStyleBackColor = false;
            this.removenbButton.Click += new System.EventHandler(this.removenbButton_Click);
            // 
            // nbFurnitureLabel
            // 
            this.nbFurnitureLabel.AutoSize = true;
            this.nbFurnitureLabel.Location = new System.Drawing.Point(518, 11);
            this.nbFurnitureLabel.Name = "nbFurnitureLabel";
            this.nbFurnitureLabel.Size = new System.Drawing.Size(28, 30);
            this.nbFurnitureLabel.TabIndex = 14;
            this.nbFurnitureLabel.Text = "X";
            // 
            // UserControl4
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(70)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserControl4";
            this.Size = new System.Drawing.Size(557, 157);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelFurnitureName;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label LabelNrOfBoxes;
        private System.Windows.Forms.Label LabelFurnitureDimensions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label nbFurnitureLabel;
        private System.Windows.Forms.Button addnbButton;
        private System.Windows.Forms.Button removenbButton;
        internal System.Windows.Forms.Button stockLabel;
        private System.Windows.Forms.Label furniturePrice;
    }
}
