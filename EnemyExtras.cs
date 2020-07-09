using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExtras : MonoBehaviour
{
    public GameObject explosion;

    public void Destroy()
    {
        Destroy(this.gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
