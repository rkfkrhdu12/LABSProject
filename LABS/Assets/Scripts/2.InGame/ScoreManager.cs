using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    /*
     * 초당 10점
     * 풀피일때 힐킷먹으면 500점
     * 이벤트 안맞고 클리어시 200점
     */

    Text scoreText;
    int score;
    void Start()
    {
        Init();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        curEvent = eEventState.REST;
        isPlayerCol = false;
    }

    public eEventState curEvent;
    public enum eEventState
    {
        REST,
        START,
        COL,
        END,
    }
    bool isPlayerCol = false;

    float scoreTime = 0.0f;
    [SerializeField] float scoreInterval = 1f;
    void Update()
    {
        scoreTime += Time.deltaTime;
        if (scoreTime >= scoreInterval)
        {
            scoreTime = 0;
            isPlayerCol = false;
            score += 10;
        }

        EventUpdate();

        scoreText.text = score.ToString();
    }

    public void MaxHPEatHeal()
    {
        score += 500;
    }

    public void EventUpdate()
    {
        switch (curEvent)
        {
            case eEventState.START:
                isPlayerCol = false;
                break;

            case eEventState.COL:
                isPlayerCol = true;
                break;

            case eEventState.END:
                if (!isPlayerCol)
                {
                    score += 200;
                }
                curEvent = eEventState.REST;
                break;
        }

    }

    public int GetScore()
    {
        return score;
    }

    public void Init()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}