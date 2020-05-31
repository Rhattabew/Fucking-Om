using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Om : MonoBehaviour
{
    public Transform william;
    public Transform firePoint;
    public GameObject[] heyBullet;
    public float timer;
    public float fireRate;
    public Rigidbody2D rb;
    public float moveSpeedRight;
    public float moveSpeed;
    public float stoppingDistance;
    public float retreatDistance;


    void Start()
    {
        william = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        shooting();
        LookAt();
        Movement();
    }

    void shooting()
    {
        timer -= Time.deltaTime;
        int i =Random.Range(0, 2);
        if(timer <= 0)
        {
            Instantiate(heyBullet[i], firePoint.position, firePoint.rotation);
            timer = fireRate;
        }

    }

    void LookAt()
    {
        //Looks at closest enemy.
        var addAngle = 0;
        var dir = william.position - firePoint.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        firePoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
        Debug.Log(william.position);
    }
}
