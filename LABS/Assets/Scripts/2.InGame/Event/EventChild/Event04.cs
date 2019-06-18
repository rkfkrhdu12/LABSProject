using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event04 : Event
{
    Transform[] bug = new Transform[12];
    Vector3[] defaultPos = new Vector3[2];

    float[] bugSpeed = new float[12];

    [SerializeField] float minSpeed = 7;
    [SerializeField] float maxSpeed = 14;

    [SerializeField] int bugCount = 6;

    public override void Awake()
    {
        base.Awake();

        defaultPos[0] = Config[(int)eConfig.PLAY].transform.GetChild(0).position;
        defaultPos[1] = Config[(int)eConfig.PLAY].transform.GetChild(1).position;
        
        for (int i = 0; i < bugCount; ++i) 
        {
            bug[i] = Config[(int)eConfig.PLAY].transform.GetChild(0).GetChild(i);
            bug[i + bugCount] = Config[(int)eConfig.PLAY].transform.GetChild(1).GetChild(i);
        }
    }

    public override void PlayStart()
    {
        for (int i = 0; i < bugCount; ++i)
        {
            bugSpeed[i] = Random.Range(minSpeed, maxSpeed);
            bugSpeed[i + bugCount] = Random.Range(minSpeed, maxSpeed);
        }

        base.PlayStart();
    }

    public override void PlayUpdate()
    {
        base.PlayUpdate();

        for (int i = 0; i < bugCount; ++i)
        {
            bug[i].Translate(-bugSpeed[i] * Time.deltaTime, 0, 0);
            bug[i + bugCount].Translate(bugSpeed[i + bugCount] * Time.deltaTime, 0, 0);
            
        }

    }

    public override void EventEnd()
    {
        for (int i = 0; i < bugCount; ++i)
        {
            bug[i].position = defaultPos[0];
            bug[i + bugCount].position = defaultPos[1];
        }

        base.EventEnd();
    }
}
