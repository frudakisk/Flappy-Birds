using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScaling : MonoBehaviour
{
    public float strechFactor = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CompareTag("TopTube"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                TransformTube(-1, -0.5f, Vector3.up);
            }

            if (Input.GetMouseButtonDown(1))
            {
                TransformTube(1, 0.5f, Vector3.down);
            }
        }

        if(CompareTag("BottomTube"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                TransformTube(1, -0.5f, Vector3.up);
            }

            if (Input.GetMouseButtonDown(1))
            {
                TransformTube(-1, 0.5f, Vector3.down);
            }
        }

    }

    private void TransformTube(float yScaleTransform, float yPosTransform, Vector3 openingTranslateVector)
    {
        Transform tube = transform.Find("Body");
        Vector3 localScale = tube.localScale;
        Vector3 pos = tube.position;
        localScale.y += yScaleTransform;
        pos.y -= yPosTransform;
        tube.localScale = localScale;
        tube.position = pos;

        Transform opening = transform.Find("Opening");
        opening.Translate(openingTranslateVector);
    }
}
