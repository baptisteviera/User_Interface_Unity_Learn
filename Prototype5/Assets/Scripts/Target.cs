using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 0;
    private GameManager myGameManagerScript;
    public int pointValue;
    public ParticleSystem explosionParticule;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos(); // position de départ
        myGameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        // il faut en effet que je prenne le script associé à mon objet game manager
    }

    private void OnMouseDown()
    {
        // permet d'éviter de pouvoir cliquer sur les objets si tous les objets ne sont pas encore redescendu et que l'on est au game over.
        if (myGameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            myGameManagerScript.updateScore(pointValue);
            Instantiate(explosionParticule, transform.position, explosionParticule.transform.rotation);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            myGameManagerScript.gameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
