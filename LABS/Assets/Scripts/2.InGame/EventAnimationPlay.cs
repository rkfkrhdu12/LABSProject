using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimationPlay : MonoBehaviour
{
    Animator ani;

    public bool isEnd = false;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Play()
    {
        ani.SetTrigger("IsPlay");
        isEnd = false;
    }

    public void AnimationEnd()
    {
        Debug.Log("1");
        GetComponent<BoxCollider2D>().size = Vector2.zero;
        isEnd = true;
    }
}
