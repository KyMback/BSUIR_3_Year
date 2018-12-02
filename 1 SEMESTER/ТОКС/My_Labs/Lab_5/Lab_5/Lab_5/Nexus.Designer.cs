namespace Lab_5
{
    partial class Nexus
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
            this.label1 = new System.Windows.Forms.Label();
            this.Input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.TextBox();
            this.DestinationAddress = new System.Windows.Forms.ComboBox();
            this.SourceAddress = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Debug = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input:";
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(12, 25);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(182, 20);
            this.Input.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(12, 82);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(182, 79);
            this.Output.TabIndex = 3;
            // 
            // DestinationAddress
            // 
            this.DestinationAddress.FormattingEnabled = true;
            this.DestinationAddress.Location = new System.Drawing.Point(12, 230);
            this.DestinationAddress.Name = "DestinationAddress";
            this.DestinationAddress.Size = new System.Drawing.Size(121, 21);
            this.DestinationAddress.TabIndex = 4;
            // 
            // SourceAddress
            // 
            this.SourceAddress.FormattingEnabled = true;
            this.SourceAddress.Location = new System.Drawing.Point(12, 274);
            this.SourceAddress.Name = "SourceAddress";
            this.SourceAddress.Size = new System.Drawing.Size(121, 21);
            this.SourceAddress.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Destination address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Source address:";
            // 
            // Debug
            // 
            this.Debug.Location = new System.Drawing.Point(12, 191);
            this.Debug.Name = "Debug";
            this.Debug.ReadOnly = true;
            this.Debug.Size = new System.Drawing.Size(182, 20);
            this.Debug.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Debug:";
            // 
            // Nexus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 340);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SourceAddress);
            this.Controls.Add(this.DestinationAddress);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.label1);
            this.Name = "Nexus";
            this.Text = "Nexus";
            CustomInitializeComponent();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected virtual void CustomInitializeComponent()
        {
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Output;
        protected System.Windows.Forms.ComboBox DestinationAddress;
        protected System.Windows.Forms.ComboBox SourceAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox Debug;
        private System.Windows.Forms.Label label5;
    }
}