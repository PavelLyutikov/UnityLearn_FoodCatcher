using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody foodRb;
    private GameManager gameManager;

    private float zSpawnRange = 4;
    private float ySpawnPosition = 6;
    private float maxTorque = 10;

    [SerializeField] int pointValue;

    void Start()
    {
        foodRb = GetComponent<Rigidbody>();

        foodRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void FixedUpdate()
    {
        if (gameManager.score > 300)
        {
            Physics.gravity = new Vector3(0, -10.0F, 0);
        }
        else if (gameManager.score > 250)
        {
            Physics.gravity = new Vector3(0, -8.0F, 0);
        }
        else if (gameManager.score > 180)
        {
            Physics.gravity = new Vector3(0, -6.0F, 0);
        }
        else if (gameManager.score > 100)
        {
            Physics.gravity = new Vector3(0, -4.0F, 0);
        }
        else if (gameManager.score > 60)
        {
            Physics.gravity = new Vector3(0, -2.0F, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -1.0F, 0);
        }
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(0, ySpawnPosition, Random.Range(-zSpawnRange, zSpawnRange));
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            
            if (!gameObject.CompareTag("Good"))
            {
                Destroy(gameObject);
            }
            else
            {
                gameManager.GameOver();
            }

            
        }
    }
}
