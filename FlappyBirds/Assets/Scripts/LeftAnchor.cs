using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAnchor : MonoBehaviour
{
    public float leftOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        //Get the main camera's viewport width
        float viewportWidth = Camera.main.orthographicSize * 2f * Camera.main.aspect;

        //calculate pos based off viewport width and offset
        float xPos = -viewportWidth / 2f + leftOffset;

        //Get current pos and set only the x coordinate
        Vector3 newPosition = transform.position;
        newPosition.x = xPos;

        //set new position
        transform.position = newPosition;
    }

}
