using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newt
{
    public partial class SaveForm : Form
    {
        public SaveForm(string Message)
        {
            InitializeComponent();
            Label_Action.Text = Message;
        }

        public void SetMessage(string Message)
        {
            Label_Action.Text = Message;
            this.Update();
        }
    }
}
