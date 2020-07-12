using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class bullet : MonoBehaviour
{

    public GameObject player;
    public float speed = 5f;
    public Rigidbody2D rb;
    public ParticleSystem explosionRef;

    public float bulletLifeTime = 2.5f;


    // Start is called before the first frame update
    void OnEnable()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Asteroid asteroid = hitInfo.GetComponent<Asteroid>();
        if(asteroid != null)
        {
            if(explosionRef != null)
            {
                ParticleSystem ps = Instantiate(explosionRef);
                ps.transform.position = asteroid.asteroid_rb.transform.position;
                ps.Play();
                Destroy(ps.gameObject, ps.main.duration);
            }
            
            if (asteroid.a_type == Asteroid.asteroid_type.small)
            {
                ScoreHandler.AddScore(10);
            }
            if (asteroid.a_type == Asteroid.asteroid_type.medium)
            {
                asteroid.createSmallAsteroid(Random.Range(1, 3));
                ScoreHandler.AddScore(20);
                //spawn small + points
            }
            if (asteroid.a_type == Asteroid.asteroid_type.large)
            {
                asteroid.createMediumAsteroid(Random.Range(1, 2));
                ScoreHandler.AddScore(30);
                //spawn small or medium + points
            }

           asteroid.gameObject.SetActive(false);
            //Debug.Log(hitInfo.name);
            this.gameObject.SetActive(false);
        }

    }


    void FixedUpdate()
    {

        if(bulletLifeTime >= 0)
        {
            bulletLifeTime -= Time.fixedDeltaTime;
        }
        else
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }


    void OnDisable()
    {
        bulletLifeTime = 2.5f;
    }
}
