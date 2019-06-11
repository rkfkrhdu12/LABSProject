using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScripts : MonoBehaviour
{
    Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("1");
            rig.gravityScale = 0;
            rig.velocity = new Vector2(0,0);
        }
    }
}
