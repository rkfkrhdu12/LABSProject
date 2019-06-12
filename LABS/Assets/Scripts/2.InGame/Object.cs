using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected float gravityPower;
    virtual protected void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        gravityPower = rigid.gravityScale;
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(0, 0);
        }
    }

    virtual protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            rigid.gravityScale = gravityPower;
        }
    }
}