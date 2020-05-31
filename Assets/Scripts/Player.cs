using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public GameObject music;
    public AudioSource iLost;

    void Start()
    {
        if (GameObject.FindWithTag("Music") != null)
        {
            music = GameObject.FindWithTag("Music").gameObject;
        }

    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * moveSpeed * -2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * moveSpeed * 2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * moveSpeed * 2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.up * moveSpeed * -2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            iLost.Play();
            Invoke("GameOver", 3f);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void GameOver()
    {
        Destroy(music);
        SceneManager.LoadScene(0);
    }
}
