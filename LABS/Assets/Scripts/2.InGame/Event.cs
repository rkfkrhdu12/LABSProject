using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]
    GameObject[] Config = new GameObject[2];

    Vector3 defaultVector;

    public enum ePlayEventState
    {
        DANGERSTART,
        DANGER,
        PLAY,
        PLAYEND,
    }
    public ePlayEventState curState;

    float dangerTime = 0.0f;
    [SerializeField]
    float dangerInterval = 2.5f;

    float playTime = 0.0f;
    [SerializeField]
    float playInterval = 1.3f;

    void Start()
    {
        Config[0] = transform.GetChild(0).gameObject;
        Config[1] = transform.GetChild(1).gameObject;

        defaultVector = Config[1].transform.position;

        dangerTime = 0.0f;
        playTime = 0.0f;
    }

    public void Reset()
    {
        curState = ePlayEventState.DANGERSTART;
    }

    private void Update()
    {
        switch(curState)
        {
            case ePlayEventState.DANGERSTART:
                DangerStart();
                break;
            case ePlayEventState.DANGER:
                DangerUpdate();
                break;
            case ePlayEventState.PLAY:
                PlayUpdate();
                break;
        }
    }

    void DangerStart()
    {
        Config[0].SetActive(true);  // DangerSprite On
        Config[1].SetActive(false); // PlaySprite Off
        curState = ePlayEventState.DANGER;
    }

    void DangerUpdate()
    {
        dangerTime += Time.deltaTime;
        if (dangerTime >= dangerInterval)
        {
            dangerTime = 0.0f;
            Config[0].SetActive(false);
            Config[1].SetActive(true);
            Config[1].transform.position = defaultVector;
            curState = ePlayEventState.PLAY;
        }
    }

    void PlayUpdate()
    {
        playTime += Time.deltaTime;
        if (playTime >= playInterval)
        {
            playTime = 0.0f;
            curState = ePlayEventState.PLAYEND;
        }
    }
}
