using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Chest : Interactable
{
    public enum chestStatus
    {
        close,
        isOpening,
        opened
    }
    public static chestStatus chestCurStatus;
    public List<GameObject> keyList;
    public List<Item> rewardList;

    public bool isCollectedAllKeys;

    public List<string> presetKeyList = new List<string>();
    public List<string> usedKeys = new List<string>();
    public List<Item> tempKeyList = new List<Item>();
    Animator animator;

    ItemOnWorld itemOnWorld;
    private void Start()
    {
        itemOnWorld = FindObjectOfType<ItemOnWorld>();
        animator = GetComponent<Animator>();
        SetPresetKeyList();
        chestCurStatus = chestStatus.close;
    }
    private void Update()
    {
        TipTextManager();
        CollectedAllKeys();
        if (trigger && (chestCurStatus == chestStatus.close || chestCurStatus == chestStatus.isOpening) && Input.GetKey(KeyCode.E))
        {
            chestCurStatus = chestStatus.isOpening;
            if (isCollectedAllKeys)
            {
                StartCoroutine(startChestPuzzle());
            }
            else
            {
                SetTipText("You haven't found all keys");
            }
        }
        if(chestCurStatus == chestStatus.isOpening && trigger)
        {
            if (isCollectedAllKeys)
            {
                SetTipText("Please open bag and use the keys in order");
            }
        }
    }
    public void ChestEvent(string itemName,Item usedKey)
    {
        if (presetKeyList.Contains(itemName))
        {
            usedKeys.Add(itemName);
            tempKeyList.Add(usedKey);
            if (usedKeys.Count == presetKeyList.Count)
            {
                //open chest in order
                if (isSameList(usedKeys, presetKeyList))
                {
                    OpenChest();
                }
                //not open chest in order
                else
                {
                    ResetBag();
                }
            }
        }
    }
    public void DestroyReward()
    {
        foreach (var reward in rewardList)
            InventoryManager.DestroyItem(reward);
    }
    public bool CollectedAllKeys()
    {
        List<string> bagNameList = new List<string>();
        foreach (var i in InventoryManager.instance.myBag.ItemList)
        {
            bagNameList.Add(i.itemName);
        }
        //using System.Linq and Get intersection and judge is same
        isCollectedAllKeys = (Intersect(bagNameList, presetKeyList).Count == presetKeyList.Count);
        return isCollectedAllKeys;
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
    List<string> Intersect(List<string> a, List<string>b)
    {
        List<string> outCome = new List<string>();
        foreach(var i in a)
        {
            if(b.Contains(i)) outCome.Add(i);
        }
        return outCome;
    }
    void ResetBag()
    {
        foreach (var item in tempKeyList)
        {
            itemOnWorld.AddNewItem(item);
        }
            
        tempKeyList.Clear();
        usedKeys.Clear();
    }
    void OpenChest()
    {
        animator.Play("OpenChest");
        chestCurStatus = chestStatus.opened;
        PlayerBag.Instance.CloseMyBag();
        SetTipText("Chest is opened");
        //GainReward
        foreach (var reward in rewardList)
        {
            itemOnWorld.AddNewItem(reward);
        }
    }
    void SetPresetKeyList()
    {
        presetKeyList.Clear();
        foreach(var i in keyList)
        {
            presetKeyList.Add(i.name);
        }
    }
    
    IEnumerator startChestPuzzle()
    {
        SetTipText("Please open bag and use the keys in order");
        PlayerBag.Instance.OpenMyBag();
        yield return new WaitForSeconds(0.1f);
    }
}
