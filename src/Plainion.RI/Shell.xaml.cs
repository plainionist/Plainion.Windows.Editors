using System.Windows;

namespace Plainion.RI
{
    public partial class Shell : Window
    {
        internal Shell( ShellViewModel viewModel )
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
