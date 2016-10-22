using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    AudioSource[] m_songs;
   //ulong m_delay;
    void Start()
    {m_songs = gameObject.GetComponents<AudioSource>();}


    void playSong(int songNum)
    {m_songs[songNum].Play(0);}

    //delay is measured in seconds
    void playSong(int songNum, ulong delay)
    { m_songs[songNum].Play(delay); }

    void stopSong(int songNum)
    {m_songs[songNum].Stop();}
}
