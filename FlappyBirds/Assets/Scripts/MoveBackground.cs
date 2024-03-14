using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBackground : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gm;

    public float speed;
    public static Vector3 startPos; //determined by camera viewpoint
    private float repeat;
    public float designatedZ;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        if(gameManager != null)
        {
            gm = gameManager.GetComponent<GameManager>();
        }
        repeat = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //this scripts needs to behave differently in the two different scenes
        if(gameManager == null)
        {
            if(SceneManager.GetActiveScene().name == "Main Menu")
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
        else
        {
            //only start moving if the game is active
            if (gm.isGameOn)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }


        if (transform.position.x < startPos.x - repeat)
        {
            startPos.z = designatedZ;
            transform.position = startPos;
            //use designated z for startPos
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(startPos.x, -15, startPos.y), new Vector3(startPos.x, 15, startPos.y));
    }
}
