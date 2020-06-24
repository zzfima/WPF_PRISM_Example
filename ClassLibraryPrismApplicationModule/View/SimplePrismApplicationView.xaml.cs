using ClassLibraryPrismApplicationModule.ViewModel;
using System.Windows.Controls;

namespace ClassLibraryPrismApplicationModule.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SimplePrismApplicationView : UserControl
    {
        private readonly MyViewModel _viewModel;

        public SimplePrismApplicationView()
        {
            InitializeComponent();
            _viewModel = new MyViewModel();
            // The DataContext serves as the starting point of Binding Paths
            DataContext = _viewModel;
        }
    }
}
