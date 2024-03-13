using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private GameManager gameManager;

    public float speed;
    private Vector3 startPos;
    private float repeat;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startPos = transform.position;
        repeat = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOn)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < startPos.x - repeat)
        {
            transform.position = startPos;
        }
    }
}
