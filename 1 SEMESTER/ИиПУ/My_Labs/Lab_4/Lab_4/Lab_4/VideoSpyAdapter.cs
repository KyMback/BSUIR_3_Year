using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Gma.System.MouseKeyHook;

namespace Lab_4
{
    public class VideoSpyAdapter : Form
    {
        private readonly int defaultNumberOfFrames = 25;
        private readonly string fileName = "spyCameraObject";
        private readonly int numberOfSeconds = 5;
        private readonly string extensionForImage = ".jpg";
        private readonly string extensionForVideo = ".mp4";
        private readonly int defaultCameraNumber = 1;

        public VideoSpyAdapter()
        {
            HideWindow();
            IKeyboardMouseEvents keyboardEvents = Hook.GlobalEvents();
            keyboardEvents.KeyDown += KeyDownEvent;
        }

        private void HideWindow()
        {
            base.SetVisibleCore(false);
            Visible = false;
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F7:
                {
                    var capture = new VideoCapture(defaultCameraNumber);
                    capture.QueryFrame().Bitmap.Save(fileName + extensionForImage);
                    capture.Dispose();
                    break;
                }
                case Keys.F8:
                {
                    var capture = new VideoCapture(defaultCameraNumber);

                    int width = Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameWidth));
                    int height = Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameHeight));
                    var videoWriter = new VideoWriter(fileName + extensionForVideo, defaultNumberOfFrames,
                        new Size(width, height), true);

                    var mat = new Mat();
                    int frameNumber = 0;
                    while (frameNumber < defaultNumberOfFrames * numberOfSeconds)
                    {
                        capture.Read(mat);
                        videoWriter.Write(mat);
                        frameNumber++;
                    }

                    if (videoWriter.IsOpened)
                    {
                        videoWriter.Dispose();                        
                    }
                    capture.Dispose();
                    break;
                }
            }
        }
    }
}