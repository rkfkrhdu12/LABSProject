using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event06 : Event
{
    Vector3 tpPoint;
    Transform[] spawnPoint = new Transform[2];
    [SerializeField] GameObject leftGhost = null; // inspector
    [SerializeField] GameObject rightGhost = null; // inspector
    int spawnLeft = 0;
    int spawnRight = 1;

    [SerializeField] EventEndObj eventEndObj = null; // inspector

    public override void Awake()
    {
        base.Awake();

        spawnPoint[spawnLeft] = Config[(int)eConfig.PLAY].transform.GetChild(spawnLeft);
        spawnPoint[spawnRight] = Config[(int)eConfig.PLAY].transform.GetChild(spawnRight);

        tpPoint = Config[(int)eConfig.DANGER].transform.GetChild(0).position;
    }

    public override void DangerStart()
    {
        base.DangerStart();

        player.transform.position = tpPoint;
    }

    public override void PlayStart()
    {
        base.PlayStart();

        player.transform.position = Config[(int)eConfig.PLAY].transform.GetChild(2).position;

        spawnTime = spawnInterval;
    }

    float spawnTime = 0.0f;
    [SerializeField] float spawnInterval = 2.0f;
    public override void PlayUpdate()
    {
        base.PlayUpdate();
        
        if(eventEndObj.IsEnd())
        {
            playInterval = 0;
            eventEndObj.ReSet();
        }

        spawnTime += Time.deltaTime;
        if(spawnTime >= spawnInterval)
        {
            spawnTime = 0.0f;
            Instantiate(leftGhost, spawnPoint[spawnLeft].position, spawnPoint[spawnLeft].rotation, spawnPoint[0]);
            GameObject clone = Instantiate(rightGhost, spawnPoint[spawnRight].position, spawnPoint[spawnRight].rotation, spawnPoint[1]);
            clone.GetComponent<EventGhost>().SetDirection(EventGhost.eGhostDir.RIGHT);
        }
    }

    public override void EventEnd()
    {
        for (int i = 0; i < spawnPoint[0].childCount; ++i)
        {
            Destroy(spawnPoint[0].GetChild(i).gameObject);
            Destroy(spawnPoint[1].GetChild(i).gameObject);
        }

        playInterval = 99999;

        base.EventEnd();
    }
}
