using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    float fireRate = 1.0f;
    float fireTimer = 0.0f;
    bool canFire = true;

    public GameObject bullet;
    public GameObject firePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }

        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (canFire)
            {
                Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                canFire = false;
                fireTimer = 0.0f;
            }
            else
            {
                return;
            }
        }
    }
}
