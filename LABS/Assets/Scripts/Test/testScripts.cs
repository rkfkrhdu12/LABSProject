using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testScripts : MonoBehaviour
{
    public SpriteRenderer a;
    Color c;
    bool isOn = false;
    float timer = 0;
    public float Timer = 2;
    
    void Start()
    {
        c = a.color;
        c.a = 0;
        a.color = c;
    }

    public void Update()
    {
        a.color = c;
        if (isOn)
        {
            if (c.a >= 1)
            {
                c.a = 1;
            }
            else
            {
                timer += Time.deltaTime;
                c.a += Time.deltaTime / Timer;
            }
        }
        Debug.Log((int)timer + "   "  + c);

    }

    public void U()
    {
        if (isOn)
        {
            c = a.color;
            c.a = 0;
            a.color = c;

            isOn = false;
        }
        else
        {
            isOn = true;
        }
    }
}
