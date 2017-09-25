using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RomanNumConversion
{
    public partial class MainWindow : Window
    {
        ConvertNum convertnum = new ConvertNum();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = convertnum;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtBoxNumber.Text, out int number) == false) //Validation to check if characters were entered      
            {
                MessageBox.Show("Enter numbers only.", "Invalid Entry");
                txtBoxNumber.Focus();
            }
            else
            {
                if (Convert.ToInt32(txtBoxNumber.Text) > 10) //Validation to make sure that numbers entered have corresponding value
                {
                    MessageBox.Show("Enter numbers from 1-10 only.", "Out of Range");
                    txtBoxNumber.Focus();
                }
                else
                    convertnum.RegNumToRomanNum();
            }
        }
    }

    //Got the code below at https://www.intertech.com/Blog/how-to-select-all-text-in-a-wpf-textbox-on-focus/
    //How to Select All Text in a WPF TextBox on Focus
    //by Intertech | Jun 18, 2010
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewMouseLeftButtonDownEvent,
               new MouseButtonEventHandler(SelectivelyHandleMouseButton), true);
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotKeyboardFocusEvent,
              new RoutedEventHandler(SelectAllText), true);

            base.OnStartup(e);
        }

        private static void SelectivelyHandleMouseButton(object sender, MouseButtonEventArgs e)
        {
            var textbox = (sender as TextBox);
            if (textbox != null && !textbox.IsKeyboardFocusWithin)
            {
                if (e.OriginalSource.GetType().Name == "TextBoxView")
                {
                    e.Handled = true;
                    textbox.Focus();
                }
            }
        }

        private static void SelectAllText(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)
                textBox.SelectAll();
        }
    }
}
