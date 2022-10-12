using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        Cav.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Event();
    }

    void Event()
    {
        Debug.Log(triggle);
        if (Input.GetKeyDown(KeyCode.E) && triggle == triggleType.Stay)
        {
            Cav.SetActive(true);
            content.text = message;
            name.text = nameText != null ? nameText : this.gameObject.name;
        }
        else if (triggle == triggleType.Leave)
        {
            Cav.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggle = triggleType.Stay;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggle = triggleType.Leave;
        }
    }
}
