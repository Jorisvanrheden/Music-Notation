using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Music_Notation.Source;

namespace Music_Notation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


        }

        private void InitializeProgram()
        {
            //Load resources

            //Start maininterface
            MainInterface mainInterface = new MainInterface();

            mainInterface.Run();
        }
    }
}
