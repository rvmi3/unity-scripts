using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forward : MonoBehaviour
{
    public GameObject explosion;
    public void Start()
    {
        Destroy(this.gameObject, 2);
    }
    public void FixedUpdate()
    {
        transform.Translate(Vector3.up * 10 * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
