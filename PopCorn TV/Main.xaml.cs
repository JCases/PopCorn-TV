using System.Windows;
using System.Windows.Input;

namespace PopCorn_TV
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            Channels.Load();
        }

        ~Main() { }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void MoveWidow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void LoginIn(object sender, RoutedEventArgs e)
        {
            if (txtbxName.Text.Length == 0 && txtbxPassword.Password.Length == 0)
            {
                AppPCTV popCornTV = new AppPCTV();
                this.Close();
                popCornTV.Show();
            }
        }
    }
}
