using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Interactable : MonoBehaviour
{
    public string message;
    public string nameText;
    public TextMeshProUGUI content;
    public TextMeshProUGUI name;
    public GameObject Cav;

    public enum triggleType
    {
        Enter,
        Stay,
        Leave,
    }
    public triggleType triggle;

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<TextMeshProUGUI>();
        name = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        
    }
}
