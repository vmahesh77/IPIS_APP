using ArecaIPIS.Forms.HomeForms;
using System.Windows.Forms;

namespace ArecaIPIS.Classes
{
    class OBJ
    {
        public static frmOnlineTrains frmOnlinetrainsInstance()
        {
            Form mainForm = Application.OpenForms["frmOnlineTrains"];
            frmOnlineTrains frmonline;

            if (mainForm != null)
            {
                frmonline = (frmOnlineTrains)mainForm;
            }
            else
            {
                frmonline = new frmOnlineTrains();
            }

            return frmonline;
        }

    }
}
