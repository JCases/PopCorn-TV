using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopCorn_TV
{
    public partial class VlcPlayer : UserControl
    {
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin;

        public VlcPlayer()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VlcPlayer));
            this.axVLCPlugin = new AxAXVLC.AxVLCPlugin2();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin)).BeginInit();
            this.SuspendLayout();
            // 
            // axVLCPlugin
            // 
            this.axVLCPlugin.CausesValidation = false;
            this.axVLCPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVLCPlugin.Enabled = true;
            this.axVLCPlugin.Location = new System.Drawing.Point(0, 0);
            this.axVLCPlugin.Name = "axVLCPlugin";
            this.axVLCPlugin.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin.OcxState")));
            this.axVLCPlugin.Size = new System.Drawing.Size(150, 150);
            this.axVLCPlugin.TabIndex = 0;
            this.axVLCPlugin.TabStop = false;
            // 
            // VlcPlayer
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.axVLCPlugin);
            this.Name = "VlcPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
