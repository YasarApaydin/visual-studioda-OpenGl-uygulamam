
namespace Odev
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // OpenGlControl
            // 
            this.OpenGlControl.AccumBits = ((byte)(0));
            this.OpenGlControl.AutoCheckErrors = false;
            this.OpenGlControl.AutoFinish = false;
            this.OpenGlControl.AutoMakeCurrent = true;
            this.OpenGlControl.AutoSwapBuffers = true;
            this.OpenGlControl.BackColor = System.Drawing.Color.Black;
            this.OpenGlControl.ColorBits = ((byte)(32));
            this.OpenGlControl.DepthBits = ((byte)(16));
            this.OpenGlControl.Location = new System.Drawing.Point(45, 7);
            this.OpenGlControl.Name = "OpenGlControl";
            this.OpenGlControl.Size = new System.Drawing.Size(524, 438);
            this.OpenGlControl.StencilBits = ((byte)(0));
            this.OpenGlControl.TabIndex = 0;
            this.OpenGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControl_Paint);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(625, 457);
            this.Controls.Add(this.OpenGlControl);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private Tao.Platform.Windows.SimpleOpenGlControl OpenGlControl;
    }
}

