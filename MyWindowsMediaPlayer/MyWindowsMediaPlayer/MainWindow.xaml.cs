﻿using System;
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
using System.Windows.Threading;
using MahApps.Metro.Controls;

namespace MyWindowsMediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowsMediaPlayer : MetroWindow
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        private int numberItems = 0;
        private int PlayListPos = 0;
 //       private int themePos = 1;
        private bool isFullscreen = false;
        private int count = 0;
        private List<File> list = new List<File>();

        private bool ValidateMediaItem(string data)
        {
            string extension;
            bool isValid = false;

            try
            {
                extension = data.Substring(data.LastIndexOf("."));
                foreach (string value in File.allTypes)
                {
                    if (value.Equals(extension, StringComparison.CurrentCultureIgnoreCase))
                        isValid = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured: " + e.Message);
            }
            return (isValid);
        }

        public WindowsMediaPlayer()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if ((WmPlayer.Source != null) && (WmPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
                {
                    sliProgress.Minimum = 0;
                    sliProgress.Maximum = WmPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                    sliProgress.Value = WmPlayer.Position.TotalSeconds;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }

        private void mediaEnd(object sender, RoutedEventArgs e)
        {
            try
            {
                if (list.ElementAtOrDefault(PlayListPos + 1) != null)
                {
                    PlayListPos = PlayListPos + 1;
                    WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                    count = 0;
                    foreach (object o in listItems.Items)
                    {
                        if (count == PlayListPos)
                            listItems.SelectedItem = o;
                        count = count + 1;
                    }
                    if (list.ElementAtOrDefault(PlayListPos) != null)
                    {
                        String musicName = list[PlayListPos].getUri;
                        nowPlaying.Text = "";
                        nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                    }
                }
                else
                {
                    PlayListPos = 0;
                    if (list.ElementAtOrDefault(0) != null)
                    {
                        WmPlayer.Source = new Uri(list[0].getUri);
                        count = 0;
                        foreach (object o in listItems.Items)
                        {
                            if (count == PlayListPos)
                                listItems.SelectedItem = o;
                            count = count + 1;
                        }
                        if (list.ElementAtOrDefault(PlayListPos) != null)
                        {
                            String musicName = list[PlayListPos].getUri;
                            nowPlaying.Text = "";
                            nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                        }
                    }
                    else
                        WmPlayer.Source = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }
    }
}
