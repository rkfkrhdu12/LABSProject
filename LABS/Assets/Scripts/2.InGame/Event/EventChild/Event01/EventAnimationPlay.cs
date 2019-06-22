using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimationPlay : MonoBehaviour
{
    Animator ani;
    AudioPlayer audioPlayer;
    ScreenShake screenShaker;
    public bool isEnd = false;

    private void Start()
    {
        ani = GetComponent<Animator>();

        audioPlayer = GameObject.Find("AudioPlayer").GetComponent<AudioPlayer>();
        screenShaker = GameObject.Find("GroundColTrigger").GetComponent<ScreenShake>();
    }

    public void Play()
    {
        ani.SetTrigger("IsPlay");

        audioPlayer.PlaySound(AudioPlayer.eMusic.E01, GetComponent<AudioSource>());

        screenShaker.Shake();

        isEnd = false;
    }

    public void AnimationEnd()
    {
        isEnd = true;
    }
}
