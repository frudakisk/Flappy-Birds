using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public GameObject pipesObject;

    private Vector3 pipesPosition = new Vector3(15f, 0f, 1f);
    private float spawnRate;

    public int points;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 3.0f;
        points = 0;
        StartCoroutine(spawnPipes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnPipes()
    {
        while(!isGameOver)
        {
            Instantiate(pipesObject, pipesPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
