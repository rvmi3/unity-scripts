using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Player player;

    public int enemyID;

    Vector3 target;

    public GameObject Explosion;
    public GameObject miniScout;


    float rot;

    Spawner spawner;

    Animator anim;

    

    







    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        anim = GetComponent<Animator>();
        //Debug.Log(enemyID + this.name);
    }
    void FixedUpdate()
    {
        EnemyVariants();

        rot += 30;
    }
    void EnemyVariants()
    {
        switch (enemyID)
        {
            case 0: scout();
                break;
            case 1: defScout();
                break;
            case 2: atkScout();
                break;
        }
    }
    void scout()
    {

        
        if (spawner.scoutSpawn == true)
        {
            float speed = 3;
            follow(speed);

            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance < 3)
            {
                
                Destroy(this.gameObject);
                _spread();

            }
        }

    }
    void defScout()
    {
        if (spawner.defenseSpawn == true)
        {
            float speed = 2;
            follow(speed);

            Transform pivot = GetComponentInChildren<Transform>();
            pivot.transform.Rotate(Vector3.forward * 50f * Time.fixedDeltaTime);
        }

    }

    void atkScout()
    {
        if (spawner.attackSpawn == true)
        {
            float speed = 4;
            follow(speed);

            Transform pivot = GetComponentInChildren<Transform>();
            pivot.transform.Rotate(Vector3.forward * 50f * Time.fixedDeltaTime);
        }

        

    }

    void follow(float speed)
    {
        if (player.isDead == true)
        {
            return;
        }

        if (player.isMoving == false)
        {
            speed *= 2;
        }
        speed *= Time.fixedDeltaTime;
        target = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
        Instantiate(Explosion, transform.position, Quaternion.identity);   
    }

    void _spread()
    {

        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 30));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 60));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 120));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 150));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 210));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 240));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 270));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 300));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 330));
        Instantiate(miniScout, transform.position, Quaternion.Euler(0, 0, 360));

    }

    

}
