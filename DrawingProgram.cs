using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static Graphics graphic;

        public static void DoInitialization(Graphics newGraphic)
        {
            graphic = newGraphic;
            graphic.SmoothingMode = SmoothingMode.None;
            graphic.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        { 
            x = x0; y = y0;
        }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphic.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, Graphics graphic)
        {
            // rotationAngle пока не используется, но будет использоваться в будущем
            Drawer.DoInitialization(graphic);

            var sz = Math.Min(width, height);

            var diagonalLength = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);
            // сделать один метод используя второй параметр(угол)
            DrawSide(sz, 0);
            DrawSide(sz, -Math.PI/2); 
            DrawSide(sz, Math.PI); 
            DrawSide(sz, Math.PI/2);
        }

        static void DrawSide(double sz, double angle)
        {
            //рисуем сторону
            Drawer.MakeIt(Pens.Yellow, sz * 0.375f, angle);
            Drawer.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), angle + Math.PI / 4);
            Drawer.MakeIt(Pens.Yellow, sz * 0.375f, angle + Math.PI);
            Drawer.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, angle + Math.PI / 2);

            Drawer.Change(sz * 0.04f, angle - Math.PI);
            Drawer.Change(sz * 0.04f * Math.Sqrt(2), angle + 3 * Math.PI / 4);
        }
    }
}