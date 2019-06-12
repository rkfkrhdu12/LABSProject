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

        Config[(int)eConfig.PLAY].transform.position = new Vector3(transform.position.x, defaultVector.y);
    }

    public override void DangerUpdate()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, Config[(int)eConfig.DANGER].transform.position.y);
    }

}
