using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OrangeGhost : Interactable
{
    public enum taskStatus 
    {
        no_task_accepted,
        task_accepted,
        task_completion
    }
    public static taskStatus taskCurStatus;
    public string startSceneName;
    public string overSceneName;
    public GameObject keys, chestObject;
    Chest chest;
    // Start is called before the first frame update
    void Start()
    {
        chest = FindObjectOfType<Chest>();
        if (taskCurStatus == taskStatus.no_task_accepted || taskCurStatus == taskStatus.task_completion)
        {
            keys.SetActive(false);
            chestObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TipTextManager();
        
        if (trigger && Input.GetKey(KeyCode.E))
        {
            //get task from orange ghost
            if (taskCurStatus == taskStatus.no_task_accepted)
            {
                InventoryManager.instance.ClearInventory();
                taskCurStatus = taskStatus.task_accepted;
                keys.SetActive(true);
                chestObject.SetActive(true);
                SceneManager.LoadScene(startSceneName);
            }
            //haven't finished the task
            if(taskCurStatus == taskStatus.task_accepted)
            {
                SetTipText("Please help me");
            }
            //finished task and tell orange ghost
            if (Chest.chestCurStatus == Chest.chestStatus.opened)
            {
                SetTipText("Thank you!");
                chest.DestroyReward(); 
                taskCurStatus = taskStatus.task_completion;
                SceneManager.LoadScene(overSceneName);
            }
        }
    }
}
