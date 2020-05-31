using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmMovement : MonoBehaviour
{
    public float stoppingDistance;
    public float retreatDistance;
    public Transform william;
    public Rigidbody2D rb;
    public float moveSpeedRight;
    public float moveSpeed;


    void Start()
    {
        william = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Movement();
        LookAt();
    }
    void Movement()
    {
        //rb.AddForce(transform.up * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, william.position) > stoppingDistance)
        {
            rb.AddForce(transform.up * moveSpeed * 120 * Time.deltaTime);
        }
        //If the enemy is too close to the player but not close enough to retreat, the enemy gain nor lose velocity.
        else if (Vector2.Distance(transform.position, william.position) < stoppingDistance && (Vector2.Distance(transform.position, william.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        //If the enemy is too close to the player, the enemy will retreat.
        else if (Vector2.Distance(transform.position, william.position) < retreatDistance)
        {
            rb.AddForce(transform.up * -moveSpeed * 60 * Time.deltaTime);
        }
    }
    void LookAt()
    {
        //Looks at closest enemy.
        var addAngle = 0;
        var dir = william.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
