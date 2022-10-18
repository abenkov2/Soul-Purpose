using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInfo;
    private void Awake()
    {
        if(instance != null)
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
    public static void ReFreshItem()
    {
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.myBag.ItemList.Count; i++)
        {
            if (instance.myBag.ItemList[i].itemNum > 0)
                CreateNewItem(instance.myBag.ItemList[i]);
        }
    }
}
