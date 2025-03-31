using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spin : MonoBehaviour
{
    
    [SerializeField] float speedRotate = 180f; 

    void Update()
    {
        transform.Rotate(0, 0, speedRotate * Time.deltaTime); 
    }
}
