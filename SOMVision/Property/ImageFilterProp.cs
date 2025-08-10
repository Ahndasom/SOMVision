using SOMVision.Grab;
using SOMVision.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOMVision
{
    public enum FilterType
    {
        None,
        Grayscale,
        HSVscale,
        Flip,
        Pyramid,
        Resize,
        Binary,
        CannyEdge,
        Morphology,
        Rotation
    }

    public partial class ImageFilterProp : UserControl
    {
        public ImageFilterProp()
        {
            InitializeComponent();
            cbFilterList.DataSource = Enum.GetValues(typeof(FilterType)).Cast<FilterType>().ToList();

            //환경설정에서 현재 카메라 타입 얻기
            cbFilterList.SelectedIndex = 0;
        }

        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {

        }

        private void btnSrc_Click(object sender, EventArgs e)
        {

        }
    }
}
