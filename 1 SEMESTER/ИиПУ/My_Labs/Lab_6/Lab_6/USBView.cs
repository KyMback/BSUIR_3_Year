using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab_6
{
    public partial class USBView : Form
    {
        private const int DEVICE_CHANGE = 0X219;
        private static readonly Manager _manager = new Manager();
        private List<Usb> _deviceList;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == DEVICE_CHANGE)
            {
                ReloadForm();
            }
        }

        public USBView()
        {
            InitializeComponent();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            _deviceList = new List<Usb>();
            ReloadForm();         
            timer.Enabled = true;
        }
        private void ReloadForm()
        {
            _deviceList = _manager.GetUsbs();
            usbList.Items.Clear();

            foreach (var device in _deviceList)
            {
                var deviceInfo = new ListViewItem(device.DeviceName);
                deviceInfo.SubItems.AddRange(new[]
                {
                    device.FreeSpace,
                    device.UsedSpace,
                    device.TotalSpace
                });
                usbList.Items.Add(deviceInfo);
            }           
        }

        private void TickTimer(object sender, EventArgs e)
        {
            ReloadForm();
        }

        private void ExecuteDevice(object sender, EventArgs e)
        {
            if (usbList.Items.Count > 0)
            {
                var items = usbList.CheckedItems;

                foreach (object item in items)
                {
                    bool? isEject = _deviceList
                        .FirstOrDefault(x => x.DeviceName.Contains((item as ListViewItem)?.Text ?? string.Empty))
                        ?.EjectDevice();
                    if (!isEject ?? false)
                        MessageBox.Show("Cant eject all devices", "OOPs", MessageBoxButtons.OK);
                }
            }
            ReloadForm();
        }
    }
}
