using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    float shake = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.3f;
    float defaultAmount;
    public float decreaseFactor = 1.0f;
    public float shakeTime = 0.5f;
    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }

        OnEnable();
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
        defaultAmount = shakeAmount;
    }

    void Update()
    {
        if (shake > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0f;
            shakeAmount = defaultAmount;
            camTransform.localPosition = originalPos;
        }
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Hit"))
    //    {
    //        shake = shakeTime;
    //    }
    //}

    public void Shake(float quakePower,float quakeTime)
    {
        shakeAmount = quakePower;
        shake = quakeTime;
    }

    public void Shake()
    {
        shake = shakeTime;
    }
}