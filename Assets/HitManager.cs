using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    public float hitForce = 1000;
    public float hitCooldown = 1f;

    private float lastHitTime = 0;
    public void TakeHit(GameObject hittingGameObject) {
        //Destroy(this.gameObject);
        if (Time.time - lastHitTime > hitCooldown)
        {
            Vector3 dir = (this.transform.position - hittingGameObject.transform.position).normalized;
            dir.y = -dir.y;
            GetComponent<Rigidbody2D>().AddForce(dir * hitForce);
            Debug.Log("Auch! " + this.gameObject.name + " got hit!");
        }
    }
}
