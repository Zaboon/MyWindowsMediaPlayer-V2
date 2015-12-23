using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace MyWindowsMediaPlayer
{
    public partial class WindowsMediaPlayer : MetroWindow
    {
        private void IsPlayExecutable(object sender, CanExecuteRoutedEventArgs e)
        {
            if (list.ElementAtOrDefault(PlayListPos) != null)
            {
                try
                {
                    String musicName = list[PlayListPos].getUri;
                    nowPlaying.Text = "";
                    nowPlaying.Text = musicName.Substring(musicName.LastIndexOf(@"\") + 1);
                }
                catch (Exception error)
                {
                    MessageBox.Show("An error occured: " + error.Message);
                }
            }
            e.CanExecute = (WmPlayer != null) && (WmPlayer.Source != null);
        }

        private void ExecutedPlay(object sender, ExecutedRoutedEventArgs e)
        {
            WmPlayer.Play();
            mediaPlayerIsPlaying = true;
        }

        private void IsPauseExecutable(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void ExecutedPause(object sender, ExecutedRoutedEventArgs e)
        {
            WmPlayer.Pause();
        }

        private void IsStopExecutable(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void ExecutedStop(object sender, ExecutedRoutedEventArgs e)
        {
            WmPlayer.Stop();
            mediaPlayerIsPlaying = false;
        }

        private void PreviousSong(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WmPlayer.Source != null)
                {
                    PlayListPos = PlayListPos - 1;
                    WmPlayer.Source = null;
                    if (list.ElementAtOrDefault(PlayListPos) != null)
                    {
                        WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                        count = 0;
                        foreach (object o in listItems.Items)
                        {
                            if (count == PlayListPos)
                                listItems.SelectedItem = o;
                            count = count + 1;
                        }
                    }
                    else
                    {
                        if (list.ElementAtOrDefault(0) != null)
                        {
                            PlayListPos = 0;
                            WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                            count = 0;
                            foreach (object o in listItems.Items)
                            {
                                if (count == PlayListPos)
                                    listItems.SelectedItem = o;
                                count = count + 1;
                            }
                        }
                        else
                            WmPlayer.Source = null;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }

        private void NextSong(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WmPlayer.Source != null)
                {
                    PlayListPos = PlayListPos + 1;
                    WmPlayer.Source = null;
                    if (list.ElementAtOrDefault(PlayListPos) != null)
                    {
                        WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                        count = 0;
                        foreach (object o in listItems.Items)
                        {
                            if (count == PlayListPos)
                                listItems.SelectedItem = o;
                            count = count + 1;
                        }
                    }
                    else
                    {
                        if (list.ElementAtOrDefault(0) != null)
                        {
                            PlayListPos = 0;
                            WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                            count = 0;
                            foreach (object o in listItems.Items)
                            {
                                if (count == PlayListPos)
                                    listItems.SelectedItem = o;
                                count = count + 1;
                            }
                        }
                        else
                            WmPlayer.Source = null;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }
    }
}
