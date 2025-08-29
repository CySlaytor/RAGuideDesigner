using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public class BufferedTreeView : TreeView
    {
        public BufferedTreeView()
        {
            this.DoubleBuffered = true;
        }
    }
}