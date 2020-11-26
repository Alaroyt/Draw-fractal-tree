using System;
using System.Drawing;
using System.Windows.Forms;

namespace Draw_bin_tree
{
    class Tree
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point">корень дерева</param>
        /// <param name="angle">угол наклона</param>
        /// <param name="length">длина ствола (каждая следующая веточка = длина ствола / 1.5)</param>
        /// <param name="graphics">CreareGraphics()</param>
        /// <param name="doRandom">случайные деревья</param>
        public Tree(Point point, int angle, int length, Graphics graphics, bool doRandom)
        {
            _x = point.X;
            _y = point.Y;
            _angle = angle;
            _length = length;
            _graphics = graphics;
            _doRandom = doRandom;
        }

        int _x;
        int _y;
        int _angle;
        int _length;

        Graphics _graphics;

        private bool _doRandom;

        /// <summary>
        /// Нарисовать описанное дерево
        /// </summary>
        public void DrawTree()
        {
            if (_doRandom)
            {
                _angle = new Random().Next(0, 361);
                _length = new Random().Next(50, 201);
            }
            try
            {
                drawFractalTree(_x, _y, _angle, _length, _graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не закрывайте окно, пока все деревья не отрисуются\n" + ex.Message, "Exception");
            }
        }
        void drawFractalTree(int x, int y, int angle, int length, Graphics graphics)
        {
            Graphics g = graphics;
            int x1, y1;
            x1 = (int)(x + length * Math.Sin(angle * Math.PI * 2 / 360.0));
            y1 = (int)(y + length * Math.Cos(angle * Math.PI * 2 / 360.0));

            g.DrawLine(new Pen(Color.Black, length / 20), x, y, x1, y1);

            if (length > _length / 10)
            {
                drawFractalTree(x1, y1, angle + new Random().Next(10, 41), (int)(length / 1.5), g);
                drawFractalTree(x1, y1, angle - new Random().Next(10, 41), (int)(length / 1.5), g);
                drawFractalTree(x1, y1, angle + new Random().Next(7, 26), (int)(length / 1.5), g);
                drawFractalTree(x1, y1, angle - new Random().Next(7, 26), (int)(length / 1.5), g);
            }
        }
    }
}
