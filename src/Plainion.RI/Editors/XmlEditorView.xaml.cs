using System.Windows.Controls;

namespace Plainion.RI.Editors
{
    public partial class XmlEditorView : UserControl
    {
        internal XmlEditorView(XmlEditorViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
