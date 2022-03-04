using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class HomeMaintainControl : Field4MaintainControl
    {
        public HomeMaintainControl()
        {
            InitializeComponent();
            pictureEdit1.Image = imageCollection1.Images[0];
        }
    }
}
