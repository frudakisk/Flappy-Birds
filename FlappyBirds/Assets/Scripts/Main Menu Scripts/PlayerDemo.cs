using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemo : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forwardSpeed;
    public float upForce;
    public float repeatTime;
    public float forceYPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * forwardSpeed * Time.deltaTime);

        if(transform.position.y <= forceYPosition)
        {
            ApplyForce();
        }

        if(transform.position.x >= 35f)
        {
            Destroy(gameObject);
        }

    }

    private void ApplyForce()
    {
        rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
    }
}
