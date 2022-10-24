using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour
{
    static bool isA, isD, isJumped;
    public Canvas canvas;
    // Update is called once per frame
    void Update()
    {
        if(isA && isD && isJumped)
        {
            canvas.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumped = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isA = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isD = true;
        }
    }
}
