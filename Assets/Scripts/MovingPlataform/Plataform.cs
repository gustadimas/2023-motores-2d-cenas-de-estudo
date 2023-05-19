using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plataform : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed;
    [SerializeField] Transform pointA, pointB;
    [SerializeField] Text timer;

    private float StartTime;

    bool moving = true;
    bool playerInPlataform = false;

    void Start()
    {
        StartTime = Time.time;
        rb = GetComponent<Rigidbody2D>();       
    }

    void Update()
    {
        if (playerInPlataform)
        {
            Timer();

            if (moving)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            if (transform.position.x >= pointB.position.x)
            {
                moving = false;
            }
            else if (transform.position.x <= pointA.position.x)
            {
                moving = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInPlataform = true;
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);

            Destroy(timer.gameObject);
        }
    }

    void Timer()
    {
        float TimerControl = Time.time - StartTime;
        string mins = ((int)TimerControl / 20).ToString("00");
        string segs = ((20) - TimerControl % 20).ToString("00");
        string milisegs = ((TimerControl * 100) % 100).ToString("00");

        string TimerString = string.Format("{00}:{01}:{02}", mins, segs, milisegs);

        timer.text = TimerString.ToString();

        if (segs.Equals("00"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            speed = 0;
            timer.gameObject.SetActive(false);
        }
    }
}
