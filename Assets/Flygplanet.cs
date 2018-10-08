using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flygplanet : MonoBehaviour {

    
    public float MoveSpeed;
    public float RotationSpeed;
    public Color Color;
    public SpriteRenderer Rend;
    private float time;
    private float RandomMovement;
 

	// Use this for initialization
	void Start () {

        RandomMovement = (Random.Range(1f, 6f));
        MoveSpeed = RandomMovement;
        Spawn();
        Speed();
        InvokeRepeating("Clock", 0f, 1f);
        //Gör så att timern bara uppdateras varje sekund
        Movement();
        ColorChange();
    }

    // Update is called once per frame
    void Update ()
    {
        Movement();
        ColorChange();
        Warp();

        //gör så att void update går till Movement koden och Clock koden
    }
    void Movement()
    {
        transform.Translate(MoveSpeed * Time.deltaTime, 0, 0, Space.Self);
        if (Input.GetKey(KeyCode.A))
            {
            transform.Rotate(0, 0, (RotationSpeed / 3) * Time.deltaTime, Space.World);
            Rend.color = new Color(0, 1, 0);
            //Detta gör så att när man trycker in A svänger den till vänster och byter färg till grön
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime, Space.World);
            Rend.color = new Color(0, 0, 1);
            //Detta gör så att när man trycker in D svänger den till höger och byter färg till blå
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((-MoveSpeed / 2) * Time.deltaTime, 0, 0, Space.Self);
            //detta gör så att skeppet åker halva hastigheten när du trycker in S
        }

    }
    void Clock()
    {
        time += 1;
        Debug.Log(string.Format("Timer {0}", time));
        //Gör såa tt timern lägger på 1 sekund
    }
    void ColorChange()
    {
        if (Input.GetKey(KeyCode.Space))
            Rend.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f) , Random.Range(0f, 1f), 1f);
    }
    void Warp()
    {
        if (transform.position.x > 9f)
        {
            transform.Translate(-18f, 0, 0);
        }
            if (transform.position.x < -9f)
            {
                transform.Translate(-18f, 0, 0);
            }
        if (transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
        }
    }
    void Spawn()
    {
        transform.position = new Vector3(Random.Range(9f, -9), (Random.Range(5, -5)));
    }
    void Speed()
    {
        transform.Translate(Random.Range(6, 0), 0, 0, Space.Self);
    }
}

    
