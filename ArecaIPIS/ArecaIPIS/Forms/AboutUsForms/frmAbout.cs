using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }
        private frmIndex parentForm;
        public frmAbout(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
    }
}
