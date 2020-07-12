using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    public enum asteroid_type { fake, small, medium, large };
    public Canvas canvasRef;
    public List<GameObject> asteroid_prefabs = new List<GameObject>(); // 0 = small, 1 = medium, 2 = large
    public asteroid_type a_type;
    public ParticleSystem ps;

    public Rigidbody2D asteroid_rb;
    // Start is called before the first frame update
    void OnEnable()
    {
        ps = this.GetComponent<ParticleSystem>();
        asteroid_rb.AddForce(new Vector2(Random.Range(1, 100), Random.Range(1, 100)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createSmallAsteroid(int asteroidsNum)
    {
        Debug.Log("Spawned Small Asteroids" + asteroidsNum);
        for(int i = 1; i <= asteroidsNum; i++)
        {
            GameObject asteroid = ObjectPoolSmall.SharedInstance.GetPooledObject();
            if(asteroid != null)
            {
                asteroid.transform.position = new Vector2(Random.Range(transform.position.x + 0.5f, transform.position.x - 0.5f), Random.Range(transform.position.y + 0.5f, transform.position.y - 0.5f));
                asteroid.transform.rotation = transform.rotation;
                asteroid.SetActive(true);
            }
        }
    }
    public void createMediumAsteroid(int asteroidsNum)
    {
        Debug.Log("Spawned Medium Asteroids:" + asteroidsNum);
        for (int i = 1; i <= asteroidsNum; i++)
        {
            GameObject asteroid = ObjectPoolMedium.SharedInstance.GetPooledObject();
            if (asteroid != null)
            {
                asteroid.transform.position = new Vector2(Random.Range(transform.position.x + 0.5f, transform.position.x - 0.5f), Random.Range(transform.position.y + 0.5f, transform.position.y - 0.5f));
                asteroid.transform.rotation = transform.rotation;
                asteroid.SetActive(true);
            }
        }
    }
    public void createLargeAsteroid(int asteroidsNum)
    {
        Debug.Log("Spawned Large Asteroids: " + asteroidsNum);
        for (int i = 1; i <= asteroidsNum; i++)
        {
            GameObject asteroid = ObjectPoolLarge.SharedInstance.GetPooledObject();
            if (asteroid != null)
            {
                asteroid.transform.position = new Vector2(Random.Range(transform.position.x + 0.5f, transform.position.x - 0.5f), Random.Range(transform.position.y + 0.5f, transform.position.y - 0.5f));
                asteroid.transform.rotation = transform.rotation;
                asteroid.SetActive(true);
            }
        }
    }
}
