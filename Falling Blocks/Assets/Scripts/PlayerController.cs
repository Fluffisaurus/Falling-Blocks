using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public event System.Action OnPlayerDeath;

    public float speed = 5;
    float screenHalfWidthInWorldUnits;
    float halfPlayerWidth;

    // Use this for initialization
    void Start () {

        halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate (Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x < -screenHalfWidthInWorldUnits + halfPlayerWidth)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits + halfPlayerWidth, transform.position.y);
        }

        if(transform.position.x > screenHalfWidthInWorldUnits - halfPlayerWidth)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits - halfPlayerWidth, transform.position.y);
        }
	}

    void OnTriggerEnter2D(Collider2D triggerCollider){
        if(triggerCollider.tag == "Falling Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

}//end of class
