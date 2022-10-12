using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Interactable
{
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Cav.SetActive(false);
        animator.Play("ghostUpAndDown");    
    }

    // Update is called once per frame
    void Update()
    {
        Event();
    }

    void Event()
    {
        if (Input.GetKeyDown(KeyCode.E) && (triggle == triggleType.Stay || triggle == triggleType.Enter))
        {
            Cav.SetActive(true);
            content.text = message;

            name.text = nameText != "" ? nameText : this.gameObject.name;
        }
        else if (triggle == triggleType.Leave)
        {
            Cav.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggle = triggleType.Enter;
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
