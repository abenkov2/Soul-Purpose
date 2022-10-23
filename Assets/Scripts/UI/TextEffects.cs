using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffects : MonoBehaviour
{
    string inputText;
    Text tex;
    int speed = 0;   //调整这个可以调整出现的速度
    int index = 0;
    string str1 = "";
    bool ison = true;

    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<Text>();
        inputText = tex.text;
        tex.text = "";
        speed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (ison)
        {
            speed --;
            if (speed <= 0)
            {
                if (index >= inputText.Length)
                {
                    ison = false;
                    return;
                }
                str1 = str1 + inputText[index].ToString();
                tex.text = str1;
                index += 1;
                speed = 15;
            }
        }
    }
}