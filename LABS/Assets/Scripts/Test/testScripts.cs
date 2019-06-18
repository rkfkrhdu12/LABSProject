using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testScripts : MonoBehaviour
{
    [SerializeField] eGhostDir dir = eGhostDir.LEFT;
    enum eGhostDir
    {
        LEFT,
        RIGHT
    }

    private void Awake()
    {
        dir = eGhostDir.LEFT;

        SpeedInit();
    }

    [SerializeField] float speed = 3;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == Direction())
        {
            Destroy(gameObject);
        }
    }

    void SpeedInit()
    {
        if (dir == eGhostDir.LEFT)
        {
            speed = 3;
        }
        else
        {
            speed = -3;
        }
    }

    string Direction()
    {
        if(dir == eGhostDir.LEFT)
            return "LeftEnd";
        else
            return "RightEnd";

    }
}
