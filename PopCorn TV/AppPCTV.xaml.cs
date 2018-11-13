using System.Windows;
using System.Windows.Input;
using AXVLC;
using AxAXVLC;
using System.Windows.Threading;
using System.Collections.Generic;

namespace PopCorn_TV
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class AppPCTV : Window
    {
        public AxVLCPlugin2 vlc;
        public static List<ChannelInfo> tvChannels;

        public bool IsPlaying;
        public AppPCTV()
        {
            InitializeComponent();

            ChargeChannels();

            // Create Player
            vlc = new AxVLCPlugin2();

            vlcPlayer.Child = vlc;
            vlc.CreateControl();

            vlc.Toolbar = false;

            IsPlaying = false;
        }

        ~AppPCTV() { }

        private void ChargeChannels()
        {
            for (int i = 0; i < Channels.tvChannels.Count; i++)
                ListChannels.Items.Add(Channels.tvChannels[i].name);
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            if (!IsPlaying)
            {
                bckgrndPlayer.Visibility = Visibility.Visible;

                vlc.playlist.add("http://xtremservices.com:8000/live/Planion/KFTkQnNoNk/3870.ts");

                vlc.playlist.play();

                IsPlaying = true;
            }
        }

        private void MoveWidow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void FSStart(object sender, RoutedEventArgs e)
        {
            FSPCTV fullscreen = new FSPCTV(vlc, this);
            fullscreen.ShowDialog();
        }

        public void FSOut(AxVLCPlugin2 vlc)
        {
            this.vlc = vlc;

            vlcPlayer.Child = vlc;
            vlc.CreateControl();

            vlc.Toolbar = false;
        }
    }
}
