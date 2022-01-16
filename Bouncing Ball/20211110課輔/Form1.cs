using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace _20211110課輔
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        double x_caculate = 1.0, y_caculate = 1.0, z_caculate = 1.0;
        double cx = 0.0, cy = 0.0, cz = 0.0;//球心
        double rot = 0.0;//旋轉角度
        double dx = 0.0, dy = 0.0, dz = 0.0;//球移動方向

        public Form1()
        {
            InitializeComponent();
            this.openGLControl1.InitializeContexts();
            Glut.glutInit();
        }
        private void MyInit()
        {
            x_caculate = rand.Next(1, 4);
            y_caculate = rand.Next(1, 4);
            z_caculate = rand.Next(1, 4);

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }


        private void SetViewingVolume()
        {
            Gl.glViewport(0, 0, openGLControl1.Size.Width, openGLControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect =
                   (double)openGLControl1.Size.Width / (double)openGLControl1.Size.Height;
            Glu.gluPerspective(45, aspect, 10.0, 100.0);
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            SetViewingVolume();
        }

        private void openGLControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0, 0.0, 50.0, 0.0, 0.0, 0.0, 1.0, 0.0,0.0);
            //--------------------上--------------------
            Gl.glColor3ub(0, 0, 255);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(10, 10, 10);
            Gl.glVertex3f(10, 10, -10);
            Gl.glVertex3f(-10, 10, -10);
            Gl.glVertex3f(-10, 10, 10);
            Gl.glEnd();
            //--------------------裡--------------------
            Gl.glColor3ub(255, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(10, 10, -10);
            Gl.glVertex3f(10, -10, -10);
            Gl.glVertex3f(-10, -10, -10);
            Gl.glVertex3f(-10, 10, -10);
            Gl.glEnd();
            //--------------------右--------------------
            Gl.glColor3ub(0, 255, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(10, -10, -10);
            Gl.glVertex3f(10, -10, 10);
            Gl.glVertex3f(10, 10, 10);
            Gl.glVertex3f(10, 10, -10);
            Gl.glEnd();
            //--------------------左--------------------
            Gl.glColor3ub(0, 255, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(-10, 10, -10);
            Gl.glVertex3f(-10, -10, -10);
            Gl.glVertex3f(-10, -10, 10);
            Gl.glVertex3f(-10, 10, 10);
            Gl.glEnd();
            //--------------------下--------------------
            Gl.glColor3ub(0, 0, 255);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(-10, -10, -10);
            Gl.glVertex3f(10, -10, -10);
            Gl.glVertex3f(10, -10, 10);
            Gl.glVertex3f(-10, -10, 10);
            Gl.glEnd();//bottom

            Gl.glPushMatrix();
            Gl.glTranslated(cx, cy, cz);
            Gl.glRotated(rot, 1, 1, 1);
            Glut.glutWireSphere(1.0, 16, 16);
            Gl.glPopMatrix();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            cx += x_caculate;cy += y_caculate; cz += z_caculate;
            if (cx >= 9)
                x_caculate*=-1.0;
            else if (cx <= -9)
                x_caculate *= -1.0;
            if (cy >= 9)
                y_caculate *= -1.0;
            else if (cy <= -9)
                y_caculate *= -1.0;
            if (cz >= 9)
                z_caculate *= -1.0;
            else if (cz <= -9) 
                z_caculate *= -1.0;


            this.openGLControl1.Refresh();
        }

    }
}
