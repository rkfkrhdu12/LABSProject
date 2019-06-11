using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject InGameScreen;

    public void StartButton()
    {
        InGameScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
