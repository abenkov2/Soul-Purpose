using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
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
        if (!InventoryManager.instance.myBag.ItemList.Contains(thisItem))
        {
            InventoryManager.instance.myBag.ItemList.Add(thisItem);
            thisItem.itemNum = 1;
        }
        else
        {
            thisItem.itemNum ++;
        }
        InventoryManager.ReFreshItem();
    }
    public void AddNewItem(Item newItem)
    {
        if (!InventoryManager.instance.myBag.ItemList.Contains(newItem))
        {
            InventoryManager.instance.myBag.ItemList.Add(newItem);
            newItem.itemNum = 1;
        }
        else
        {
            newItem.itemNum ++;
        }
        InventoryManager.ReFreshItem();
    }

}
