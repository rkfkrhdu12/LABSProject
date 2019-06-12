using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] Config = new GameObject[2];
    protected enum eConfig
    {
        DANGER,
        PLAY,
    }

    //Vector3 defaultVector;

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

    virtual public void Start()
    {
        Config[(int)eConfig.DANGER] = transform.GetChild((int)eConfig.DANGER).gameObject;
        Config[(int)eConfig.PLAY] = transform.GetChild((int)eConfig.PLAY).gameObject;

        //defaultVector = Config[1].transform.position;

        dangerTime = 0.0f;
        playTime = 0.0f;
    }

    public void Reset()
    {
        curState = ePlayEventState.DANGERSTART;
    }

    public void Update()
    {
        switch(curState)
        {
            case ePlayEventState.DANGERSTART:
                DangerStart();

                curState = ePlayEventState.DANGER;
                break;

            case ePlayEventState.DANGER:
                dangerTime += Time.deltaTime;
                if (dangerTime >= dangerInterval)
                {
                    dangerTime = 0;

                    DangerUpdate();

                    curState = ePlayEventState.PLAY;
                }
                break;

            case ePlayEventState.PLAY:
                playTime += Time.deltaTime;
                if (playTime >= playInterval)
                {
                    playTime = 0.0f;

                    PlayUpdate();

                    curState = ePlayEventState.PLAYEND;
                }
                break;
        }
    }

    virtual public void DangerStart()
    {
        Config[(int)eConfig.DANGER].SetActive(true);
        Config[(int)eConfig.PLAY].SetActive(false);
    }

    virtual public void DangerUpdate()
    {
        Config[(int)eConfig.DANGER].SetActive(false);
        Config[(int)eConfig.PLAY].SetActive(true);
    }

    virtual public void PlayUpdate()
    {
        
    }
}
