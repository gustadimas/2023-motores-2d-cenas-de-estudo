using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlataforms : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField]  LayerMask jumpableGround;

    [SerializeField] float jumpForce;

    [SerializeField] GameObject pauseGame;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(5, rb.velocity.y);

        //if (transform.position.x > 12)
        //{
        //    transform.position = new Vector3(-13, -1.6f, 0);
        //}
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("lastPoint"))
        {
            SceneManager.LoadScene("Responsividade");
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseGame.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseGame.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
