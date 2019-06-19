using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    List<Event> Events = new List<Event>();

    int prevEvent = 0;

    ScoreManager scoreMgr;

    int eventCount = 0;
    int curEvent = 0;
    public enum eEventState
    {
        PLAY,
        END,
    }
    public eEventState curState;

    float restTime = 0.0f;
    float restInterval = 4.0f;

    public void Init()
    {
        eventCount = transform.childCount;

        for (int i = 0; i < eventCount; ++i)
        {
            Events.Add(transform.GetChild(i).GetComponent<Event>());
        }

        scoreMgr = GameObject.Find("UI").GetComponent<ScoreManager>();
    }

    public void ReSet()
    {
        curState = eEventState.END;
        restTime = 0;

        for (int i = 0; i < eventCount; ++i) 
        {
            Events[i].ReSet();
        }
    }

    public void Start()
    {
        

        ReStart();
    }
    
    public void Update()
    {
        switch (curState)
        {
            case eEventState.PLAY:
                if (Events[curEvent].curState == Event.ePlayEventState.PLAYEND)
                {
                    curState = eEventState.END;
                    scoreMgr.curEvent = ScoreManager.eEventState.END;
                }
                break;

            case eEventState.END:
                restTime += Time.deltaTime;
                if (restTime >= restInterval)
                {
                    restTime = 0.0f;

                    ReStart();
                }
                break;
        }
    }

    void ReStart()
    {
        Events[curEvent].EventEnd();
        Events[curEvent].curState = Event.ePlayEventState.PLAYEND;

        curEvent = Random.Range(0, eventCount);
        while (eventCount != 1)
        {
            if (curEvent != prevEvent)
            {
                break;
            }
            curEvent = Random.Range(0, eventCount);
        }

        Events[curEvent].Reset();
        curState = eEventState.PLAY;
        scoreMgr.curEvent = ScoreManager.eEventState.START;
        prevEvent = curEvent;
    }


}
