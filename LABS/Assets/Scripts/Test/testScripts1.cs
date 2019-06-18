using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testScripts1 : MonoBehaviour
{
    [SerializeField] GameObject obj = null; //inspector
    [SerializeField] Transform parentObj = null; // inspector
    float spawnTime = 0.0f;
    float spawnInterval = 2.0f;
    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnInterval)
        {
            spawnTime = 0.0f;
            Instantiate(obj, parentObj.position, parentObj.rotation, parentObj);
        }
    }
}
