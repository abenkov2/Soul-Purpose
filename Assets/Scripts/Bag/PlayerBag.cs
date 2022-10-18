using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    public GameObject Bag;
    bool isOpen;
    private void Awake()
    {
        Bag.SetActive(false);
    }
    public void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            Bag.SetActive(isOpen);
        }
    }
}
