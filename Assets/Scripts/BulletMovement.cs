using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject hey;
    public float moveSpeed;
    void Update()
    {
        Movement();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("playerHit");
            Destroy(hey);
        }
        if (other.tag == "Walls")
        {
            Debug.Log("wallHit");
            Destroy(hey);
        }
    }

    void Movement()
    {
        rb.AddForce(transform.right * moveSpeed * 2 * Time.deltaTime);
    }
}
