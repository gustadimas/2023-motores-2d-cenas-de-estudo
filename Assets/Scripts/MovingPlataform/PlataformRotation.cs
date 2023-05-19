using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlataformRotation : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius, angularSpeed;
    [SerializeField] Text timer;
    private float StartTime;
    float posX, posY, angle = 0f;
    bool playerInPlataform = false;

    void Start()
    {
        StartTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / 2;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        Debug.Log("posX " + posX + "posY " + posY);

        if (angle >= 360f)
        {
            angle = 0f;
        }

        if (playerInPlataform)
        {
            Timer();
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
            //timer.gameObject.SetActive(false);
            Destroy(timer.gameObject);
        }
    }

    void Timer()
    {
        float TimerControl = Time.time - StartTime;
        string mins = ((int)TimerControl / 10).ToString("00");
        string segs = (10 - TimerControl % 10).ToString("00");
        string milisegs = ((TimerControl * 100) % 100).ToString("00");
        string TimerString = string.Format("{00}:{01}:{02}", mins, segs, milisegs);
        timer.text = TimerString.ToString();

        if (segs.Equals("00"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            Destroy(rotationCenter.gameObject);
           //timer.gameObject.SetActive(false);
        }

        else if (timer.gameObject == false)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
