using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA;

public class Ship_Controller : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletPrefab;

    public ParticleSystem ps;
    public ParticleSystem explosionRef;

    public bool ableToShoot = true;
    public float shootTimer = 0;
    public float shootRate = 2;

    private Rigidbody2D player_rb;
    private Transform player_transform;
    //private GameObject playerScore;

    public Transform firePoint;


    private float max_speed = 5f;
    public float force_amount = 1.5f;
    public float turn_speed = 90f;

    public float particlePerSecond = 1000;


    Renderer[] renderers;

    // Start is called before the first frame update


    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        player_transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Asteroid asteroid = hitInfo.GetComponent<Asteroid>();
        if(asteroid != null)
        {
            if (explosionRef != null)
            {
                ParticleSystem ps = Instantiate(explosionRef);
                ps.transform.position = asteroid.asteroid_rb.transform.position;
                ps.Play();
                Destroy(ps.gameObject, ps.main.duration);
            }
            asteroid.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            //handle UI
        }
    }

    void FixedUpdate()
    {
        player_rb.velocity = Vector2.ClampMagnitude(player_rb.velocity, max_speed);

        vector_movement();

        if(shootTimer >= 0)
        {
            shootTimer -= Time.fixedDeltaTime * shootRate;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            handle_shooting();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) )
        {
            if (ps != null)
            {
                var em = ps.emission;
                em.rateOverTime = 0;
            }
        }


    }


    void vector_movement()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //var emission = ps.emission;
            player_rb.AddRelativeForce(Vector2.up * max_speed);
            if(ps != null)
            {
                //ps.Emit((int)(particlePerSecond * Time.fixedDeltaTime));
                var em = ps.emission;
                em.rateOverTime = (int) (player_rb.velocity.magnitude * particlePerSecond);
            }

        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player_rb.transform.Rotate(0, 0, Time.fixedDeltaTime * turn_speed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player_rb.transform.Rotate(0, 0, -Time.fixedDeltaTime * turn_speed);
        }

    }

    void handle_shooting()
    {
        GameObject bullet = bulletPool.SharedInstance.GetPooledObject();
        if (shootTimer <= 0)
        {
           if(bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }
            shootTimer = 1;
            //ableToShoot = false;
        }
    }

}

//Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);