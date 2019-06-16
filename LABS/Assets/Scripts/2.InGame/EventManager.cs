using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    List<Event> Events = new List<Event>();

    int prevEvent = 0;

    public HealKitManager healkitMgr;

    int eventCount = 0;
    int curEvent = 0;
    public enum eEventState
    {
        PLAY,
        END,
    }
    eEventState curState;

    float restTime = 0.0f;
    float restInterval = 4.0f;

    public Text ScoreText = null;      // Inspector
    int curScore = 0;
    int addScore = 1;

    public void Start()
    {
        eventCount = transform.childCount;

        for (int i = 0; i < eventCount; ++i)
        {
            Events.Add(transform.GetChild(i).GetComponent<Event>());
        }

        healkitMgr = GetComponent<HealKitManager>();

        Init();
    }
    
    public void Update()
    {
        switch (curState)
        {
            case eEventState.PLAY:
                if (Events[curEvent].curState == Event.ePlayEventState.PLAYEND)
                {
                    curState = eEventState.END;
                    healkitMgr.Create();
                }
                break;

            case eEventState.END:
                restTime += Time.deltaTime;
                if (restTime >= restInterval)
                {
                    restTime = 0.0f;

                    curScore += addScore;
                    ScoreText.text = curScore.ToString();

                    Init();
                }
                break;
        }
    }

    void Init()
    {
        curEvent = Random.Range(0, eventCount);
        while (true)
        {
            if (curEvent != prevEvent)
            {
                break;
            }
            curEvent = Random.Range(0, eventCount);
        }
        Debug.Log(curEvent + " " + eventCount);
        Events[curEvent].Reset();
        curState = eEventState.PLAY;
        prevEvent = curEvent;
    }
}
