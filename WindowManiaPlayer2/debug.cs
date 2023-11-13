using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowManiaPlayer
{
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }
        public bool WantClose = false;
        private void debug_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WantClose = true;
        }
    }
}
