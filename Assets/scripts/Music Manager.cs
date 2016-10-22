using UnityEngine;
using System.Collections;

    public class MusicManager
    {
       AudioSource m_song;
       ulong m_delay;
    MusicManager(AudioSource song, ulong delay)
    {
        m_song = song;
        m_delay = delay;
    }

        void playSong()
          {m_song.Play(m_delay);}

        //delay is measured in seconds
        void playSong(ulong delay)
          {m_song.Play(delay);}

        void stopSong()
          {m_song.Stop();}
    }
