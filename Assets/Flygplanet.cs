using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flygplanet : MonoBehaviour {

    public SpriteRenderer Rend;
    public float MoveSpeed;
    public float RotationSpeed;
    public Color Color;


	// Use this for initialization
	void Start () {

        Rend.Color = Color;
        Movement();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();

    }
    void Movement()
    {
        transform.Translate(MoveSpeed * Time.deltaTime, 0, 0, Space.Self);
        if (Input.GetKey(KeyCode.A))
            {
            transform.Rotate(0, 0, RotationSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime, Space.World);
            Rend.color = new Color(1, 0, 0);
        }

    }
}

