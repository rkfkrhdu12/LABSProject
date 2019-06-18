using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event05 : Event
{
    [SerializeField]
    Transform[] elk = new Transform[8];
    Vector3[] defaultPos = new Vector3[2];

    [SerializeField] float[] elkSpeed = new float[8];

    [SerializeField] float minSpeed = 7;
    [SerializeField] float maxSpeed = 14;

    [SerializeField] int elkCount = 4;
    [SerializeField] int curElkCount = 0;

    public override void Awake()
    {
        base.Awake();

        defaultPos[0] = Config[(int)eConfig.PLAY].transform.GetChild(0).position;
        defaultPos[1] = Config[(int)eConfig.PLAY].transform.GetChild(1).position;

        for (int i = 0; i < elkCount; ++i)
        {
            elk[i] = Config[(int)eConfig.PLAY].transform.GetChild(0).GetChild(i);
            elk[i + elkCount] = Config[(int)eConfig.PLAY].transform.GetChild(1).GetChild(i);
        }
    }

    public override void PlayStart()
    {
        for (int i = 0; i < elkCount; ++i)
        {
            elkSpeed[i] = Random.Range(minSpeed, maxSpeed);
            elkSpeed[i + elkCount] = Random.Range(minSpeed, maxSpeed);
        }
        spawnTime = 0;
        curElkCount = 0;
        base.PlayStart();
    }

    float spawnTime = 0.0f;
    float spawnInterval = 1.0f;
    public override void PlayUpdate()
    {
        base.PlayUpdate();

        if (curElkCount < elkCount)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime >= spawnInterval)
            {
                spawnTime = 0;
                curElkCount++;
            }
        }

        for (int i = 0; i < curElkCount; ++i)
        {
            elk[i].Translate(-elkSpeed[i] * Time.deltaTime, 0, 0);
            elk[i + elkCount].Translate(elkSpeed[i + elkCount] * Time.deltaTime, 0, 0);
        }

    }

    public override void EventEnd()
    {
        for (int i = 0; i < elkCount; ++i)
        {
            elk[i].position = defaultPos[0];
            elk[i + elkCount].position = defaultPos[1];
        }

        base.EventEnd();
    }
}
