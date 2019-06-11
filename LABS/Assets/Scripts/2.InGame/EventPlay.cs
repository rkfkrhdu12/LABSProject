using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlay : MonoBehaviour
{
    EventAnimationPlay ani;
    bool isAniPlay = false;

    Rigidbody2D rigid;

    private void Start()
    {
        ani = transform.GetChild(0).GetComponent<EventAnimationPlay>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isAniPlay && ani.isEnd)
        {
            rigid.gravityScale = 1;
            isAniPlay = false;
            gameObject.SetActive(false);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !isAniPlay) 
        {
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(0, 0);
            ani.Play();
            isAniPlay = true;
        }
    }
}
