﻿using System.Windows.Forms;
using LauncherPlugin;
using Microsoft.Win32;
using System;

namespace QuickLauncher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.ControlBox = false;

            string path;
            path = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\QuickLauncher", "pluginPath", "");
            if (path == null || path == "")
                path = (String)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\QuickLauncher", "pluginPath", ".");

            int top = 0;
            Console.WriteLine(path);
            var plugins = GenericPluginLoader<ILauncherPlugin>.LoadPlugins(path);
            foreach (ILauncherPlugin plug in plugins)
            {
                Console.WriteLine(plug.Name + " " + plug.Version);
                UserControl uc = plug.Init();
                uc.Top = top;
                rootpane.Controls.Add(uc);
                top += uc.Height + 3;
            }

            this.Height = top;

            this.Location = new System.Drawing.Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height
                );
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}