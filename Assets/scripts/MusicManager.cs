using UnityEngine;
using System.Collections;

public class MusicManager
{
    AudioSource m_song;
    ulong m_delay;
    MusicManager(AudioSource song)
    {
        m_song = song


    }

    void playSong(int songNum)
    {

        m_song.Play(m_delay);
    }

    //delay is measured in seconds
    void playSong(int songNum, ulong delay)
    { m_song.Play(delay); }

    void stopSong(int songNum)
    { m_song.Stop(); }
}
