﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event06 : Event
{
    Vector3 tpPoint;
    Transform[] spawnPoint = new Transform[2];

    int spawnLeft = 0;
    int spawnRight = 1;

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

    float spawnTime = 0.0f;
    [SerializeField] float spawnInterval = 2.0f;
    public override void PlayUpdate()
    {
        base.PlayUpdate();
        spawnTime += Time.deltaTime;
        if(spawnTime >= spawnInterval)
        {
            spawnTime = 0.0f;
        }
    }
}
