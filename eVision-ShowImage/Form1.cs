//eVision-Show Image Sample 
//Function: 1. Load Image 
//          2. convert Bitmap to EImageC24
//          3. Show EImageC24 Image to picturebox
//Enviornment: VS 2012, eVision 2.2.2
//Caution: using eVision need to run [Visual Studio] or [compiled exe] as administrator, if not it will not able to get the grant from license dongle.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Euresys.Open_eVision_2_7;

namespace eVision_ShowImage
{
    public partial class Form1 : Form
    {
        Bitmap bitmap = null;
        BitmapData bmpData = null;
        EImageC24 EC24Image1 = new EImageC24(); //eVision的彩色圖像物件
        EImageBW8 EBW8Image1 = new EImageBW8(); //eVision的灰階圖像物件
        float ScalingRatio = 0; //Picturebox與原始影像大小的縮放比例
        float EBW8ScaleRatio;

        EWorldShape EWorldShape1 = new EWorldShape();
        EFrameShape EFrameShape1 = new EFrameShape();

        EPatternFinder F1 = new EPatternFinder();
        EFoundPattern[] F1FoundPatterns;

        ECircleGauge C1 = new ECircleGauge();
        ELineGauge L1 = new ELineGauge();
        public Form1()
        {
            InitializeComponent();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            //使用者選取Bitmap檔案
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //第一種載入作法:
                ////讀取檔案的Bitmap (一般這一行也可以改成從相機的影像進行讀取）
                //Bitmap bitmap_source = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                ////當bitmap尚未創建記憶體空間時直接使用Clone複製來源影像
                //if (bitmap == null)
                //    bitmap = (Bitmap)bitmap_source.Clone(); //複製完整的記憶體空間
                ////指派影像
                //bitmap = bitmap_source; 

                ////防止來源影像為空則不處理
                //if (bitmap == null)
                //    return;
                ////Bitmap影像轉換eVision格式影像
                ////EC24Image1 = BitmapToEImageC24(ref bitmap);

                //第二種載入作法:
                EC24Image1.Load(openFileDialog1.FileName); //直接載入
                
                //顯示影像於Picturebox
                ShowImage(EC24Image1, pbImage);

                //因Bitmap容易造成記憶體外洩，因此將資料從記憶體中Dispose，並且進行GC
                //bitmap.Dispose(); //第一種作法要記得取消記憶體的空間
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            //使用者選取Bitmap檔案
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                EBW8Image1.Load(openFileDialog1.FileName); //直接載入

                //顯示影像於Picturebox
                ShowImage(EBW8Image1, pbImage);
            }
        }

