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
    public static float spawnRate;

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

    /// <summary>
    /// While the game isnt over, Spawns the pipe obstacle at timed intervals
    /// </summary>
    /// <returns>a routine</returns>
    private IEnumerator spawnPipes()
    {
        while(!isGameOver)
        {
            Instantiate(pipesObject, pipesPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    /// <summary>
    /// Starts the game when the player hits required button or key
    /// and allows physics to take place and starts spawning pipe obstacles
    /// </summary>
    private void StartGame()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && player != null)
        {
            startText.gameObject.SetActive(false);
            isGameOn = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            StartCoroutine(spawnPipes());
        }
    }

    /// <summary>
    /// This is what happens when the game is over.
    /// We check the highscore, do an explosion on player position,
    /// make a noise when the player dies and shows the game over panel
    /// </summary>
    /// <returns>a routine</returns>
    private IEnumerator GameOverRoutine()
    {
        isGameOn = false;
        playedGameOverRoutine = true;
        CheckHighscore();
        Vector3 pos = player.transform.position;
        Instantiate(birdExplosion, pos, Quaternion.identity);
        audioManager.PlayClip(1);
        Destroy(player.gameObject);
        yield return new WaitForSeconds(3f);
        gameOverPanel.SetActive(true);
    }

    /// <summary>
    /// Compares the players current score with the highscore
    /// </summary>
    private void CheckHighscore()
    {
        if(points > DataController.Instance.highscore)
        {
            DataController.Instance.highscore = points;
        }
    }
}
