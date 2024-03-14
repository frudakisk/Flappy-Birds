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
    private AudioManager audioManager;
    private ParticleSystem jumpParticles;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        jumpParticles = GetComponent<ParticleSystem>();
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
        jumpParticles.Play();
    }

    private void CheckRoof()
    {
        if(transform.position.y >= roofValue)
        {
            transform.position = new Vector3(transform.position.x, roofValue, transform.position.z);
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
            audioManager.PlayClip(0);
            gameManager.points++;
        }
    }
}
