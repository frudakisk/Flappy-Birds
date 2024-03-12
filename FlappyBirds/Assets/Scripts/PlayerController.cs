using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float impulseForce;
    private float roofValue;
    private float bounceForce;

    private Rigidbody2D rb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        impulseForce = 10f;
        roofValue = 4.5f;
        bounceForce = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        CheckRoof();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * impulseForce, ForceMode2D.Impulse);
    }

    private void CheckRoof()
    {
        if(transform.position.y >= roofValue)
        {
            transform.position = new Vector2(transform.position.x, roofValue);
            rb.AddForce(Vector2.down * bounceForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tube") ||
            collision.gameObject.name == "Floor")
        {
            Debug.Log("Game over!");
            gameManager.isGameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Point Trigger")
        {
            gameManager.points++;
        }
    }
}
