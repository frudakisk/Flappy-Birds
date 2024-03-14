using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool isGameOn;
    private bool playedGameOverRoutine;

    private AudioManager audioManager;

    public GameObject pipesObject;
    public GameObject player;

    private Vector3 pipesPosition = new Vector3(15f, 0f, -1f);
    private float spawnRate;

    public int points;

    //Text
    public TextMeshProUGUI startText;
    public TextMeshProUGUI scoreText;

    //panels
    public GameObject gameOverPanel;

    //particle effects
    public ParticleSystem birdExplosion;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
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

        if(isGameOver && !playedGameOverRoutine)
        {
            StartCoroutine(GameOverRoutine());
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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && player != null)
        {
            startText.gameObject.SetActive(false);
            isGameOn = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            StartCoroutine(spawnPipes());
        }
    }

    private IEnumerator GameOverRoutine()
    {
        isGameOn = false;
        playedGameOverRoutine = true;
        Vector3 pos = player.transform.position;
        Instantiate(birdExplosion, pos, Quaternion.identity);
        audioManager.PlayClip(1);
        Destroy(player.gameObject);
        yield return new WaitForSeconds(3f);
        gameOverPanel.SetActive(true);
    }
}
