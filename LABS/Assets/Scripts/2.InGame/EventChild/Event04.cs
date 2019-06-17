using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event04 : Event
{
    [SerializeField]
    Transform[] bug = new Transform[12];
    [SerializeField]
    float[] bugSpeed = new float[12];

    public override void Awake()
    {
        base.Awake();

        int childNumber = 0;
        int countNumber = 0;
        for (int i = 0; i < 12; ++i, ++countNumber) 
        {
            if(i == 6)
            {
                countNumber = 0;
                childNumber++;
            }

            bug[i] = Config[(int)eConfig.PLAY].transform.GetChild(childNumber).GetChild(countNumber);
        }
    }

    public override void PlayStart()
    {
        for (int i = 0; i < 12; ++i)
        {
            bugSpeed[i] = Random.Range(3, 10);
        }

        base.PlayStart();
    }

    public override void PlayUpdate()
    {
        base.PlayUpdate();

        for (int i = 0; i < 12; ++i)
        {
            if (i < 6)
            {
                bug[i].Translate(-bugSpeed[i] * Time.deltaTime, 0, 0);
            }
            else
            {
                bug[i].Translate(bugSpeed[i] * Time.deltaTime, 0, 0);
            }
        }

    }
}