        /// <summary>
        /// Bitmap影像轉換eVision格式影像
        /// </summary>
        /// <param name="bitmap">來源Bitmap影像</param>
        /// <returns>轉換後的EImageC24影像</returns>
        private EImageC24 BitmapToEImageC24(ref Bitmap bitmap)
        {
            EImageC24 EC24Image1 = null;
            try
            {
                EC24Image1 = new EImageC24();

                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                bmpData =
                    bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bitmap.PixelFormat);

                EC24Image1.SetImagePtr(bitmap.Width, bitmap.Height, bmpData.Scan0);
                bitmap.UnlockBits(bmpData);

            }
            catch (EException e)//EException為eVision的例外處理
            {
                Console.WriteLine(e.ToString());
            }
            return EC24Image1;
        }

        /// <summary>
        /// 顯示影像於Picturebox
        /// </summary>
        /// <param name="img">顯示的eVision影像</param>
        /// <param name="pb">目標Picturebox</param>
        private void ShowImage(EImageC24 img, PictureBox pb)
        {
            try
            {
                Bitmap bmp;
                bmp = new Bitmap(pb.Width, pb.Height);

                //計算Picturebox與顯示影像的比例，以便將影像縮放並且完整呈現到picturebox上。
                float PictureBoxSizeRatio = (float)pb.Width / pb.Height;
                float ImageSizeRatio = (float)img.Width / img.Height;
                if (ImageSizeRatio > PictureBoxSizeRatio)
                    ScalingRatio = (float)pb.Width / img.Width;
                else
                    ScalingRatio = (float)pb.Height / img.Height;

                //委派
                if (pb.InvokeRequired)
                {
                    pb.Invoke(new MethodInvoker(delegate() { img.Draw(Graphics.FromImage(bmp), ScalingRatio); pb.BackgroundImage = bmp; }));
                }
                else
                {
                    //先將EImageC24畫在bitmap模式的圖檔
                    img.Draw(Graphics.FromImage(bmp), ScalingRatio);
                    //再由Picturebox取得bitmap
                    pb.BackgroundImage = bmp;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void ShowImage(EImageBW8 img, PictureBox pb)
        {
            try
            {
                Bitmap bmp;
                bmp = new Bitmap(pb.Width, pb.Height);

                //計算Picturebox與顯示影像的比例，以便將影像縮放並且完整呈現到picturebox上。
                float PictureBoxSizeRatio = (float)pb.Width / pb.Height;
                float ImageSizeRatio = (float)img.Width / img.Height;
                if (ImageSizeRatio > PictureBoxSizeRatio)
                    ScalingRatio = (float)pb.Width / img.Width;
                else
                    ScalingRatio = (float)pb.Height / img.Height;
                EBW8ScaleRatio = ScalingRatio; //記錄此比例供繪製輪廓軌跡使用
                //委派
                if (pb.InvokeRequired)
                {
                    pb.Invoke(new MethodInvoker(delegate () { img.Draw(Graphics.FromImage(bmp), ScalingRatio); pb.BackgroundImage = bmp; }));
                }
                else
                {
                    //先將EImageC24畫在bitmap模式的圖檔
                    img.Draw(Graphics.FromImage(bmp), ScalingRatio);
                    //再由Picturebox取得bitmap
                    pb.BackgroundImage = bmp;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;

            F1.AngleBias = 0f;
            F1.AngleTolerance = 180.00f;
            F1.ScaleTolerance = 0.05f;

            this.C1.Attach(this.EFrameShape1);
            this.C1.SetCenterXY(279f,325.5f);
            this.C1.Tolerance = 20;
            this.C1.Diameter = 104.69f;

            this.L1.Attach(this.EFrameShape1);
            this.L1.SetCenterXY(18.5f, 121.5f);
            this.L1.Tolerance = 20;
            this.L1.Length = 200;

            this.EFrameShape1.Attach(EWorldShape1);
            this.EFrameShape1.SetCenterXY(242f, 268.5f);
        }

        float ppm;
        private void button_PPM_Click(object sender, EventArgs e)
        {
            ppm = float.Parse(this.TXT_MM.Text) / float.Parse(this.TXT_PX.Text);
            this.LBL_PPM.Text = ppm.ToString("0.000");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = this.openFileDialog1.FileName;

                this.F1.Load(fileName);

                MessageBox.Show("OK");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.pbImage.CreateGraphics();

            EFoundPattern firstMode1 = this.F1FoundPatterns[0];
            firstMode1.DrawCenter = true;
            firstMode1.DrawBoundingBox = true;
            firstMode1.DrawFeaturePoints = true;
            Color drawColor = Color.Red;
            firstMode1.Draw(g, new ERGBColor(drawColor.R, drawColor.G, drawColor.B), ScalingRatio, ScalingRatio);

            this.EFrameShape1.Draw(g, EDrawingMode.Nominal, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EPoint center = this.F1FoundPatterns[0].Center;
            float angle = this.F1FoundPatterns[0].Angle;

            this.EFrameShape1.Angle = angle;
            this.EFrameShape1.SetCenterXY(center.X, center.Y);

            Graphics g = this.pbImage.CreateGraphics();
            this.EFrameShape1.Draw(g, EDrawingMode.Nominal, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            C1.Measure(this.EBW8Image1);
            L1.Measure(this.EBW8Image1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            float circleDiameter = C1.MeasuredCircle.Diameter * ppm;
        }

        /// <summary>計算兩點之間的長度</summary>
        /// <param name="PointA">第一點座標</param>
        /// <param name="PointB">第二點座標</param>
        /// <param name="PointAToPointCLength">輸出: A 到 B 點距離</param>
        /// <remarks>
        /// </remarks>
        /// <see>參考：http://163.32.100.89/koliming/volume1/1-2/1-2_ex-8/1-2_ex-8.html </see>
        public static void CalLengthBetweenTwoPoint(PointF PointA, PointF PointB, out double PointAToPointCLength)
        {
            //取得AC線段長
            PointAToPointCLength = Math.Sqrt(Math.Pow(PointA.X - PointB.X, 2) + Math.Pow(PointA.Y - PointB.Y, 2));
        }

        /// <summary>點到線垂直距離計算</summary>
        /// <param name="lineStartPoint">線段起點</param>
        /// <param name="lineEndPoint">線段終點</param>
        /// <param name="measurePoint">量測點</param>
        /// <param name="LineCrossPoint">回傳 點線距離計算垂直點</param>
        /// <returns>點到線距離</returns>
        public static double CalPointToLineVerticalPointDistance(PointF lineStartPoint, PointF lineEndPoint, PointF measurePoint, out PointF LineCrossPoint) //向量
        {
            PointF crossPos = new PointF();
            double cross = (lineEndPoint.X - lineStartPoint.X) * (measurePoint.X - lineStartPoint.X) + (lineEndPoint.Y - lineStartPoint.Y) * (measurePoint.Y - lineStartPoint.Y);

            double d2 = (lineEndPoint.X - lineStartPoint.X) * (lineEndPoint.X - lineStartPoint.X) + (lineEndPoint.Y - lineStartPoint.Y) * (lineEndPoint.Y - lineStartPoint.Y);
            double r = cross / d2;
            double px = lineStartPoint.X + (lineEndPoint.X - lineStartPoint.X) * r;
            double py = lineStartPoint.Y + (lineEndPoint.Y - lineStartPoint.Y) * r;
            crossPos.X = (float)px;
            crossPos.Y = (float)py;
            LineCrossPoint = crossPos;
            return Math.Sqrt((measurePoint.X - px) * (measurePoint.X - px) + (py - measurePoint.Y) * (py - measurePoint.Y));
        }
    }
}
