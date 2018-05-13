using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    public Vector2 speedMinMax;
    float speed;

    float visibleHeightThreshold;

    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        //currently set to translate based on object space
        //if changed to Space.World, rotated object will fall straight down based on world space

        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
	}
}
