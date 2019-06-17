using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Text highScoreText = null;
    [SerializeField] Text curScoreText = null;

    void Awake()
    {
        Init();
        ReSet();
    }

    bool isNew = false;
    public void ScoreStart(int score)
    {
        if(PlayerPrefs.GetInt("Score") < score)
        {
            PlayerPrefs.SetInt("Score", score);
            isNew = true;
        }
        curScoreText.text = score.ToString();
        highScoreText.text = (isNew ? "New " : "") + PlayerPrefs.GetInt("Score").ToString();
    }

    public bool isReStart = false;
    public void ReStartButton() { isReStart = true; }

    public bool isGoMainMenu = false;
    public void MainMenuButton() { isGoMainMenu = true; }

    public void Init()
    {
        curScoreText = transform.GetChild(0).gameObject.GetComponent<Text>();
        highScoreText = transform.GetChild(1).gameObject.GetComponent<Text>();

        SetActive(false);
    }

    public void ReSet()
    {
        isReStart = false;
        isGoMainMenu = false;
        isNew = false;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
