using System.Windows;

namespace numberConversion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NumConverter nc = new NumConverter();

        public MainWindow()
        {
            //Initialization and data context
            InitializeComponent();
            DataContext = nc;
            nc.Result = "Enter a number between 1 - 100.";
        }

        //On click event
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            nc.Converter();
        }
    }
}
