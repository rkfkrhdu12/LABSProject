using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlay : Object
{
    EventAnimationPlay ani;
    bool isAniPlay = false;

    override protected void Start()
    {
        base.Start();

        ani = transform.GetChild(0).GetComponent<EventAnimationPlay>();
    }

    void Update()
    {
        if(isAniPlay && ani.isEnd)
        {
            rigid.gravityScale = gravityPower;
            isAniPlay = false;
            gameObject.SetActive(false);
        }
    }


    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Ground") && !isAniPlay) 
        {
            ani.Play();
            isAniPlay = true;
        }
    }
}
