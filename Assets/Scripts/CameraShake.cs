using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   [SerializeField] float shakeDuration = 1f;
   [SerializeField] float shakeMagnitude = 0.5f;
   Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {   
        float elapsedTime = 0;
        while(elapsedTime < shakeDuration)
        {
             transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude; //transform.position là vector3
                                                                                                  //nên đổi (cast) thành insideUnitSphere hoặc gán thành vector3
             elapsedTime += Time.deltaTime;    
             yield return new WaitForEndOfFrame();                                                                                 
        }
        transform.position = initialPosition;
       



    }
}
