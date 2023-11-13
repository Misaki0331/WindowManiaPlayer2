using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowManiaPlayer
{
    public partial class Notes : Form
    {

        public Notes()
        {
            InitializeComponent();

           // ClientSize = new(150, 1);
            Hide();
        }
        public int NoteNumber=-1;
        public bool WillHide = false;
        bool release = false;
        private void notes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!release)e.Cancel = true;
        }
        public void Release()
        {
            release = true;
            Close();
        }
    }
}
