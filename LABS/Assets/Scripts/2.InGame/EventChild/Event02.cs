using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event02 : Event
{
    [SerializeField]
    SpriteRenderer[] dangerPizza = new SpriteRenderer[5];
    [SerializeField]
    Transform[] playPizza = new Transform[5];
    Vector3[] defaultPos = new Vector3[5];
    Quaternion[] defaultRot = new Quaternion[5];

    [SerializeField]
    Sprite pizzaImage; // inspector

    float pizzaTime = 0.0f;
    [SerializeField]
    float pizzaInterval = .5f;
    [SerializeField]
    int pizzaCount = 0;

    [SerializeField]
    float pizzaSpeed = 3;
    public override void Start()
    {
        base.Start();

        for (int i = 0; i < 5; i++)
        {
            dangerPizza[i] = Config[(int)eConfig.DANGER].transform.GetChild(i).GetComponent<SpriteRenderer>();

            playPizza[i] = Config[(int)eConfig.PLAY].transform.GetChild(i);
            defaultPos[i] = playPizza[i].transform.position;
            defaultRot[i] = playPizza[i].transform.rotation;
        }

    }

    public override void DangerStart()
    {
        base.DangerStart();

        pizzaCount = 0;
    }

    public override void DangerUpdate()
    {
        base.DangerUpdate();

        pizzaTime += Time.deltaTime;
        if (pizzaTime >= (pizzaInterval - .01f)) 
        {
            pizzaTime = 0;
            dangerPizza[pizzaCount++].sprite = pizzaImage;
        }
    }

    public override void PlayStart()
    {
        base.PlayStart();
    }

    [SerializeField]
    int playUpdateCount = 0;
    float pizzaAniTime = 0.0f;
    float pizzaAniInterval = 1f;
    public override void PlayUpdate()
    {
        base.PlayUpdate();

        for (int i = playUpdateCount; i < 5; i++)
        {
            Vector3 dir = player.transform.position - playPizza[i].position;
            
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            playPizza[i].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        pizzaAniTime += Time.deltaTime;
        if (pizzaAniTime >= (pizzaAniInterval - .01))
        {
            pizzaAniTime = 0;
            playUpdateCount++;
            playUpdateCount %= (int)playInterval;
        }

        for (int i = 0; i < playUpdateCount; ++i)
        {
            playPizza[i].Translate(pizzaSpeed * Time.deltaTime, 0, 0);
        }
    }

    public override void EventEnd()
    {
        base.EventEnd();

        for (int i = 0; i < 5; i++) 
        {
            dangerPizza[i].sprite = nullSprite;

            playPizza[i].transform.position = defaultPos[i];
            playPizza[i].transform.rotation = defaultRot[i];
        }
    }
}
