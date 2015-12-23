using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;

namespace MyWindowsMediaPlayer
{
    public partial class WindowsMediaPlayer : MetroWindow
    {
        private void DragDrop(object sender, DragEventArgs e)
        {
            string[] file;

            try
            {
                file = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string data in file)
                {
                    if (ValidateMediaItem(data))
                    {
                        list.Add(new File(@data));
                        numberItems = numberItems + 1;
                    }
                }
                if (numberItems > 0)
                    listItems.Items.Clear();
                foreach (File toAdd in list)
                {
                    listItems.Items.Add(toAdd);
                }
                e.Handled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }

        private void ChooseItem(object sender, MouseEventArgs e)
        {
            try
            {
                if (listItems.SelectedItem != null && numberItems > 0)
                {
                    PlayListPos = listItems.SelectedIndex;
                    WmPlayer.Source = new Uri(list[PlayListPos].getUri);
                    mediaPlayerIsPlaying = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error.Message);
            }
        }

    }
}
