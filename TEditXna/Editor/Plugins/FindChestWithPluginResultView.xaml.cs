﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Xna.Framework;

namespace TEditXna.Editor.Plugins
{
    /// <summary>
    /// Interaction logic for ReplaceAllPlugin.xaml
    /// </summary>
    public partial class FindChestWithPluginResultView : Window
    {
        private char[] splitters = new char[] { ',' };
        public FindChestWithPluginResultView(IEnumerable<Vector2> locations)
        {
            InitializeComponent();
            foreach (Vector2 location in locations)
            {
                // Was to lazy to do it with Bindings (sorry)
                LocationList.Items.Add(String.Format("{0}, {1}", location.X, location.Y));
            }
        }

        public void CloseButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Close();
        }

        private void ListBoxMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ( e.OriginalSource is TextBlock )
            {
                TextBlock item = e.OriginalSource as TextBlock;
                if ( !string.IsNullOrEmpty(item.Text) )
                {
                    string[] positions = item.Text.Split(splitters);
                    if ( positions.Length == 2 )
                    {
                        int x = 0;
                        int y = 0;

                        if ( int.TryParse(positions[0].Trim(), out x) && int.TryParse(positions[1].Trim(), out y) )
                        {
                            MainWindow mainwin = Application.Current.MainWindow as MainWindow;
                            if (mainwin != null)
                            {
                                mainwin.ZoomFocus(x, y);
                            }
                        }
                    }
                }
            }
        }
    }
}
