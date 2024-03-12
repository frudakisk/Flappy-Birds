using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool isGameOn;

    public GameObject pipesObject;
    public GameObject player;

    private Vector3 pipesPosition = new Vector3(15f, 0f, 1f);
    private float spawnRate;

    public int points;

    //Text
    public TextMeshProUGUI startText;
    public TextMeshProUGUI scoreText;

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

        scoreText.text = $"Score: {points}";

        if(isGameOver)
        {
            //little particle effect here
            Destroy(player.gameObject);
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
            startText.gameObject.SetActive(false);
            isGameOn = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            StartCoroutine(spawnPipes());
        }
        //dont spawn until we start game
        //dont allow physics to manipulate the player until we start game
    }
}
