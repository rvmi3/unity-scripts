using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    

    public float bulletSpeed;
    public GameObject Explosion;
    public CameraEffects camera;

    bool shake;


    public void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraEffects>();
    }
    public void FixedUpdate()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.fixedDeltaTime);
        if (shake == true)
        {
            StartCoroutine(camera.Shake(1f, .4f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Destroy();            
            Destroy(this.gameObject);
            shake = true;
            Instantiate(Explosion, transform.position, Quaternion.identity);
            
        }
        else if (other.CompareTag("Shield"))
        {
            EnemyExtras protection = other.GetComponent<EnemyExtras>();

            protection.Destroy();
            Destroy(this.gameObject);
            Instantiate(Explosion, transform.position, Quaternion.identity);
        }

        
    }
    IEnumerator shaked()
    {
        yield return new WaitForSeconds(1f);
        shake = false;
    }

    


}
