using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eChobits {
    class Music {
        WMPLib.WindowsMediaPlayer player;
        WMPLib.IWMPPlaylist playlist;
        string[] songs;
        public Music() {
            player = new WMPLib.WindowsMediaPlayer();
            songs = System.IO.Directory.GetFiles(Application.StartupPath + "\\soundtracks");
            playlist = player.newPlaylist("playlist#1", "");
            foreach (string song in songs) playlist.appendItem(player.newMedia(song));
        }
        
        public void play() {
            if (player.currentPlaylist.count == 0) player.currentPlaylist = playlist;
            player.controls.play();
        }
        public void pause() { player.controls.pause(); }
        public void next() { player.controls.next(); }

    }
}
