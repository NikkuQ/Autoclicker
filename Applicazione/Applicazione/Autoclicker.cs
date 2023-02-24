using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Autoclicker
{
    public partial class Autoclicker : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public enum MouseEventFlags
        {
            LeftDown = 2,
            LeftUp = 4
        }

        public void leftClick(Point p)
        {
            mouse_event((int)MouseEventFlags.LeftDown, p.X, p.Y, 0, 0);
            mouse_event((int)MouseEventFlags.LeftUp, p.X, p.Y, 0, 0);
        }

        bool esecuzione = false;

        public Autoclicker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            esecuzione = !esecuzione;
            timer1.Interval = (int)numericUpDown1.Value;
            timer1.Enabled = true;
            if (esecuzione)
            {
                timer1.Start();
                button1.BackColor = Color.GreenYellow;
            }
            else
            {
                timer1.Stop();
                button1.BackColor = Color.Transparent;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            leftClick(new Point(MousePosition.X, MousePosition.Y));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.NumPad0))
            {
                if (!esecuzione)
                {
                    timer1.Interval = (int)numericUpDown1.Value;
                    timer1.Enabled = true;
                    esecuzione = true;
                    timer1.Start();
                }
                else      
                {
                    timer1.Interval = (int)numericUpDown1.Value;
                    timer1.Enabled = false;
                    esecuzione = false;
                    timer1.Stop();
                }
            }
            //if ((!esecuzione) && Keyboard.IsKeyDown(Key.NumPad0))
            //{
            //    timer1.Interval = (int)numericUpDown1.Value;
            //    timer1.Enabled = true;
            //    timer1.Start();
            //}
            //else if (esecuzione && Keyboard.IsKeyDown(Key.NumPad0))
            //{
            //    timer1.Interval = (int)numericUpDown1.Value;
            //    timer1.Enabled = false;
            //    timer1.Stop();
            //}
        }

        private void Autoclicker_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer2.Interval = 1;
            timer2.Start();
        }
    }
}
