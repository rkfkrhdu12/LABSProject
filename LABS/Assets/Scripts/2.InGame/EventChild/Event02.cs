using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event02 : Event
{
    [SerializeField]
    SpriteRenderer[] dangerPizza = new SpriteRenderer[5];
    Transform[] playPizza = new Transform[5];

    [SerializeField]
    Sprite pizzaImage; // inspector
    public override void Start()
    {
        base.Start();

        for (int i = 0; i < 5; i++)
        {
            dangerPizza[i] = Config[(int)eConfig.DANGER].transform.GetChild(i).GetComponent<SpriteRenderer>();

            playPizza[i] = Config[(int)eConfig.PLAY].transform.GetChild(i);
        }

    }

    public override void DangerStart()
    {
        base.DangerStart();

        pizzaCount = 0;
    }

    float pizzaTime = 0.0f;
    [SerializeField]
    float pizzaInterval = .5f;
    [SerializeField]
    int pizzaCount = 0;
    public override void DangerUpdate()
    {
        base.DangerUpdate();
        pizzaTime += Time.deltaTime;
        if (pizzaTime >= pizzaInterval)
        {
            pizzaTime = 0;
            dangerPizza[pizzaCount++].sprite = pizzaImage;
        }
    }

    public override void PlayStart()
    {
        base.PlayStart();
    }

    public override void PlayUpdate()
    {
        base.PlayUpdate();

        for (int i = 0; i < 5; i++)
        {
            Vector3 dir = player.transform.position - playPizza[i].position;
            
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            playPizza[i].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public override void EventEnd()
    {
        base.EventEnd();

        for (int i = 0; i < 5; i++) 
        {
            dangerPizza[i].sprite = nullSprite;
        }
    }
}
