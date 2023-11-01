using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;

namespace AIBSoft
{
    [ProvideProperty("ShortCut", typeof(Control))]
    public class ShortCutProvider : Component, IExtenderProvider
    {
        private Hashtable properties;
        private System.ComponentModel.Container components = null;

        public ShortCutProvider()
        {
            properties = new Hashtable();
            components = new System.ComponentModel.Container();
        }
        public ShortCutProvider(System.ComponentModel.IContainer container)
            : this()
        {
            container.Add(this);
        }
        bool IExtenderProvider.CanExtend(object ctrl)
        {
            return (ctrl is Button || ctrl is SimpleButton);
        }

        [DefaultValue(System.Windows.Forms.Shortcut.None)]
        [Category("Shortcut")]
        [Description("Set Shortcut for Button")]
        public System.Windows.Forms.Shortcut GetShortCut(Control g)
        {
            var p = (System.Windows.Forms.Shortcut?)properties[g.Name];
            if (p == null)
            {
                properties.Add(g.Name, System.Windows.Forms.Shortcut.None);
            }
            return (System.Windows.Forms.Shortcut)properties[g.Name];
        }

        public void SetShortCut(Control g, System.Windows.Forms.Shortcut value)
        {
            if (value != Shortcut.None)
            {
                NativeWindowWithEvent m = new NativeWindowWithEvent();
                m.control = g;
                RegisterHotkey(m, value);
                m.ProcessMessage += new MessageEventHandler(m_ProcessMessage);
            }
            var p = (System.Windows.Forms.Shortcut?)properties[g.Name];
            if (p == null)
            {
                properties.Add(g.Name, value);
            }
            else
            {
                properties[g.Name] = value;
            }
        }

        void m_ProcessMessage(object Sender, ref System.Windows.Forms.Message msg, ref bool Handled)
        {
            if (msg.Msg == 0x0312)
            {
                var ctrl = ((NativeWindowWithEvent)Sender).control;
                if (ctrl is SimpleButton)
                    ((SimpleButton)ctrl).PerformClick();
                else
                    ((Button)ctrl).PerformClick();
            }

        }
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        protected bool RegisterHotkey(NativeWindowWithEvent m, Shortcut key)
        {
            int mod = 0;
            Keys k2 = Keys.None;
            if (((int)key & (int)Keys.Alt) == (int)Keys.Alt) { mod += 0x0001; k2 = Keys.Alt; }
            if (((int)key & (int)Keys.Shift) == (int)Keys.Shift) { mod += 0x0004; k2 = Keys.Shift; }
            if (((int)key & (int)Keys.Control) == (int)Keys.Control) { mod += 0x0002; k2 = Keys.Control; }
            return RegisterHotKey(m.Handle, this.GetType().GetHashCode(), (int)mod, ((int)key) - ((int)k2));
        }
    }
    public delegate void MessageEventHandler(object Sender, ref Message msg, ref bool Handled);
    public class NativeWindowWithEvent : NativeWindow
    {
        public Control control;
        public event MessageEventHandler ProcessMessage;
        public NativeWindowWithEvent()
        {
            CreateParams parms = new CreateParams();
            this.CreateHandle(parms);
        }
        protected override void WndProc(ref Message m)
        {
            if (ProcessMessage != null)
            {
                bool Handled = false;
                ProcessMessage(this, ref m, ref Handled);
                if (!Handled)
                    base.WndProc(ref m);
            }
            else
                base.WndProc(ref m);
        }

    }
}
