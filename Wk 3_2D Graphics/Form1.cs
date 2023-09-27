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
            Font UIFont = new Font(Name, 12);
            Font TitleFont = new Font(Name, 36);

            Point[] points = { new Point(50,50), new Point(100,150),new Point(20,90) };

            int windowWidth = Width;
            int windowHeight = Height;

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


            //Button Size and Locations
            int button_width = 150;
            int button_height = 60;

            int startButton_x = 50;
            int startButton_y = (windowHeight / 2) - button_height;

            int endButton_x = 50;
            int endButton_y = (windowHeight/2) + button_height;

            //Title Size and Location
            

            int title_x = 150;
            int title_y = 80;
            int titleSize_x = 490;
            int titleSize_y = 50;

            int hexagon_x = title_x - 50;
            int hexagon_y = title_y - titleSize_y / 2;

            int hexagon2_x = title_x + titleSize_x - 50;
            int hexagon2_y = title_y - titleSize_y / 2;

            int hexagon_width = 100;
            int hexagon_height = 100;

            Point[] hexagonPoints1 =
            {
                new Point(hexagon_x+15, hexagon_y), //Top left corner - Start point
                new Point(hexagon_x+hexagon_width-15,hexagon_y), //Top right corner
                new Point(hexagon_x+hexagon_width,hexagon_y+(hexagon_height/2)), //Middle right corner
                new Point(hexagon_x+hexagon_width-15,hexagon_y+hexagon_height), //Bottom Right Corner
                new Point(hexagon_x+15, hexagon_y + hexagon_height),
                new Point(hexagon_x,hexagon_y+(hexagon_height/2))

            };
            Point[] hexagonPoints2 =
            {
                new Point(hexagon2_x+15, hexagon2_y), //Top left corner - Start point
                new Point(hexagon2_x+hexagon_width-15,hexagon2_y), //Top right corner
                new Point(hexagon2_x+hexagon_width,hexagon2_y+(hexagon_height/2)), //Middle right corner
                new Point(hexagon2_x+hexagon_width-15,hexagon2_y+hexagon_height), //Bottom Right Corner
                new Point(hexagon2_x+15, hexagon2_y + hexagon_height),
                new Point(hexagon2_x,hexagon2_y+(hexagon_height/2))

            };

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
            //RectangleF t = new RectangleF(40, 40, 20, 20);
            //e.Graphics.FillRectangle(brush, t);
            #endregion

            #region UI Buttons
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, startButton_x, startButton_y, button_width, button_height);
            e.Graphics.DrawRectangle(outlinePen, startButton_x, startButton_y, button_width, button_height);

            e.Graphics.FillRectangle(Brushes.WhiteSmoke, endButton_x, endButton_y, button_width, button_height);
            e.Graphics.DrawRectangle(outlinePen, endButton_x, endButton_y, button_width, button_height);

            string startGame = "Start Game";

            int startButtonStringLoc_x = startButton_x + (button_width/4);
            int startButtonStringLoc_y = startButton_y + (button_height/3);
            e.Graphics.DrawString(startGame, UIFont, Brushes.Black, startButtonStringLoc_x, startButtonStringLoc_y);

            string exitGame = "Exit Game";

            int exitButtonStringLoc_x = endButton_x + (button_width / 4);
            int exitButtonStringLoc_y = endButton_y + (button_height / 3);
            e.Graphics.DrawString(exitGame, UIFont, Brushes.Black, exitButtonStringLoc_x, exitButtonStringLoc_y);

            #endregion

            #region Title
            e.Graphics.FillPolygon(Brushes.Gray, hexagonPoints1);
            e.Graphics.FillPolygon(Brushes.Gray, hexagonPoints2);
            e.Graphics.FillRectangle(Brushes.SlateGray, title_x, title_y, titleSize_x, titleSize_y);
            e.Graphics.DrawString("The Alien Abductions", TitleFont, Brushes.Yellow, title_x, title_y);
            #endregion
        }
    }
}
