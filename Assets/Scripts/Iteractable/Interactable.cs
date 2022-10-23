using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interactable : MonoBehaviour
{
    public bool trigger;
    public Text tip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            trigger = false;
        }
    }
    void OpenTip()
    {
        tip.gameObject.SetActive(true);
    }
    void CloseTip()
    {
        tip.gameObject.SetActive(false);
    }
    public void TipTextManager()
    {
        if (trigger)
        {
            OpenTip();
        }
        else
        {
            CloseTip();
        }
    }
    public void SetTipText(string text)
    {
        tip.text = text;
    }
}
