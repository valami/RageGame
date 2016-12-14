using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System;

namespace RageGame
{
    static class Music
    {
        static string Last;

        static WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        static WMPLib.WindowsMediaPlayer playerjump = new WMPLib.WindowsMediaPlayer();
        static WMPLib.WindowsMediaPlayer playerdead = new WMPLib.WindowsMediaPlayer();

        static public void PlayMenu()
        {
            player.controls.stop();
            player.URL = "menu.mp3";
            player.controls.play();
        }

        static public void PlayEnd()
        {
            player.controls.stop();
            player.URL = "menu.mp3";
            player.controls.play();
        }

        static public void PlayLevel(string URL)
        {
            if (Last != URL)
            {
                playerdead.controls.stop();
                player.controls.stop();
                player.URL = URL;
                player.controls.play();
                Last = URL;
            }
        }
        static public void PlayJump()
        {
            //playerjump.controls.stop();
            //playerjump.URL = "ugras.mp3";
            //playerjump.controls.play();
        }
        static public void PlayDead()
        {
            player.controls.stop();
            playerdead.controls.stop();
            playerdead.URL = "halal.mp3";
            playerdead.controls.play();
        }
    }
}
