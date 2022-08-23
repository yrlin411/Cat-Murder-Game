using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject atMouseHole;

    public float mouseSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        if (hor != 0) {
            transform.position += new Vector3(mouseSpeed*hor,0,0); 
        }

        if (Input.GetKeyDown(KeyCode.W) && atMouseHole!=null)
        {
            transform.position = atMouseHole.GetComponent<MouseHole>().otherMouseHole.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MouseHole")) {
            atMouseHole = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(atMouseHole))
        {
            atMouseHole=null;
        }
    }
}
