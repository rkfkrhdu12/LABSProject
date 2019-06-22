using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event03 : Event
{
    Transform[] dangerConfig = new Transform[2];
    enum eDangerConfig
    {
        Update,
        End,
    }
    [SerializeField] eDangerConfig curDangerState = eDangerConfig.Update;

    [SerializeField] SpriteRenderer[] dangerImage = new SpriteRenderer[11];
    int dangerLeftFrog = 9;
    [SerializeField] Sprite[] rightFrogSprite = new Sprite[2]; // inspector
    int dangerRightFrog = 10;
    [SerializeField] Sprite[] leftFrogSprite = new Sprite[2]; // inspector
    Color imageColor;
    [SerializeField] float alphaTimeInterval = 2;

    [SerializeField] ScreenShake scnShake = null;

    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < Config[(int)eConfig.DANGER].transform.childCount; ++i)
        {
            dangerConfig[i] = Config[(int)eConfig.DANGER].transform.GetChild(i);
        }

        imageColor = new Color(1, 1, 1, 1);
        imageColor.a = 0;

        curDangerState = eDangerConfig.Update;

        for (int i = 0; i < dangerConfig[(int)eDangerConfig.Update].childCount; ++i)
        {
            dangerImage[i] = dangerConfig[(int)eDangerConfig.Update].GetChild(i).GetComponent<SpriteRenderer>();
            dangerImage[i].color = imageColor;
        }
    }

    public override void DangerStart()
    {
        base.DangerStart();

        curDangerState = eDangerConfig.Update;

        dangerConfig[(int)eDangerConfig.Update].gameObject.SetActive(true);
        dangerConfig[(int)eDangerConfig.End].gameObject.SetActive(false);
    }

    public override void DangerUpdate()
    {
        base.DangerUpdate();

        switch (curDangerState)
        {
            case eDangerConfig.Update:
                imageColor.a += Time.deltaTime / alphaTimeInterval;

                for (int i = 0; i < dangerConfig[(int)eDangerConfig.Update].childCount; ++i)
                {
                    dangerImage[i].color = imageColor;
                }

                if (imageColor.a >= 1)
                {
                    imageColor.a = 1;
                    curDangerState = eDangerConfig.End;
                }
                break;

            case eDangerConfig.End:
                dangerConfig[(int)eDangerConfig.End].gameObject.SetActive(true);
                dangerImage[dangerRightFrog].sprite = rightFrogSprite[1];
                dangerImage[dangerLeftFrog].sprite = leftFrogSprite[1];
                break;

        }
    }

    public override void PlayStart()
    {
        base.PlayStart();
        scnShake.Shake(.3f, 2f);
    }

    public override void PlayUpdate()
    {
        base.PlayUpdate();
    }

    public override void EventEnd()
    {
        imageColor = new Color(1, 1, 1, 1);
        imageColor.a = 0;

        dangerImage[dangerRightFrog].sprite = rightFrogSprite[0];
        dangerImage[dangerLeftFrog].sprite = leftFrogSprite[0];

        for (int i = 0; i < dangerConfig[(int)eDangerConfig.Update].childCount; ++i)
        {
            dangerImage[i].color = imageColor;
        }

        base.EventEnd();
    }

}