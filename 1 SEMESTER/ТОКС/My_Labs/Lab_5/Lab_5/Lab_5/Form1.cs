namespace Lab_5
{
    public partial class Monitor : Nexus
    {
        public Monitor(byte address, byte previousAddress, byte nextAddress) : base(address, previousAddress,
            nextAddress)
        {

        }

        protected override void CustomInitializeComponent()
        {
            button1 = new System.Windows.Forms.Button
            {
                Location = new System.Drawing.Point(12, 305),
                Name = "button1",
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 10,
                Text = "Start",
                UseVisualStyleBackColor = true
            };
            button1.Click += button1_Click;
            this.Controls.Add(this.button1);

        }


        protected void button1_Click(object sender, System.EventArgs e)
        {
            Nexus.Data = new Package
            {
                Data = 1,
                DestinationAddress = 3,
                NextAddress = 2,
                SourceAddress = 1
            };
            //DataReceivedEvent2(Data);
        }

        private System.Windows.Forms.Button button1;
    }
}
