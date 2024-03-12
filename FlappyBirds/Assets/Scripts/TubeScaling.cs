using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScaling : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        TubePosition();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        OffScreenDestroy();
    }

    private void TubePosition()
    {
        //determine position when creating tubes
        float randomMiddle = Random.Range(-2f, 3f);
        Vector3 pos = transform.position;
        pos.y = randomMiddle;
        transform.position = pos;
    }

    private void OffScreenDestroy()
    {
        if(transform.position.x <= -20f)
        {
            Destroy(gameObject);
        }
    }

}
