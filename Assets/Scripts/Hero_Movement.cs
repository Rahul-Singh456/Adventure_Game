using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;

public class Hero_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Camera cam;
    public TMP_Text Score;

    public int score = 0;
    public float Hz_acc = 20.0f;
    public float Jump_Speed = 6.5f;
    private bool is_in_air = false;
    public bool OUT = false;
    private bool FINISH = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GetComponent<Camera>();
        cam = Camera.main;
        cam.enabled = true;
    }
    void Update()
    {
        if (FINISH && !OUT && !is_in_air)
        {
            rb.velocity = new Vector3(0, 0, 0);
            Debug.Log("YOU WIN!!!!!!!!!!");
        }

        else if (!OUT)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            {
                if (rb.velocity.x <= 5.0f)
                {
                    rb.velocity += new Vector2(1, 0) * Hz_acc * Time.deltaTime;
                }
            }

            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            {
                if (rb.velocity.x >= -5.0f)
                {
                    rb.velocity -= new Vector2(1, 0) * Hz_acc * Time.deltaTime;
                }
            }

            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
            {
                if (!is_in_air)
                {
                    Vector2 temp_vel = rb.velocity;
                    temp_vel.y = Jump_Speed;
                    rb.velocity = temp_vel;
                    is_in_air = true;
                }
            }

            cam.transform.position = new Vector3(rb.position.x, rb.position.y + 2.5f, -10);
        }
        
        else 
        {
            rb.velocity = new Vector3(0, 0, 0);
            Debug.Log("OUT!!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_in_air = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            OUT = true;
        }
        else if (collision.gameObject.tag == "Finish")
        {
            FINISH = true;
        }

    }
    public void Scoring()
    {
        score++;
        Score.text = score.ToString();
    }
}
