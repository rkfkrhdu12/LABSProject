using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event02 : Event
{
    SpriteRenderer[] dangerPizza = new SpriteRenderer[5];

    Transform[] playPizza = new Transform[5];
    Vector3[] defaultPos = new Vector3[5];
    Quaternion[] defaultRot = new Quaternion[5];

    int maxPizzaCount = 5;

    [SerializeField]
    Sprite pizzaImage = null; // inspector

    float pizzaTime = 0.0f;
    [SerializeField]
    float pizzaInterval = 0;
    int pizzaCount = 0;

    [SerializeField]
    float pizzaSpeed = 3;
    public override void Start()
    {
        base.Start();

        pizzaInterval = dangerInterval / 5.0f;
        
        for (int i = 0; i < maxPizzaCount; i++)
        {
            dangerPizza[i] = Config[(int)eConfig.DANGER].transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>();

            dangerPizza[i].sprite = nullSprite;

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
            pizzaCount %= 5;
        }

        for (int i = 0; i < pizzaCount; i++)
        {
            Vector3 dir = player.transform.position - dangerPizza[i].transform.parent.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dangerPizza[i].transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public override void PlayStart()
    {
        for (int i = 0; i < maxPizzaCount; ++i)
        {
            playPizza[i].transform.rotation = dangerPizza[i].transform.parent.rotation;
        }

        playUpdateCount = 0;
        pizzaAniTime = 0;

        base.PlayStart();
    }

    int playUpdateCount = 0;
    float pizzaAniTime = 0.0f;
    [SerializeField]
    float pizzaAniInterval = 1f;
    public override void PlayUpdate()
    {
        base.PlayUpdate();
        
        for (int i = playUpdateCount; i < maxPizzaCount; i++)
        {
            Vector3 dir = player.transform.position - playPizza[i].position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            playPizza[i].rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        pizzaAniTime += Time.deltaTime;
        if (pizzaAniTime >= (pizzaAniInterval - .01))
        {
            pizzaAniTime = 0;
            if (maxPizzaCount <= playUpdateCount)
            {
                playUpdateCount = maxPizzaCount;
            }
            else
            {
                playUpdateCount++;
            }
        }

        for (int i = 0; i < playUpdateCount; ++i)
        {
            playPizza[i].Translate(pizzaSpeed * Time.deltaTime, 0, 0);
        }
    }

    public override void EventEnd()
    {
        for (int i = 0; i < 5; i++) 
        {
            dangerPizza[i].sprite = nullSprite;

            playPizza[i].transform.position = defaultPos[i];
            playPizza[i].transform.rotation = defaultRot[i];
        }

        base.EventEnd();
    }
    
}
