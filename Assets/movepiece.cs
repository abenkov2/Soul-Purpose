using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movepiece : MonoBehaviour
{
    public enum pieceStatusType
    {
        idle,
        pickedup,
        locked
    }
    public pieceStatusType pieceStatus;

    public Transform edgeParticles;

    public KeyCode placePiece;

    public KeyCode returnToInv;

    public bool checkPlacement;

    public float yDiff;

    public Vector2 invPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvControl();

        if (pieceStatus == pieceStatusType.pickedup)
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = objPos;
        }

        if ((Input.GetKeyDown(placePiece)) && (pieceStatus == pieceStatusType.pickedup))
        {
            checkPlacement = true;
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        Debug.Log("1");
        if ((other.gameObject.name == gameObject.name) && checkPlacement == true)
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.position = other.gameObject.transform.position;
            pieceStatus = pieceStatusType.locked;
            Instantiate(edgeParticles, other.gameObject.transform.position, edgeParticles.rotation);
            checkPlacement = false;

        }

        if ((other.gameObject.name != gameObject.name) && checkPlacement == true)
        {
            checkPlacement = false;
        }
    }

    void OnMouseDown()
    {
        pieceStatus = pieceStatusType.pickedup;
        checkPlacement = false;
        invPos = transform.position;
    }

    void InvControl()
    {
        if ((Input.GetAxis("Mouse ScrollWheel") > 0) && (pieceStatus != pieceStatusType.locked))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            yDiff -= 2;
        }

        if ((Input.GetAxis("Mouse ScrollWheel") < 0) && (pieceStatus != pieceStatusType.locked))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            yDiff += 2;
        }

        if ((Input.GetKeyDown(returnToInv)) && (pieceStatus == pieceStatusType.pickedup))
        {
            transform.position = new Vector2(0, invPos.y + yDiff);
            pieceStatus = pieceStatusType.idle;
        }
    }
}
