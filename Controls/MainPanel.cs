using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CelluleMutante2.Controls
{
    public class MainPanel : Panel
    {
        public MainPanel()
        {
            Name = "pnl_main";
            BackColor = Color.LightGray;
            Anchor = AnchorStyles.None;
            Size = new Size(300, 300);
            Dock = DockStyle.None;
        }
    }
}
