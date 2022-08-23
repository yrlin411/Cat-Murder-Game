using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{

    public float movementSpeed = 0.1f;

    public float jumpCooldown = 2f;
    public bool isFacingRight = true;

    private float lastJumpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movementSpeed * (isFacingRight?1:-1), 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) {
            isFacingRight = !isFacingRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CatJumpPoint") && Time.time-lastJumpTime>jumpCooldown) {
            Debug.Log("Cat found a jump point");
            float prob = collision.GetComponent<CatJumpPoint>().jumpProbability;
            float roll = Random.Range(0f, 1f);
            Debug.Log("Roll: "+roll+" need to beat "+ prob);
            if (roll < prob) {
                Jump(collision.GetComponent<CatJumpPoint>().jumpDestination);
                lastJumpTime = Time.time;
            }
        }
    }

    private void Jump(GameObject jumpDestination)
    {
        Debug.Log("CanJumps");  
        transform.position = jumpDestination.transform.position;
    }
}
