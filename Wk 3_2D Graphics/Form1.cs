using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wk_3_2D_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Cyan);
            Pen outlinePen = new Pen(Color.Black, 2);

            Point[] points = { new Point(50,50), new Point(100,150),new Point(20,90) };

            int ufoX = 450;
            int ufoY = 200;
            int ufoWidth = 160;
            int ufoHeight = 60;
            Point[] ufoBeamPoints = 
            { 
                new Point((ufoX + ufoWidth/2) - 40, ufoY + ufoHeight + 80), 
                new Point((ufoX + ufoWidth/2) + 40, ufoY + ufoHeight + 80), 
                new Point((ufoX + ufoWidth/2), ufoY + ufoHeight + 5),
            };

            int moonX = 0;
            int moonY = 0;
            int moonSize = 300;

            #region Background
            e.Graphics.FillRegion(Brushes.DarkBlue,new Region(new Rectangle(0,0,Size.Width,Size.Height)));
            e.Graphics.FillRegion(Brushes.DarkGreen, new Region(new Rectangle(0, Size.Height - (Size.Height / 3), Size.Width, Size.Height)));
            e.Graphics.FillEllipse(Brushes.GhostWhite, moonX - moonSize/2, moonY - moonSize/2, moonSize, moonSize);
            
            #endregion

            ///Drawings for the UFO
            #region UFO
            //UFO Glass
            e.Graphics.DrawArc(outlinePen, ufoX + (ufoWidth / 2) - 40, ufoY - ufoHeight / 2 - 10, 80, 80, 0, -180);
            e.Graphics.FillEllipse(Brushes.Cyan, ufoX + (ufoWidth / 2) - 40, ufoY - ufoHeight / 2 - 10, 80, 80);
            //UFO Body
            e.Graphics.FillEllipse(Brushes.Gray, ufoX, ufoY, ufoWidth, ufoHeight);
            e.Graphics.DrawEllipse(outlinePen, ufoX, ufoY, ufoWidth, ufoHeight);
            //UFO Beam
            e.Graphics.FillPolygon(Brushes.Yellow, ufoBeamPoints);
            e.Graphics.DrawPolygon(outlinePen, ufoBeamPoints);
            
            //UFO Circles
            for (int i = 1; i <= 5; i++)
            {
                int circleSizes = 10;
                e.Graphics.FillEllipse(Brushes.Yellow, ufoX + (i * (ufoWidth / 5) - 15), ufoY + (ufoHeight / 2 - (circleSizes/2)), circleSizes, circleSizes);
                e.Graphics.DrawEllipse(outlinePen, ufoX + (i * (ufoWidth / 5) - 15), ufoY + (ufoHeight / 2 - (circleSizes/2)), circleSizes, circleSizes);
            }
            #endregion

            #region Tank: Drawings for the Tank
            RectangleF t = new RectangleF(40, 40, 20, 20);
            e.Graphics.FillRectangle(brush, t);
            #endregion


        }
    }
}
