using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool isGameOn;

    public GameObject pipesObject;
    public GameObject player;

    private Vector3 pipesPosition = new Vector3(15f, 0f, 1f);
    private float spawnRate;

    public int points;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 3.0f;
        points = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOn)
        {
            StartGame();
        }
        
    }

    private IEnumerator spawnPipes()
    {
        while(!isGameOver)
        {
            Instantiate(pipesObject, pipesPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void StartGame()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Starting Game!");
            isGameOn = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            StartCoroutine(spawnPipes());
        }
        //dont spawn until we start game
        //dont allow physics to manipulate the player until we start game
    }
}
