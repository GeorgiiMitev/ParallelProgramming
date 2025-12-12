using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Imaging;
using System.Runtime.Intrinsics.X86;

namespace ImageDownscale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap("d:\\users\\fmi\\Desktop\\C# Parallel Programming\\AG1121.jpg"); 
            Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData data = image.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            Bitmap targetImage = new Bitmap(data.Width, data.Height); // 
            Rectangle targetRectangle = new Rectangle(0, 0, targetImage.Width, targetImage.Height);
            BitmapData targetData = targetImage.LockBits(targetRectangle, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
