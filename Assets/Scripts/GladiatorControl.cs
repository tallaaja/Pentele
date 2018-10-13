using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorControl : MonoBehaviour {

    public GameObject gladiator;
    public Rigidbody2D gladiatorrigidbody;
    float speed = 1;

	// Use this for initialization
	void Start () {
        Rigidbody2D gladiatorrigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D pressed");
            gladiatorrigidbody.velocity = transform.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A pressed");
            gladiatorrigidbody.velocity = transform.right * -speed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S pressed");
            gladiatorrigidbody.velocity = transform.up * -speed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W pressed");
            gladiatorrigidbody.velocity = transform.up;
        }

    }
}
