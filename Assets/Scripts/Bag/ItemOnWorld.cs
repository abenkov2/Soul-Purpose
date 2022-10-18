using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem()
    {
        if (!playerInventory.ItemList.Contains(thisItem))
        {
            playerInventory.ItemList.Add(thisItem);
        }
        else
        {
            thisItem.itemNum++;
        }
        InventoryManager.ReFreshItem();
    }

}
