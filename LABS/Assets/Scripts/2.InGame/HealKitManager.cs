using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealKitManager : MonoBehaviour
{
    public GameObject healKit;

    public void Create()
    {
        Vector3 v = new Vector3(0, -1, 0);

        GameObject clone = Instantiate(healKit, v, Quaternion.identity, transform);
    }
}
