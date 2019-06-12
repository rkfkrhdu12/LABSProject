using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event01 : Event
{
    Vector3 defaultVector;

    public override void Start()
    {
        base.Start();

        defaultVector = Config[(int)eConfig.PLAY].transform.position;
    }

    public override void DangerStart()
    {
        base.DangerStart();

        Config[(int)eConfig.PLAY].transform.position = defaultVector;
    }

    public override void DangerUpdate()
    {
        base.DangerUpdate();
    }

    public override void PlayUpdate()
    {
        base.PlayUpdate();
    }
}
