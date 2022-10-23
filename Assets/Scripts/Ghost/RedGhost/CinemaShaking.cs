using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemaShaking : MonoBehaviour
{
    CinemachineImpulseSource myImpulse;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CinemaShake()
    {
        myImpulse = GetComponent<CinemachineImpulseSource>();
        myImpulse.GenerateImpulse(); //ÆÁÄ»Õð¶¯
    }
}
