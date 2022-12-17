using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KarbonHoldingRudovich
{
    class Rendering
    {
        private static Bitmap _bmp;
        private static Graphics _graph;

        //отрисовка линиями
        public void Render(Points point1, Points point2, Color color)
        {
            _graph.DrawLine(new Pen(color, 2), (float)point1.X, (float)point1.Y, (float)point2.X, (float)point2.Y);
        }
        public void Gener(PictureBox pictureBox)
        {
            _bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            _graph = Graphics.FromImage(_bmp);
            _graph.SmoothingMode = SmoothingMode.AntiAlias;
            _graph.Clear(Color.Black);
            _graph.TranslateTransform(pictureBox.Width / 2, pictureBox.Height / 2);
            _graph.ScaleTransform(1, -1);
            pictureBox.Image = _bmp;
        }
    }
}
