using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Inventory myBag ;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInfo;

    Chest chest;
    private void Awake()
    {
        chest = FindObjectOfType<Chest>();
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void OnEnable()
    {
        ReFreshItem();
        instance.itemInfo.text = "";
    }
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfo.text = itemDescription;
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemNum.ToString();
    }
    public static void DestroyItem(Item item)
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            GameObject gameObject = instance.slotGrid.transform.GetChild(i).gameObject;
            if(gameObject.name == item.itemName)
            {
                Destroy(gameObject);
                break;
            }
        }
    }
    public static void ReFreshItem()
    {
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.myBag.ItemList.Count; i++)
        {
            if (instance.myBag.ItemList[i].itemNum > 0)
            {
                CreateNewItem(instance.myBag.ItemList[i]);
            }
            else
            {
                UpdateItemInfo("");
            }
        }
        for (int i = 0; i < instance.myBag.ItemList.Count; i++)
        {

            if (instance.myBag.ItemList[i].itemNum <= 0)
            {
                instance.myBag.ItemList.Remove(instance.myBag.ItemList[i]);
            }
        }
    }
    public void UseOnClicked()
    {
        for (int i = 0; i < myBag.ItemList.Count; i++)
        {
            if (myBag.ItemList[i].itemNum > 0 && myBag.ItemList[i].itemName == Slot.lastItemName)
            {
                EventManager(myBag.ItemList[i]);
                InventoryManager.ReFreshItem();
                break;
            }
        }
    }
    void EventManager(Item curItem)
    {
        //chest event
        if(Chest.chestCurStatus == Chest.chestStatus.isOpening)
        {
            chest.ChestEvent(Slot.lastItemName, curItem);
            curItem.itemNum--;
        }
    }
    public void ClearInventory()
    {
        foreach(var item in myBag.ItemList)
        {
            item.itemNum = 0;
        }
    }
}