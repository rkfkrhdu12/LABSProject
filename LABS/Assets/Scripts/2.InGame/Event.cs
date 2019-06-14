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

    protected GameObject player;

    public enum ePlayEventState
    {
        DANGERSTART,
        DANGER,
        PLAY,
        PLAYEND,
    }
    public ePlayEventState curState;

    protected float dangerTime = 0.0f;
    [SerializeField]
    protected float dangerInterval = 2.5f;

    protected float playTime = 0.0f;
    [SerializeField]
    protected float playInterval = 1.0f;

    protected float playOnTime = 0.0f;
    [SerializeField]
    protected float playOnInterval = .1f;

    [SerializeField]
    protected Sprite nullSprite; // inspector

    virtual public void Start()
    {
        player = GameObject.Find("Player").gameObject;

        Config[(int)eConfig.DANGER] = transform.GetChild((int)eConfig.DANGER).gameObject;
        Config[(int)eConfig.PLAY] = transform.GetChild((int)eConfig.PLAY).gameObject;

        dangerTime = 0.0f;
        playTime = 0.0f;
    }

    public void Reset()
    {
        curState = ePlayEventState.DANGERSTART;
    }

    public virtual void Update()
    {
        switch(curState)
        {
            case ePlayEventState.DANGERSTART:
                DangerStart();

                break;

            case ePlayEventState.DANGER:
                dangerTime += Time.deltaTime;
                DangerUpdate();
                if (dangerTime >= dangerInterval)
                {
                    PlayStart();
                }
                break;

            case ePlayEventState.PLAY:
                playTime += Time.deltaTime;
                PlayUpdate();
                if (playTime >= playInterval)
                {
                    playTime = 0.0f;

                    EventEnd();

                    curState = ePlayEventState.PLAYEND;
                }
                break;
        }
    }

    virtual public void DangerStart()
    {
        Config[(int)eConfig.DANGER].SetActive(true);
        Config[(int)eConfig.PLAY].SetActive(false);


        curState = ePlayEventState.DANGER;
    }

    virtual public void DangerUpdate()
    {

    }
    
    virtual public void PlayStart()
    {
        playOnTime += Time.deltaTime;
        if (playOnTime >= playOnInterval)
        {
            Config[(int)eConfig.PLAY].SetActive(true);
            Config[(int)eConfig.DANGER].SetActive(false);

            playOnTime = 0;
            dangerTime = 0;

            curState = ePlayEventState.PLAY;
        }
    }

    virtual public void PlayUpdate()
    {
        
    }

    virtual public void EventEnd()
    {

    }
}
