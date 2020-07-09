using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    public float dummy2;

    private Vector2 distance;
    private Vector3 transformLocation;

    public GameObject Bullet;
    public GameObject shooter;
    public GameObject explosion;
    public CameraEffects camera;


    
    Rotate playerRotation;

    

    float ready2fire;
    public float fireRate;

    public bool isMoving;
    public bool isDead = false;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRotation = GetComponentInChildren<Rotate>();
    }

    
    

    void FixedUpdate()
    {
        movement();
        shooting();
        
       
        //Debug.Log(isMoving);
    }

    void movement()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        distance = move * speed;
        rb.MovePosition(rb.position + distance * Time.fixedDeltaTime);
        isMoving = true;

        if (move == new Vector2(0f, 0f))
        {
            isMoving = false;
        }
    }

    void shooting()
    {
        
        if (Time.fixedTime > ready2fire)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transformLocation = shooter.transform.position;
                Instantiate(Bullet, transformLocation, playerRotation.transform.rotation);
                ready2fire = fireRate + Time.fixedTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            isDead = true;               
        }
        if (other.CompareTag("Shield"))
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            isDead = true;
        }

        if (other.CompareTag("Scout"))
        {
            StartCoroutine(Slowed());
        }

    }

    IEnumerator Slowed()
    {
        speed *= .5f;
        yield return new WaitForSeconds(2);
        speed *= 2;
    }
}
