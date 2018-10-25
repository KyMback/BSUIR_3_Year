namespace Lab_1
{
    partial class ComChat
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.AvailablePorts = new System.Windows.Forms.ComboBox();
            this.InputBytesLabel = new System.Windows.Forms.Label();
            this.OutputBytesLabel = new System.Windows.Forms.Label();
            this.NumberOfInputBytes = new System.Windows.Forms.Label();
            this.NumberOfOutputBytes = new System.Windows.Forms.Label();
            this.XOnXOffButton = new System.Windows.Forms.Button();
            this.Open_port_button = new System.Windows.Forms.Button();
            this.Close_port_button = new System.Windows.Forms.Button();
            this.PackageInfoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SourceAddress = new System.Windows.Forms.NumericUpDown();
            this.DestinationAddress = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SourceAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 150);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(237, 20);
            this.InputTextBox.TabIndex = 1;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.AcceptsReturn = true;
            this.OutputTextBox.Location = new System.Drawing.Point(12, 12);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputTextBox.Size = new System.Drawing.Size(237, 105);
            this.OutputTextBox.TabIndex = 3;
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Location = new System.Drawing.Point(174, 176);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // AvailablePorts
            // 
            this.AvailablePorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvailablePorts.FormattingEnabled = true;
            this.AvailablePorts.Location = new System.Drawing.Point(352, 93);
            this.AvailablePorts.Name = "AvailablePorts";
            this.AvailablePorts.Size = new System.Drawing.Size(121, 21);
            this.AvailablePorts.TabIndex = 7;
            // 
            // InputBytesLabel
            // 
            this.InputBytesLabel.AutoSize = true;
            this.InputBytesLabel.Location = new System.Drawing.Point(265, 12);
            this.InputBytesLabel.Name = "InputBytesLabel";
            this.InputBytesLabel.Size = new System.Drawing.Size(62, 13);
            this.InputBytesLabel.TabIndex = 8;
            this.InputBytesLabel.Text = "Input bytes:";
            // 
            // OutputBytesLabel
            // 
            this.OutputBytesLabel.AutoSize = true;
            this.OutputBytesLabel.Location = new System.Drawing.Point(265, 29);
            this.OutputBytesLabel.Name = "OutputBytesLabel";
            this.OutputBytesLabel.Size = new System.Drawing.Size(70, 13);
            this.OutputBytesLabel.TabIndex = 9;
            this.OutputBytesLabel.Text = "Output bytes:";
            // 
            // NumberOfInputBytes
            // 
            this.NumberOfInputBytes.AutoSize = true;
            this.NumberOfInputBytes.Location = new System.Drawing.Point(353, 9);
            this.NumberOfInputBytes.Name = "NumberOfInputBytes";
            this.NumberOfInputBytes.Size = new System.Drawing.Size(13, 13);
            this.NumberOfInputBytes.TabIndex = 10;
            this.NumberOfInputBytes.Text = "0";
            // 
            // NumberOfOutputBytes
            // 
            this.NumberOfOutputBytes.AutoSize = true;
            this.NumberOfOutputBytes.Location = new System.Drawing.Point(353, 29);
            this.NumberOfOutputBytes.Name = "NumberOfOutputBytes";
            this.NumberOfOutputBytes.Size = new System.Drawing.Size(13, 13);
            this.NumberOfOutputBytes.TabIndex = 11;
            this.NumberOfOutputBytes.Text = "0";
            // 
            // XOnXOffButton
            // 
            this.XOnXOffButton.Enabled = false;
            this.XOnXOffButton.Location = new System.Drawing.Point(267, 93);
            this.XOnXOffButton.Name = "XOnXOffButton";
            this.XOnXOffButton.Size = new System.Drawing.Size(75, 23);
            this.XOnXOffButton.TabIndex = 12;
            this.XOnXOffButton.Text = "Send XOn";
            this.XOnXOffButton.UseVisualStyleBackColor = true;
            this.XOnXOffButton.Click += new System.EventHandler(this.XOnXOffButton_Click);
            // 
            // Open_port_button
            // 
            this.Open_port_button.Location = new System.Drawing.Point(267, 46);
            this.Open_port_button.Margin = new System.Windows.Forms.Padding(2);
            this.Open_port_button.Name = "Open_port_button";
            this.Open_port_button.Size = new System.Drawing.Size(75, 24);
            this.Open_port_button.TabIndex = 13;
            this.Open_port_button.Text = "Open port";
            this.Open_port_button.UseVisualStyleBackColor = true;
            this.Open_port_button.Click += new System.EventHandler(this.Open_port_button_Click);
            // 
            // Close_port_button
            // 
            this.Close_port_button.Enabled = false;
            this.Close_port_button.Location = new System.Drawing.Point(356, 46);
            this.Close_port_button.Margin = new System.Windows.Forms.Padding(2);
            this.Close_port_button.Name = "Close_port_button";
            this.Close_port_button.Size = new System.Drawing.Size(63, 24);
            this.Close_port_button.TabIndex = 14;
            this.Close_port_button.Text = "Close port";
            this.Close_port_button.UseVisualStyleBackColor = true;
            this.Close_port_button.Click += new System.EventHandler(this.Close_port_button_Click);
            // 
            // PackageInfoTextBox
            // 
            this.PackageInfoTextBox.AcceptsReturn = true;
            this.PackageInfoTextBox.Location = new System.Drawing.Point(12, 123);
            this.PackageInfoTextBox.Name = "PackageInfoTextBox";
            this.PackageInfoTextBox.ReadOnly = true;
            this.PackageInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PackageInfoTextBox.Size = new System.Drawing.Size(237, 20);
            this.PackageInfoTextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Source address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Destination address:";
            // 
            // SourceAddress
            // 
            this.SourceAddress.Location = new System.Drawing.Point(267, 150);
            this.SourceAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SourceAddress.Name = "SourceAddress";
            this.SourceAddress.Size = new System.Drawing.Size(100, 20);
            this.SourceAddress.TabIndex = 20;
            this.SourceAddress.ValueChanged += new System.EventHandler(this.SourceAddressChanged);
            // 
            // DestinationAddress
            // 
            this.DestinationAddress.Location = new System.Drawing.Point(373, 150);
            this.DestinationAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.DestinationAddress.Name = "DestinationAddress";
            this.DestinationAddress.Size = new System.Drawing.Size(100, 20);
            this.DestinationAddress.TabIndex = 21;
            this.DestinationAddress.ValueChanged += new System.EventHandler(this.DestinationAddress_ValueChanged);
            // 
            // ComChat
            // 
            this.AcceptButton = this.SendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 209);
            this.Controls.Add(this.DestinationAddress);
            this.Controls.Add(this.SourceAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PackageInfoTextBox);
            this.Controls.Add(this.Close_port_button);
            this.Controls.Add(this.Open_port_button);
            this.Controls.Add(this.XOnXOffButton);
            this.Controls.Add(this.NumberOfOutputBytes);
            this.Controls.Add(this.NumberOfInputBytes);
            this.Controls.Add(this.OutputBytesLabel);
            this.Controls.Add(this.InputBytesLabel);
            this.Controls.Add(this.AvailablePorts);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.InputTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ComChat";
            this.Text = "ComChat";
            ((System.ComponentModel.ISupportInitialize)(this.SourceAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ComboBox AvailablePorts;
        private System.Windows.Forms.Label InputBytesLabel;
        private System.Windows.Forms.Label OutputBytesLabel;
        private System.Windows.Forms.Label NumberOfInputBytes;
        private System.Windows.Forms.Label NumberOfOutputBytes;
        private System.Windows.Forms.Button XOnXOffButton;
        private System.Windows.Forms.Button Open_port_button;
        private System.Windows.Forms.Button Close_port_button;
        private System.Windows.Forms.TextBox PackageInfoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SourceAddress;
        private System.Windows.Forms.NumericUpDown DestinationAddress;
    }
}

