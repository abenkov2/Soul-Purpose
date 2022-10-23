using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public static string lastItemName; //must be static
    public Inventory myBag;
    public void itemOnClicked()
    {
        lastItemName = slotItem.itemName;
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
    
}
