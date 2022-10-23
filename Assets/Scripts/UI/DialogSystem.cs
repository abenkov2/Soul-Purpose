using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogSystem : MonoBehaviour
{
    [Header("UI")]
    public Text content;
    public Text name;
    [Header("file")]
    public TextAsset file;
    public int curDialogIndex;
    bool isDialogOver;

    List<string> textList = new List<string>();
    List<string> nameList = new List<string>();
    private void OnEnable()
    {
        name.text = nameList[curDialogIndex];
        content.text = textList[curDialogIndex++];
    }
    // Start is called before the first frame update
    void Awake()
    {
        getTextFormFile(file);
        curDialogIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //dialog click and continue
        if (Input.GetKeyDown(KeyCode.R) && curDialogIndex < textList.Count)
        {
            name.text = nameList[curDialogIndex];
            content.text = textList[curDialogIndex++];
        }
        if(curDialogIndex >= textList.Count)
        {
            isDialogOver = true;
            curDialogIndex = 0;
        }
    }
    /// <summary>
    /// Save dialog file into nameList and textList
    /// </summary>
    /// <param name="file"></param>
    void getTextFormFile(TextAsset file)
    {
        textList.Clear();

        var lineDate = file.text.Split('\n');
        for(int i = 0; i < lineDate.Length; i++)
        {
            if(i % 2 == 0)
            {
                nameList.Add(lineDate[i]);
            }
            else
            {
                textList.Add(lineDate[i]);
            }
        }
    }
}
