using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGhost : MonoBehaviour
{
    [SerializeField] eGhostDir dir = eGhostDir.LEFT;
    public enum eGhostDir
    {
        LEFT,
        RIGHT
    }

    private void Awake()
    {
        dir = eGhostDir.LEFT;

    }

    public void Start()
    {
        SpeedInit();
    }

    [SerializeField] float speed = 5.9999f;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Direction())
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(eGhostDir direction)
    {
        dir = direction;
        SpeedInit();
    }

    void SpeedInit()
    {
        if (dir == eGhostDir.LEFT)
        {
            speed = -speed;
        }
    }

    string Direction()
    {
        if (dir == eGhostDir.LEFT)
            return "LeftEnd";
        else
            return "RightEnd";

    }
}
