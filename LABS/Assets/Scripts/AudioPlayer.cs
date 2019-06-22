using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] music = new AudioClip[5];
    public enum eMusic
    {
        BG,
        E01,
        E02,
        E03,
        E05,
    }
    
    public void PlaySound(eMusic clipCount, AudioSource audioPlayer, bool isLoop = false)
    {
        audioPlayer.clip = music[(int)clipCount];
        audioPlayer.loop = isLoop;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}
