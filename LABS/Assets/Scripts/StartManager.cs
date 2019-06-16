using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    [SerializeField] GameObject defaultScr;
    [SerializeField] GameObject infoScr;

    eStartState curState;
    enum eStartState
    {
        DEFAULT,
        INFO,
        START,
    }

    float gameStartTime = 0.0f;
    float gameStartInterval = 2.0f;
    public bool isGameStart = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        switch(curState)
        {
            case eStartState.INFO:
                gameStartTime += Time.deltaTime;
                if (gameStartTime >= gameStartInterval)
                {
                    curState = eStartState.START;
                }
                break;
            case eStartState.START:
                isGameStart = true;
                break;
        }
    }

    public void StartButton()
    {
        defaultScr.SetActive(false);
        infoScr.SetActive(true);
        curState = eStartState.INFO;
    }

    public void ExitButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void Init()
    {
        curState = eStartState.DEFAULT;
        defaultScr.SetActive(true);
        infoScr.SetActive(false);
    }
}
