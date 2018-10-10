using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flygplanet : MonoBehaviour {

    
    public float MoveSpeed;
    //public float så att man kan ändra värdet på Movespeed i unity
    public float RotationSpeed;
    //public float så att man kan ändra värdet på RotationSpeed i unity
    public Color Color;
    // public så man kan ändra färgen i unity
    public SpriteRenderer Rend;
    private float time;
    //gjorde time till en private float för att jag vill att den ska kunna bli ett stort nummer och den ska inte kunna ändra i unity
    private float RandomMovement;
    //gjorde RandomMovement till en private float eftersom den inte behöver ändras i unity den behöver bara veta att Randommovement är en float

	// Use this for initialization
	void Start () {

        RandomMovement = (Random.Range(1f, 6f));
        //Gör så att RandomMovement har får en siffra mellan 1-6 hastighet
        MoveSpeed = RandomMovement;
        //Gör så att MoveSpeed är samma sak som RandomMovement
        Spawn();
        //Gör så att den går till void Spawn
        Speed();
        //Gör så att den går till void Speed
        InvokeRepeating("Clock", 0f, 1f);
        //Gör så att Clock uppdateras 1 gång per sekund
        Movement();
        //Gör så den går till Void Movement
        ColorChange();
        //Gör så att den går till void ColorChange
    }

    // Update is called once per frame
    void Update ()
    {
        Movement();
        //gör så att vad som står i void Movement "warpas" hit
        ColorChange();
        //gör så att vad som står i void ColorChange "warpas" hit
        Warp();
        //gör så att vad som står i void Warp "warpas" hit
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
        //Gör såa att timern lägger på 1 och att den skriver Timer (värdet på timern)
    }
    void ColorChange()
    {
        if (Input.GetKey(KeyCode.Space))
            Rend.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f) , Random.Range(0f, 1f), 1f);
        //Gör så att om man trycker/håller ner space så byter den fär till en random färg
    }
    void Warp()
    {
        if (transform.position.x > 9f)
        {
            transform.Translate(-18f, 0, 0);
            //om du åker till ett värde över 9 i x så åker du bakåt 18
        }
            if (transform.position.x < -9f)
            {
                transform.Translate(-18f, 0, 0);
            //om du åker till ett värde under -9 i x så åker du bakåt 18

        }
        if (transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
            //Gör så att om du åker över värdet 5 i y så skyckas du till -5 i y och har kvar samma position i x och z 
        }
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
            //Gör så att om du åker under värdet -5 i y så skyckas du till 5 i y och har kvar samma position i x och z 

        }
    }
    void Spawn()
    {
        transform.position = new Vector3(Random.Range(9f, -9), (Random.Range(5, -5)));
        //Gör så att du spawnar in ett random värde mellan 9 och -9 i x och 5 och -5 i y led
    }
    void Speed()
    {
        transform.Translate(Random.Range(6, 1), 0, 0, Space.Self);
        //Gör så att du får en random hastighet mella 6 och 1
    }
}

    
