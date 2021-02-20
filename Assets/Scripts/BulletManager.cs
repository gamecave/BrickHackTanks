using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    float speed = 20.0f;

    float delete = 1.0f;
    float deleteTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        deleteTimer += Time.deltaTime;
        if(deleteTimer >= delete)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
