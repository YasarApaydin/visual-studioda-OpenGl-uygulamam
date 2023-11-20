using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;


namespace Odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OpenGlControl.InitializeContexts();

            Gl.glClearColor(0, 0, 1, 0);
            Gl.glOrtho(-12, 12, -12, 12, -1, 1);
        }

        private void OpenGlControl_Paint(object sender, PaintEventArgs e)
        {
            Gl.glColor3f(1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);




            // Koordinat eksenlerini çizme
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2f(-12, 0); // Başlangıç noktası
            Gl.glVertex2f(12, 0); // Bitiş noktası

            Gl.glVertex2f(0, -12); // Başlangıç noktası
            Gl.glVertex2f(0, 12); // Bitiş noktası

            Gl.glEnd();



            Gl.glBegin(Gl.GL_TRIANGLES);

            Gl.glColor3f(0, 1, 1);
            // A noktası (6, 2)
            Gl.glVertex3f(6, 2, 1);
            // B noktası (9, 2)
            Gl.glVertex3f(9, 2, 1);
            // C noktası (6, 4)
            Gl.glVertex3f(6, 4, 1);
            Gl.glEnd();






            // matrisi tanımlama
            double[,] matrisimiz = {
                    { 6, 2, 1 },
                    { 9, 2, 1 },
                    { 6, 4, 1 }
                };



            double[,] oteleme ={
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { -10, -10, 1 }
                };


            int satir = matrisimiz.GetLength(0);
            int sutun = matrisimiz.GetLength(1);



            double[,] dondur = new double[3, 3];
            for (int t = 0; t < satir; t++)
            {
                for (int m = 0; m < sutun; m++)
                {
                    dondur[t, m] = 0;
                    for (int k = 0; k < sutun; k++)
                    {
                        dondur[t, m] += matrisimiz[t, k] * oteleme[k, m];
                    }
                }
            }


            double[,] dondur1 = new double[3, 3];



            double[,] dondurmeAci ={
                    { Math.Cos(70), -Math.Sin(70), 0 },
                    { Math.Sin(70), Math.Cos(70) , 0 },
                    { 0           , 0            , 1 }
                };


            for (int t = 0; t < satir; t++)
            {
                for (int m = 0; m < sutun; m++)
                {
                    dondur1[t, m] = 0;
                    for (int k = 0; k < sutun; k++)
                    {
                        dondur1[t, m] += dondur[t, k] * dondurmeAci[k, m];
                    }
                }
            }





            double[,] ters_otele ={
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { 10, 10, 1 }
                };

            double[,] dondur2 = new double[3, 3];

            for (int t = 0; t < satir; t++)
            {
                for (int m = 0; m < sutun; m++)
                {
                    dondur2[t, m] = 0;
                    for (int k = 0; k < sutun; k++)
                    {
                        dondur2[t, m] += dondur1[t, k] * ters_otele[k, m];
                    }
                }
            }




            //   Dödürülmüş  üçgenin çizimi
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3f(1, 0, 0);
            Gl.glVertex3f((float)dondur2[0, 0], (float)dondur2[0, 1], (float)dondur2[0, 2]);

            Gl.glVertex3f((float)dondur2[1, 0], (float)dondur2[1, 1], (float)dondur2[1, 2]);

            Gl.glVertex3f((float)dondur2[2, 0], (float)dondur2[2, 1], (float)dondur2[2, 2]);
            Gl.glEnd();




            double[,] oteleme2 = {
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { 0, -12, 1 }
                };



            //Dödürdükten sonraki öteleme işlemi
            double[,] oteleme3 = new double[3, 3];
            for (int t = 0; t < satir; t++)
            {
                for (int m = 0; m < sutun; m++)
                {
                    oteleme3[t, m] = 0;
                    for (int k = 0; k < sutun; k++)
                    {
                        oteleme3[t, m] += dondur2[t, k] * oteleme2[k, m];
                    }
                }
            }




            //Ötelenmiş Ücgenin Cizimi
            Gl.glBegin(Gl.GL_TRIANGLES);

            Gl.glColor3f(1, 0, 0);
            Gl.glVertex3f((float)oteleme3[0, 0], (float)oteleme3[0, 1], (float)oteleme3[0, 2]);

            Gl.glVertex3f((float)oteleme3[1, 0], (float)oteleme3[1, 1], (float)oteleme3[1, 2]);

            Gl.glVertex3f((float)oteleme3[2, 0], (float)oteleme3[2, 1], (float)oteleme3[2, 2]);
            Gl.glEnd();







            //Noktanın Cizimi
            int kenarSayisi1 = 20;
            Gl.glColor3d(2, 0, 0);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int i = 0; i < kenarSayisi1; i++)
            {
                float aci = 2.0f * (float)Math.PI * i / kenarSayisi1;
                float x = (float)Math.Cos(aci) * 0.8f + 10;
                float y = (float)Math.Sin(aci) * 0.8f + 10;
                Gl.glVertex2f(x, y);
            }

            Gl.glEnd();
        }
    }
}
