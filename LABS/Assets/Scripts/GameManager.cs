using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start
    StartManager startMgr;
    // InGame
    InGameManager inGameMgr;

    EventManager eventMgr;
    ScoreManager scoreMgr;
    PlayerController player;

    [SerializeField] GameObject StartScreen; // inspector
    [SerializeField] GameObject InGameScreen; // inspector
    [SerializeField] GameObject GameOverScreen; // inspector

    void Start()
    {
        StartScreen.SetActive(true);
        startMgr = StartScreen.GetComponent<StartManager>();

        InGameScreen.SetActive(true);
        inGameMgr = InGameScreen.GetComponent<InGameManager>();

        eventMgr = inGameMgr.eventMgr;
        scoreMgr = inGameMgr.scoreMgr;
        player = inGameMgr.player;
    }

    // Update is called once per frame
    void Update()
    {
        if(startMgr.isGameStart)
        {
            StartScreen.SetActive(false);
            InGameScreen.SetActive(true);
        }
    }
}
