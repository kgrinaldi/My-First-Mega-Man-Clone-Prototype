using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    private float speed = 1;

    private Rigidbody2D rb2d;

    private Vector2 playerPosition;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        

        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationY = Input.GetAxis("Vertical") * speed;

        Vector2 translation = new Vector2();
        
        //float horizontal = 0;
        //float vertical = 0;

        transform.Translate(translationX, translationY, 0);

        if(Input.GetKeyDown == KeyCode)
        {

        }

        //Vector2 movement

        //rb2d.AddForce(movement);

	}
}
