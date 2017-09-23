using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour {

    // Variable initialization.
    private Vector3 oldMousePos;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        Physics2D.gravity = new Vector2(0, -9.81F);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        oldMousePos = Input.mousePosition;
        Physics2D.gravity = Vector2.zero;
    }

    void OnMouseDrag()
    {
        
        Vector3 curScreenPoint = Input.mousePosition;
        offset = curScreenPoint - oldMousePos;
        oldMousePos = curScreenPoint;
        Vector3 itemPos = Camera.main.WorldToScreenPoint(transform.position);
        transform.position = Camera.main.ScreenToWorldPoint(itemPos + offset);
    }

    void OnMouseUp()
    {
        Physics2D.gravity = new Vector2(0, -9.81F);
    }
}
