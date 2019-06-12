using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealKitManager : MonoBehaviour
{
    public GameObject healKit;
    int createCount = 3;
    
    int curCount = 0;
    public void Create()
    {
        curCount++;
        Debug.Log(curCount.ToString());

        if (curCount == createCount)
        {
            curCount = 0;
            Vector3 v = new Vector3(0, -1, 0);

            GameObject clone = Instantiate(healKit, v, Quaternion.identity, transform);
        }
    }
}
