using UnityEngine;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    float minForce = 12.0f;
    float maxForce = 15.0f;
    float minTorque = 2;
    private float xRange = 4;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRB.AddForce(RandomForceVector(minForce, maxForce), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorqueVector(minTorque), ForceMode.Impulse);

        transform.position = RandomSpawnPos(xRange);
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

    }
    private Vector3 RandomForceVector(float minForce, float maxForce) 
    {
        return (Vector3.up * Random.Range(minForce, maxForce));
    }
    private Vector3 RandomTorqueVector(float minTorque)
    {
        return new Vector3(Random.Range(-minTorque, minTorque), Random.Range(-minTorque, minTorque), Random.Range(-minTorque, minTorque));
    }
    private Vector3 RandomSpawnPos(float xRange)
    {
        return new Vector3(Random.Range(-xRange, xRange), -2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
