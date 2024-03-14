using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InfiniteBirdSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator InfiniteBirdSpawn()
    {
        while(true)
        {
            float randomY = Random.Range(-6f, 6f);
            GameObject birdInstance = Instantiate(bird, new Vector3(-30, randomY, -1), Quaternion.identity);
            birdInstance.GetComponent<PlayerDemo>().forceYPosition = randomY;
            int randomWaitTime = Random.Range(2, 9);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }
}
