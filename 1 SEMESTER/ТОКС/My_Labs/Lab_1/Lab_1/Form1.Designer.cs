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
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 123);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(237, 105);
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
            this.SendButton.Location = new System.Drawing.Point(174, 234);
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
            this.AvailablePorts.Location = new System.Drawing.Point(268, 207);
            this.AvailablePorts.Name = "AvailablePorts";
            this.AvailablePorts.Size = new System.Drawing.Size(121, 21);
            this.AvailablePorts.TabIndex = 7;
            this.AvailablePorts.SelectedIndexChanged += new System.EventHandler(this.ComPorts_DropDownChanged);
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
            this.XOnXOffButton.Location = new System.Drawing.Point(268, 45);
            this.XOnXOffButton.Name = "XOnXOffButton";
            this.XOnXOffButton.Size = new System.Drawing.Size(75, 23);
            this.XOnXOffButton.TabIndex = 12;
            this.XOnXOffButton.Text = "Send XOff";
            this.XOnXOffButton.UseVisualStyleBackColor = true;
            this.XOnXOffButton.Click += new System.EventHandler(this.XOnXOffButton_Click);
            // 
            // ComChat
            // 
            this.AcceptButton = this.SendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 262);
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
    }
}

