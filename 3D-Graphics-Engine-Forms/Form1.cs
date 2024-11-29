using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections;
using System.Threading;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;

namespace _3D_Graphics_Engine_Forms
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        float cameraX = -10;
        float cameraY = -10;
        float cameraZ = 10;

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool eDown = false;
        bool qDown = false;

        List<Matrix<double>> vectorsInitial = new List<Matrix<double>>(new Matrix<double>[] {
            DenseMatrix.OfArray(new double[,] { { 0.5 },{ 0.5 },{ 0 } } ),
            DenseMatrix.OfArray(new double[,] { { 0.5 },{ -0.5 },{ 0 } } ),
            DenseMatrix.OfArray(new double[,] { { -0.5 },{ 0.5 },{ 0 } } ),
            DenseMatrix.OfArray(new double[,] { { -0.5 },{ -0.5 },{ 0 } } ),
            DenseMatrix.OfArray(new double[,] { { 0.5 },{ 0.5 },{ 1 } } ),
            DenseMatrix.OfArray(new double[,] { { 0.5 },{ -0.5 },{ 1 } } ),
            DenseMatrix.OfArray(new double[,] { { -0.5 },{ 0.5 },{ 1 } } ),
            DenseMatrix.OfArray(new double[,] { { -0.5 },{ -0.5 },{ 1 } } )
        });

        List<Matrix<double>> basisVectors = new List<Matrix<double>>(new Matrix<double>[] {
            DenseMatrix.OfArray(new double[,] { {1}, {0}, {0} }),
            DenseMatrix.OfArray(new double[,] { {0}, {1}, {0} }),
            DenseMatrix.OfArray(new double[,] { {0}, {0}, {1} }),
            DenseMatrix.OfArray(new double[,] { {0}, {0}, {0} })
        });

        float a = (float)(3 * Math.PI/4);
        float b = (float)Math.PI * 3/4;

        public Form1()
        {
            InitializeComponent();
            LockMouse();
            Cursor.Hide();
            this.DoubleBuffered = true;
            timer.Enabled = true;
            timer.Interval = 9;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(Color.White);
            Brush brushRed = new SolidBrush(Color.Red);
            Brush brushGreen = new SolidBrush(Color.Green);
            Brush brushBlue = new SolidBrush(Color.Blue);
            Brush brushBeige = new SolidBrush(Color.Tan);
            Pen redPen = new Pen(Color.Red, 3);
            Pen bluePen = new Pen(Color.Blue, 3);
            Pen greenPen = new Pen(Color.Green, 1);
            Pen beigePen = new Pen(Color.Tan, 2);
            List<Matrix<double>> vectorsFinal = new List<Matrix<double>>();
            List<Matrix<double>> vectorsOffset = new List<Matrix<double>>();
            List<Matrix<double>> vectorsProjected = new List<Matrix<double>>();

            List<Matrix<double>> basisFinal = new List<Matrix<double>>();
            List<Matrix<double>> basisOffset = new List<Matrix<double>>();
            List<Matrix<double>> basisProjected = new List<Matrix<double>>();

            basisFinal.Clear();
            basisOffset.Clear();
            basisProjected.Clear();

            vectorsFinal.Clear();
            vectorsOffset.Clear();
            vectorsProjected.Clear();
            //b += 0.02f;

            Matrix<double> matrix = Calculations.CalculateProjectionMatrix((float)Math.PI * 1 / 2, (float)Math.PI * 1 / 2);

            /*
            for (int i = 0; i < vectorsInitial.Count; i++)
            {
                vectorsOffset.Add(DenseMatrix.OfArray(new double[,]
                {
                    { vectorsInitial[i][0,0] - cameraX},
                    { vectorsInitial[i][1,0] - cameraY},
                    { vectorsInitial[i][2,0] - cameraZ},
                }));
            }

            for (int i = 0; i < vectorsOffset.Count; i++)
            {
                vectorsProjected.Add(matrix * vectorsOffset[i]);
            }

            for (int i = 0; i < vectorsProjected.Count; i++)
            {
                vectorsFinal.Add(Calculations.DistortPerspective(cameraX, cameraY, cameraZ, vectorsOffset[i], vectorsProjected[i]));
            }
            */


            //b = System.Windows.Forms.Cursor.Position.X * -0.001f;
            //a = System.Windows.Forms.Cursor.Position.Y * 0.001f;

            Matrix<double> newVec = DenseMatrix.OfArray(new double[,]
            {
                { 1*Math.Cos(b) },
                { 0*Math.Sin(b) },
                { 0*Math.Sin(b) }
            });

            Matrix<double> stableVec = DenseMatrix.OfArray(new double[,]
            {
                { 0 },
                { 0 },
                { 0 }
            });

            newVec = matrix * newVec;

            /*
            for(int i = 0; i < basisVectors.Count; i++)
            {
                float euclidDist = (float)Math.Sqrt(Math.Pow(basisVectors[i][0, 0] - cameraX, 2) + Math.Pow(basisVectors[i][1, 0] - cameraY, 2) + Math.Pow(basisVectors[i][2, 0] - cameraZ, 2));

                basisOffset.Add(DenseMatrix.OfArray(new double[,]
                {
                    { euclidDist * Math.Cos(b) + basisVectors[i][0,0]},
                    { euclidDist * Math.Sin(b) + basisVectors[i][1,0]},
                    { 1}
                }));
            }
            */

            basisVectors[0] = DenseMatrix.OfArray(new double[,]
            {
                {1*Math.Sin(b) },
                {1*Math.Cos(a) },
                {1*Math.Sin(a) }
            });

            //basisVectors[1] = DenseMatrix.OfArray(new double[,]
            //{
            //               {1*Math.Cos(b) },
            //              {0 },
            //             {0 }
            //});

            Matrix<double> newVecTemp = DenseMatrix.OfArray(new double[,]
            {
                { 1*Math.Cos(b) },
                { 0*Math.Sin(b) },
                { 0*Math.Sin(b) }
            });

            for (int i = 0; i < basisOffset.Count; i++)
            {
                basisProjected.Add(matrix * basisOffset[i]);
            }

            //Console.WriteLine(basisProjected.Count);

            for (int i = 0; i < basisProjected.Count; i++)
            {
                basisFinal.Add(basisProjected[i]);
                //basisFinal.Add(Calculations.DistortPerspective(cameraX, cameraY, cameraZ, basisOffset[i], basisProjected[i]));
            }

            Brush tempBrush;

            if (Calculations.DotProduct(Calculations.GetVOrtho(a, b), newVecTemp) > 0)
                tempBrush = brush;
            else tempBrush = brushRed;

            Matrix<double> globalXBase = DenseMatrix.OfArray(new double[,]
            {
                { 1 },
                { 0 },
                { 0 }
            });

            Matrix<double> globalYBase = DenseMatrix.OfArray(new double[,]
            {
                { 0 },
                { 1 },
                { 0 }
            });

            Matrix<double> globalZBase = DenseMatrix.OfArray(new double[,]
            {
                { 0 },
                { 0 },
                { 1 }
            });

            Matrix<double> globalOriginBase = DenseMatrix.OfArray(new double[,]
            {
                { 0 },
                { 0 },
                { 0 }
            });


            Matrix<double> cameraPos = DenseMatrix.OfArray(new double[,] { { cameraX }, { cameraY }, { cameraZ } });
            Matrix<double> vOrtho = Calculations.GetVOrtho(a, b);

            Matrix<double> localXBase = Calculations.GetB(a, b).Inverse() * (globalXBase - (cameraPos + vOrtho));
            Matrix<double> localYBase = Calculations.GetB(a, b).Inverse() * (globalYBase - (cameraPos + vOrtho));
            Matrix<double> localZBase = Calculations.GetB(a, b).Inverse() * (globalZBase - (cameraPos + vOrtho));
            Matrix<double> localOriginBase = Calculations.GetB(a, b).Inverse() * (globalOriginBase - (cameraPos + vOrtho));

            bool drawX;
            bool drawY;
            bool drawZ;

            if (Calculations.DotProduct(localXBase, globalYBase) > 0)
                drawX = true;
            else
                drawX = false;

            if (Calculations.DotProduct(localYBase, globalYBase) > 0)
                drawY = true;
            else
                drawY = false;

            if (Calculations.DotProduct(localZBase, globalYBase) > 0)
                drawZ = true;
            else
                drawZ = false;
            //Thread.Sleep(10000000);

            Matrix<double> distortedX = Calculations.DistortPerspective(0, 0, 0, localXBase, perspectiveMod);
            Matrix<double> distortedY = Calculations.DistortPerspective(0, 0, 0, localYBase, perspectiveMod);
            Matrix<double> distortedZ = Calculations.DistortPerspective(0, 0, 0, localZBase, perspectiveMod);

            if (drawX)
                g.FillRectangle(brushRed, (float)Math.Round(100 * ((float)distortedX[0, 0]) + 1084/2), -(float)Math.Round(100 * ((float)distortedX[1, 0]) - 704/2), 4, 4);
            if (drawY)
                g.FillRectangle(brushGreen, (float)Math.Round(100 * ((float)distortedY[0, 0]) + 1084/2), -(float)Math.Round(100 * ((float)distortedY[1, 0]) - 704/2), 4, 4);
            if (drawZ)
                g.FillRectangle(brushBlue, (float)Math.Round(100 * ((float)distortedZ[0, 0]) + 1084 / 2), -(float)Math.Round(100 * ((float)distortedZ[1, 0]) - 704 / 2), 4, 4);

            //g.FillRectangle(brush, (float)Math.Round((double)100 * ((float)localOriginBase[0, 0] + 8)), -(float)Math.Round((double)100 * ((float)localOriginBase[2, 0] - 5)), 4, 4);
            drawFloor();

            void drawFloor()
            {
                List<Matrix<double>> xPointsA = new List<Matrix<double>>();
                for (int i = -10; i <= 10; i++)
                {
                    xPointsA.Add(DenseMatrix.OfArray(new double[,] { { i }, { -10 }, { 0 } }));
                    xPointsA[i + 10] = Calculations.GetB(a, b).Inverse() * (xPointsA[i + 10] - (cameraPos + vOrtho));
                    xPointsA[i + 10] = Calculations.DistortPerspective(0, 0, 0, xPointsA[i + 10], perspectiveMod);
                }

                List<Matrix<double>> xPointsB = new List<Matrix<double>>();
                for (int i = -10; i <= 10; i++)
                {
                    xPointsB.Add(DenseMatrix.OfArray(new double[,] { { i }, { 10 }, { 0 } }));
                    xPointsB[i + 10] = Calculations.GetB(a, b).Inverse() * (xPointsB[i + 10] - (cameraPos + vOrtho));
                    xPointsB[i + 10] = Calculations.DistortPerspective(0, 0, 0, xPointsB[i + 10], perspectiveMod);
                }

                for (int i = 0; i <= 20; i++)
                {
                    g.DrawLine(beigePen, (float)Math.Round(100 * (xPointsA[i][0, 0]) + 1084/2), -(float)Math.Round(100 * (xPointsA[i][1, 0]) - 704/2),
                        (float)Math.Round(100 * (xPointsB[i][0, 0]) + 1084/2), -(float)Math.Round(100 * (xPointsB[i][1, 0]) - 704/2));
                }

                List<Matrix<double>> yPointsA = new List<Matrix<double>>();
                for (int i = -10; i <= 10; i++)
                {
                    yPointsA.Add(DenseMatrix.OfArray(new double[,] { { -10 }, { i }, { 0 } }));
                    yPointsA[i + 10] = Calculations.GetB(a, b).Inverse() * (yPointsA[i + 10] - (cameraPos + vOrtho));
                    yPointsA[i + 10] = Calculations.DistortPerspective(0, 0, 0, yPointsA[i + 10], perspectiveMod);
                }

                List<Matrix<double>> yPointsB = new List<Matrix<double>>();
                for (int i = -10; i <= 10; i++)
                {
                    yPointsB.Add(DenseMatrix.OfArray(new double[,] { { 10 }, { i }, { 0 } }));
                    yPointsB[i + 10] = Calculations.GetB(a, b).Inverse() * (yPointsB[i + 10] - (cameraPos + vOrtho));
                    yPointsB[i + 10] = Calculations.DistortPerspective(0, 0, 0, yPointsB[i + 10], perspectiveMod);
                }

                for (int i = 0; i <= 20; i++)
                {
                    g.DrawLine(beigePen, (float)Math.Round(100 * (yPointsA[i][0, 0]) + 1084 / 2), -(float)Math.Round(100 * (yPointsA[i][1, 0]) - 704/2),
                        (float)Math.Round(100 * (yPointsB[i][0, 0]) + 1084 / 2), -(float)Math.Round(100 * (yPointsB[i][1, 0]) - 704/2));
                }

                if (aDown) { cameraX -= 0.1f * (float)Math.Cos(b - Math.PI / 2); cameraY -= 0.1f * (float)Math.Sin(b - Math.PI / 2); }
                if (dDown) { cameraX += 0.1f * (float)Math.Cos(b - Math.PI / 2); cameraY += 0.1f * (float)Math.Sin(b - Math.PI / 2); }
                if (wDown) { cameraX += 0.1f * (float)Math.Cos(b); cameraY += 0.1f * (float)Math.Sin(b); }
                if (sDown) { cameraX -= 0.1f * (float)Math.Cos(b); cameraY -= 0.1f * (float)Math.Sin(b); }
                if (eDown) { cameraZ += 0.1f; }
                if (qDown) { cameraZ -= 0.1f; }


                //if ()
                //   cameraX += 0.2f * (float)Math.Cos(b); cameraY += 0.2f * (float)Math.Sin(b);


                /*
                Console.WriteLine("move?");
                string readConsole = Console.ReadLine();

                if (readConsole == "W")
                    cameraY++;
                else if (readConsole == "A")
                    cameraX--;
                else if (readConsole == "D")
                    cameraX++;
                else if (readConsole == "S")
                    cameraY--;
                */
                //g.FillRectangle(tempBrush, (float)(100 * (basis[0, 0] + 5)), -(float)(100 * (newVec[1, 0] - 3)), 2, 2);
                //g.FillRectangle(brush, (float)(100 * (stableVec[0, 0] + 5)), -(float)(100 * (stableVec[1, 0] - 3)), 2, 2);

                //for (int i = 0; i < vectorsFinal.Count; i++)
                //{
                //   g.FillRectangle(brush, (float)Math.Round(100 * ((float)vectorsFinal[i][0, 0] + 5)), -(float)Math.Round(100 * ((float)vectorsFinal[i][1, 0] -3)), 1, 1);
                //}


                /*
                g.FillRectangle(brush, (float)Math.Round(100 * ((float)basisProjected[3][0, 0] + 5)), -(float)Math.Round(100 * ((float)basisProjected[3][1, 0] - 3)), 2, 2);

                g.DrawLine(redPen, (float)Math.Round(100 * ((float)basisFinal[3][0, 0] + 5)), -(float)Math.Round(100 * ((float)basisFinal[3][1, 0] - 3)),
                (float)Math.Round(100 * ((float)basisFinal[0][0, 0] + 5)), -(float)(Math.Round(100 * ((float)basisFinal[0][1, 0] - 3))));

                g.DrawLine(greenPen, (float)Math.Round(100 * ((float)basisFinal[3][0, 0] + 5)), -(float)Math.Round(100 * ((float)basisFinal[3][1, 0] - 3)),
                (float)Math.Round(100 * ((float)basisFinal[1][0, 0] + 5)), -(float)(Math.Round(100 * ((float)basisFinal[1][1, 0] - 3))));

                g.DrawLine(bluePen, (float)Math.Round(100 * ((float)basisFinal[3][0, 0] + 5)), -(float)Math.Round(100 * ((float)basisFinal[3][1, 0] - 3)),
                (float)Math.Round(100 * ((float)basisFinal[2][0, 0] + 5)), -(float)(Math.Round(100 * ((float)basisFinal[2][1, 0] - 3))));
                */

            }
        }

        public static float perspectiveMod = 1;

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode.ToString());

            if (e.KeyCode == Keys.A) { aDown = true; }
            else if (e.KeyCode == Keys.D) { dDown = true; }
            else if (e.KeyCode == Keys.W) { wDown = true; }
            else if (e.KeyCode == Keys.S) { sDown = true; }
            else if (e.KeyCode == Keys.Q) { qDown = true; }
            else if (e.KeyCode == Keys.E) { eDown = true; }
            else if (e.KeyCode == Keys.Escape) { _isMouseLocked = false; this.Capture = false; Cursor.Show(); }
            else if (e.KeyCode == Keys.Oemtilde) { _isMouseLocked = true; this.Capture = true; Cursor.Hide(); }

            if (e.KeyCode == Keys.Up) { perspectiveMod += 0.1f; }
            else if(e.KeyCode == Keys.Down) { perspectiveMod -= 0.1f; }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private Point _lastMousePos;  // Store the last mouse position
        private bool _isMouseLocked = false;

        private void LockMouse()
        {
            _isMouseLocked = true;
            _lastMousePos = this.PointToClient(Cursor.Position);
            this.Cursor = Cursors.Cross;

            this.Capture = true;
        }

        private void LockMouseToCenter()
        {
            // Set the cursor position to the center of the form (relative to the screen)
            Cursor.Position = this.PointToScreen(new Point(this.Width / 2, this.Height / 2));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_isMouseLocked)
            {
                bool move = true;

                Point currentMousePos = e.Location;

                Point mouseDelta = new Point(e.X - _lastMousePos.X, e.Y - _lastMousePos.Y);
                if (Math.Abs(mouseDelta.X) > 25 || Math.Abs(mouseDelta.Y) > 25)
                    move = false;

                if(move)
                {
                    b -= (mouseDelta.X*0.001f);
                    a += (mouseDelta.Y * 0.001f);

                }
                //b += (System.Windows.Forms.Cursor.Position.X - this.Width/2) * 0.01f;

                _lastMousePos = currentMousePos;

                if (Math.Abs(this.Width/2 - e.X) >50 || (Math.Abs(this.Height / 2 - e.Y) > 50))
                    LockMouseToCenter();
            }
            //Point mouseDelta = new Point(e.X - _las)
        }

        private void KeyLifted(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { aDown = false; }
            else if (e.KeyCode == Keys.D) { dDown = false; }
            else if (e.KeyCode == Keys.W) { wDown = false; }
            else if (e.KeyCode == Keys.S) { sDown = false; }
            else if (e.KeyCode == Keys.Q) { qDown = false; }
            else if (e.KeyCode == Keys.E) { eDown = false; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Calculations
    {
        static float scalar = 1f;

        public static Matrix<double> CalculateProjectionMatrix(float a, float b)
        {
            Matrix<double> vOrtho = DenseMatrix.OfArray(new double[,]
            {
                {scalar *Math.Sin(a)*Math.Cos(b) },{scalar *Math.Sin(a)*Math.Sin(b) },{ scalar *Math.Cos(a) }
            });

            Matrix<double> b1 = DenseMatrix.OfArray(new double[,]
            {
                {scalar * Math.Sin(a-((float)Math.PI)/2)*Math.Cos(b) },{ scalar * Math.Sin(a-((float)Math.PI)/2)*Math.Sin(b) },{scalar * Math.Cos(a-((float) Math.PI)/2) }
            });

            Matrix<double> b2 = CrossProduct(vOrtho, b1);

            Matrix<double> A = DenseMatrix.OfArray(new double[,]
            {
                {b1[0,0], b2[0,0] },
                {b1[1,0], b2[1,0] },
                {b1[2,0], b2[2,0] }
            });

            Matrix<double> projA = A * (A.Transpose() * A).Inverse() * A.Transpose();
            Matrix<double> B = DenseMatrix.OfArray(new double[,]
            {
                {b2[0,0], vOrtho[0,0], b1[0,0]},
                {b2[1,0], vOrtho[1,0], b1[1,0]},
                {b2[2,0], vOrtho[2,0], b1[2,0]}
            });

            Matrix<double> T = DenseMatrix.OfArray(new double[,]
            {
                {1,0,0 },
                {0,1,0 }
            });

            Matrix<double> projFinal = T * B.Inverse() * projA;

            return projFinal;
        }

        public static Matrix<double> GetVOrtho(float a,float b)
        {
            return DenseMatrix.OfArray(new double[,] {
                    {scalar * Math.Sin(a)*Math.Cos(b) },{scalar * Math.Sin(a)*Math.Sin(b) },{scalar * Math.Cos(a) }
                });
        }

        public static Matrix<double> GetB(float a, float b)
        {
            Matrix<double> vOrtho = DenseMatrix.OfArray(new double[,]
            {
                {scalar * Math.Sin(a)*Math.Cos(b) },{scalar * Math.Sin(a)*Math.Sin(b) },{scalar * Math.Cos(a) }
            });

            Matrix<double> b1 = DenseMatrix.OfArray(new double[,]
            {
                {scalar * Math.Sin(a-((float)Math.PI)/2)*Math.Cos(b) },{scalar * Math.Sin(a-((float)Math.PI)/2)*Math.Sin(b) },{scalar * Math.Cos(a-((float) Math.PI)/2) }
            });

            Matrix<double> b2 = CrossProduct(vOrtho, b1);

            Matrix<double> A = DenseMatrix.OfArray(new double[,]
            {
                {b1[0,0], b2[0,0] },
                {b1[1,0], b2[1,0] },
                {b1[2,0], b2[2,0] }
            });

            Matrix<double> projA = A * (A.Transpose() * A).Inverse() * A.Transpose();
            Matrix<double> B = DenseMatrix.OfArray(new double[,]
            {
                {b2[0,0], vOrtho[0,0], b1[0,0]},
                {b2[1,0], vOrtho[1,0], b1[1,0]},
                {b2[2,0], vOrtho[2,0], b1[2,0]}
            });

            return B;
        }

        public static Matrix<double> DistortPerspective(float x, float y, float z, Matrix<double> vector, float perspectiveMod)
        {
            float dist = (float)vector[1, 0];//(float)Math.Sqrt(Math.Pow(vector[0, 0], 2) + Math.Pow(vector[1, 0], 2) + Math.Pow(vectorOffset[2, 0], 2));
            float multiplier = 1 / (1 * (0.1f * Math.Abs(dist) + 0.1f));

            return DenseMatrix.OfArray(new double[,]
            {
               {  vector[0,0] * multiplier },// + multiplier * vectorProjected[0,0] },
               {  vector[2,0] * multiplier }// + multiplier * vectorProjected[1,0] },
            });
        }

        public static Matrix<double> CrossProduct(Matrix<double> a, Matrix<double> b)
        {
            double i;
            double j;
            double k;

            i = (a[1, 0] * b[2, 0]) - (a[2, 0] * b[1, 0]);
            j = (a[0, 0] * b[2, 0]) - (a[2, 0] * b[0, 0]);
            k = (a[0, 0] * b[1, 0]) - (a[1, 0] * b[0, 0]);

            return DenseMatrix.OfArray(new double[,]
            {
                {i },{-j },{k }
            });
        }

        public static float DotProduct(Matrix<double> a, Matrix<double> b)
        {
            float prod = 0;
            for(int i = 0; i < a.RowCount; i++)
            {
                prod += (float)(a[i, 0] * b[i, 0]);
            }

            return prod;
        }
    }
}
