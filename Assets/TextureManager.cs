using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextureManager : MonoBehaviour
{
    Object[] textures;
    public GameObject puzzlePiecePrefab;
    public GameObject puzzlePieceGrid;

    public GameObject rightPuzzlePiecePrefab;
    public GameObject rightPuzzlePieceGrid;

    int gridNum = 60;
    // Start is called before the first frame update
    void Start()
    {
        textures = Resources.LoadAll("Textures", typeof(Sprite));
        foreach (var t in textures)
        {
            GameObject piece = Instantiate(puzzlePiecePrefab, puzzlePieceGrid.transform.position, Quaternion.identity);
            piece.transform.SetParent(puzzlePieceGrid.transform);
            piece.GetComponent<Image>().sprite = (Sprite)t;
        }

        for(int i = 0; i < gridNum; i++)
        {
            GameObject piece = Instantiate(rightPuzzlePiecePrefab, rightPuzzlePieceGrid.transform.position, Quaternion.identity);
            piece.transform.SetParent(rightPuzzlePieceGrid.transform);
        }
    }

}
