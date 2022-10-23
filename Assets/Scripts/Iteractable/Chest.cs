using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<string> presetKeyList;
    List<string> usedKeys = new List<string>();
    List<Item> tempKeyList = new List<Item>();
    bool isChestOpen;
    Animator animator;

    ItemOnWorld itemOnWorld;
    private void Start()
    {
        itemOnWorld = FindObjectOfType<ItemOnWorld>();
        animator = GetComponent<Animator>();
    }
    public void ChestEvent(string itemName,Item usedKey)
    {
        if (presetKeyList.Contains(itemName))
        {
            usedKeys.Add(itemName);
            tempKeyList.Add(usedKey);
            if (usedKeys.Count == presetKeyList.Count)
            {
                if (isSameList(usedKeys, presetKeyList))
                {
                    isChestOpen = true;
                    OpenChest();
                }
                else
                {
                    isChestOpen = false;
                    ResetBag();
                }
            }
        }
    }
    bool isSameList(List<string> a, List<string> b)
    {
        for(int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        return true;
    }
    void ResetBag()
    {
        foreach (var item in tempKeyList)
            itemOnWorld.AddNewItem(item);
        tempKeyList.Clear();
        usedKeys.Clear();
    }
    void OpenChest()
    {
        animator.Play("OpenChest");
    }
    void CloseChest()
    {
        animator.Play("CloseChest");
    }
}
