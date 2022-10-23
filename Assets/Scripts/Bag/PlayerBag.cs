using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    public static PlayerBag Instance;
    public GameObject Bag;
    bool isOpen;
    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance); 
        Instance = this;
        Bag.SetActive(false);
    }
    public void UseKeyboardToOpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryManager.ReFreshItem();
            isOpen = !isOpen;
            Bag.SetActive(isOpen);
        }
    }
    public void OpenMyBag()
    {
        if (!isOpen)
        {
            isOpen = !isOpen;
            Bag.SetActive(isOpen);
        }
    }
    public void CloseMyBag()
    {
        if (isOpen)
        {
            isOpen = !isOpen;
            Bag.SetActive(isOpen);
        }
    }
}
