
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class RedGhost : MonoBehaviour
{
    public Text timeText;
    public Text DoorStatusText;
    public float timeMax = 10;
    float timer;
    bool isTimeOut;
    int buttonInteractionNum = 0;
    bool isDoorOpen;
    CinemachineImpulseSource myImpulse;
    // Start is called before the first frame update
    void Start()
    {
        myImpulse = GetComponent<CinemachineImpulseSource>();
        timer = timeMax;
        isTimeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDoorOpen)
        {
            CountDown();
            ScreenShake();
            DoorCheck();
        } 
    }
    void CountDown()
    {
        if (!isTimeOut)
        {
            timer -= Time.deltaTime;
            timeText.text = timer.ToString("F2");
            if (timer <= 0)
            {
                isTimeOut = true;
            }
        }
    }
    void ScreenShake()
    {
        myImpulse.GenerateImpulse();
    }
    void DoorCheck()
    {
        if(buttonInteractionNum >= 3 || isTimeOut)
        {
            isDoorOpen = true;
        }
        DoorStatusText.text = isDoorOpen ? "Open" : "Close";
    }
    public void ResetButtonOnclick()
    {
        timer = timeMax;
        buttonInteractionNum++;
    }
}
