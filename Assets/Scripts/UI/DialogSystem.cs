using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogSystem : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI content;
    public TextMeshProUGUI name;
    [Header("file")]
    public TextAsset file;
    public int index;

    List<string> textList = new List<string>();
    List<string> nameList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        getTextFormFile(file);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index < textList.Count)
        {
            name.text = nameList[index];
            content.text = textList[index++];
        }
        if(index >= textList.Count)
        {
            index = 0;
        }
    }
    void getTextFormFile(TextAsset file)
    {
        textList.Clear();

        var lineDate = file.text.Split('\n');
        for(index = 0; index < lineDate.Length; index++)
        {
            if(index % 2 == 0)
            {
                nameList.Add(lineDate[index]);
            }
            else
            {
                textList.Add(lineDate[index]);
            }
        }
    }
}
