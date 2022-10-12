using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public GameObject talkUI;
    public GameObject button;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        button.SetActive(false);
        talkUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            talkUI.SetActive(true);
        }
    }
}
