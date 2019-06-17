﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] StartManager    startMgr       = null; // inspector
    [SerializeField] InGameManager   inGameMgr      = null; // inspector
    [SerializeField] GameOverManager gameOverMgr    = null; // inspector

    private void Awake()
    {
        StartInit();
        InGameInit();
        GameOverInit();
    }

    void Update()
    {
        if(startMgr.isGameStart)
        {
            startMgr.isGameStart = false;
            startMgr.SetActive(false);

            inGameMgr.SetActive(true);
            inGameMgr.ReSet();
        }

        if(inGameMgr.isPlayerDead)
        {
            inGameMgr.isPlayerDead = false;
            inGameMgr.SetActive(false);

            gameOverMgr.SetActive(true);
            gameOverMgr.ReSet();
            gameOverMgr.ScoreStart(inGameMgr.GetScore());
        }

        if (gameOverMgr.isGoMainMenu)
        {
            gameOverMgr.isGoMainMenu = false;
            gameOverMgr.SetActive(false);

            startMgr.SetActive(true);
            startMgr.ReSet();
        }

        if (gameOverMgr.isReStart)
        {
            gameOverMgr.isReStart = false;
            gameOverMgr.SetActive(false);

            inGameMgr.SetActive(true);
            inGameMgr.ReSet();
        }
    }
    
    void StartInit()
    {
        startMgr.SetActive(true);
        startMgr.Init();
    }

    void InGameInit()
    {
        inGameMgr.SetActive(true);
        inGameMgr.Init();
        inGameMgr.SetActive(false);
    }

    void GameOverInit()
    {
        gameOverMgr.SetActive(true);
        gameOverMgr.Init();
        gameOverMgr.SetActive(false);
    }
}
