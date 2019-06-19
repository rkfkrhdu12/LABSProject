using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public EventManager eventMgr;
    public ScoreManager scoreMgr;
    public PlayerController player;

    void Awake()
    {
        Init();
    }
    

    public bool isPlayerDead = false;
    void Update()
    {
        if(player.isDead)
        {
            isPlayerDead = true;
        }
    }

    public void Init()
    {
        eventMgr = transform.GetChild(0).GetComponent<EventManager>();
        eventMgr.Init();

        scoreMgr = transform.GetChild(1).GetComponent<ScoreManager>();
        scoreMgr.Init();

        player = transform.GetChild(2).GetComponent<PlayerController>();
        player.Init();

        isPlayerDead = false;
    }

    public void ReSet()
    {
        eventMgr.ReSet();
        scoreMgr.ReSet();
        player.ReSet();

        isPlayerDead = false;
    }

    public int GetScore()
    {
        return scoreMgr.GetScore();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
