using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
