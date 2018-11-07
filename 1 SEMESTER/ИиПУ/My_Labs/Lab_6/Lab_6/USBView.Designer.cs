namespace Lab_6
{
    partial class USBView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usbList = new System.Windows.Forms.ListView();
            this.DeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FreeSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UsedSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 8000;
            this.timer.Tick += new System.EventHandler(this.TickTimer);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-14, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // usbList
            // 
            this.usbList.CheckBoxes = true;
            this.usbList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DeviceName,
            this.FreeSpace,
            this.UsedSpace,
            this.TotalSpace});
            this.usbList.Location = new System.Drawing.Point(12, 12);
            this.usbList.Name = "usbList";
            this.usbList.Size = new System.Drawing.Size(366, 102);
            this.usbList.TabIndex = 7;
            this.usbList.UseCompatibleStateImageBehavior = false;
            this.usbList.View = System.Windows.Forms.View.Details;
            // 
            // DeviceName
            // 
            this.DeviceName.Text = "Name Device";
            this.DeviceName.Width = 111;
            // 
            // FreeSpace
            // 
            this.FreeSpace.Text = "Free Space";
            this.FreeSpace.Width = 80;
            // 
            // UsedSpace
            // 
            this.UsedSpace.Text = "Used Space";
            this.UsedSpace.Width = 80;
            // 
            // TotalSpace
            // 
            this.TotalSpace.Text = "Total Space";
            this.TotalSpace.Width = 91;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 119);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Eject All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExecuteDevice);
            // 
            // USBView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usbList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(399, 188);
            this.MinimumSize = new System.Drawing.Size(399, 188);
            this.Name = "USBView";
            this.Text = "USB Manager";
            this.Load += new System.EventHandler(this.LoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView usbList;
        private System.Windows.Forms.ColumnHeader DeviceName;
        private System.Windows.Forms.ColumnHeader FreeSpace;
        private System.Windows.Forms.ColumnHeader UsedSpace;
        private System.Windows.Forms.ColumnHeader TotalSpace;
        private System.Windows.Forms.Button button1;
    }
}

