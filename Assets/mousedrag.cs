using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedrag : MonoBehaviour {

    // Variable initialization.
    private Rigidbody2D rb;

    private Vector3 oldMousePos;
    private Vector3 offset;

    private bool letDrop = false; // Can object be moved by mouse.

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0, -9.81F);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("v_x: " + rb.velocity.x);
	}

    void OnMouseDown()
    {
        oldMousePos = Input.mousePosition;
        Physics2D.gravity = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    void OnMouseDrag()
    {
        if (!letDrop)
        {
            Vector3 curScreenPoint = Input.mousePosition;
            offset = curScreenPoint - oldMousePos;
            oldMousePos = curScreenPoint;
            Vector3 itemPos = Camera.main.WorldToScreenPoint(transform.position);
            transform.position = Camera.main.ScreenToWorldPoint(itemPos + offset);
        }
    }

    void OnMouseUp()
    {
        Physics2D.gravity = new Vector2(0, -9.81F);
        rb.velocity = offset;
        letDrop = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string goName = collision.gameObject.name;
        if ((goName == "lwall" || goName == "rwall" || goName == "ceiling" || goName == "floor")
            && Input.GetMouseButton(0))
        {
            letDrop = true;
            if (Physics2D.gravity == Vector2.zero)
                Physics2D.gravity = new Vector2(0, -9.81F);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!Input.GetMouseButton(0) && collision.gameObject.name == "floor")
            letDrop = false;
    }
}
