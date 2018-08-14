using System.Windows;
using System.Windows.Input;
using AXVLC;
using AxAXVLC;

namespace PopCorn_TV
{
    /// <summary>
    /// Lógica de interacción para FSPCTV.xaml
    /// </summary>
    public partial class FSPCTV : Window
    {
        public AxVLCPlugin2 vlc;
        public AppPCTV app;
        public FSPCTV(AxVLCPlugin2 vlc, AppPCTV app)
        {
            InitializeComponent();

            this.vlc = vlc;
            this.app = app;

            vlcPlayer.Child = this.vlc;
            this.vlc.CreateControl();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                app.FSOut(vlc);
                Close();
            }
                
        }
    }
}
