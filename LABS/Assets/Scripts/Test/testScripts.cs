using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScripts : MonoBehaviour
{

    public Transform target;
    void Update()
    {
        Vector3 dir = target.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-5*Time.deltaTime, 0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(5 * Time.deltaTime, 0,0);
        }
               
    }
}
