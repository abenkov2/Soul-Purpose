using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    static string slotName; //must be static
    public Inventory myBag;
    public void itemOnClicked()
    {
        slotName = slotItem.itemName;
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
        
    }
    public void UseOnClicked()
    {
        for (int i = 0; i < myBag.ItemList.Count; i++)
        {
            if (myBag.ItemList[i].itemNum > 0 && myBag.ItemList[i].itemName == slotName)
            {
                myBag.ItemList[i].itemNum--;
                break;
            }
        }
        InventoryManager.ReFreshItem();
    }

}
