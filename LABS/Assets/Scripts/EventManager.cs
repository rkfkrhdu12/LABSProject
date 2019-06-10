using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    List<Event> Events = new List<Event>();
    int eventCount = 0;
    int curEvent = 0;
    public enum eEventState
    {
        START,
        PLAY,
        END,
    }
    eEventState curState;


    float restTime = 0.0f;
    float restInterval = 2.0f;


    public void Start()
    {
        eventCount = transform.childCount;

        for (int i = 0; i < eventCount; ++i)
        {
            Events.Add(transform.GetChild(i).GetComponent<Event>());
        }

        curEvent = Random.Range(0, eventCount - 1);
        Events[curEvent].Reset();
        curState = eEventState.PLAY;
    }
    
    public void Update()
    {
        switch (curState)
        {
            case eEventState.START:
                curEvent = Random.Range(0, eventCount - 1);
                Events[curEvent].Reset();
                curState = eEventState.PLAY;
                break;

            case eEventState.PLAY:
                if (Events[curEvent].curState == Event.ePlayEventState.PLAYEND) { curState = eEventState.END; }
                break;

            case eEventState.END:
                restTime += Time.deltaTime;
                if (restTime >= restInterval)
                {
                    restTime = 0.0f;
                    curState = eEventState.START;
                }
                break;
        }
    }
}
