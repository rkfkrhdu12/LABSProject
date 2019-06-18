using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEndObj : MonoBehaviour
{
    bool isEnd = false;

    private void Start()
    {
        ReSet();
    }

    public void ReSet()
    {
        isEnd = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isEnd = true;
        }
    }

    public bool IsEnd()
    {
        return isEnd;
    }
}
