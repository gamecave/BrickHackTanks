using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _health = 3;
    float speed = 0.5f;
    float rotateSpeed = 25.0f;
    Vector3 movement;
    Vector3 rotation;
    Rigidbody rb;

    public int Health { get => _health; set => _health = value; }

    public string id;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firePos;
    float fireRate = 1.0f;
    float fireTimer = 0.0f;
    bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

    }

    public void Fire()
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

    /// <summary>
    /// Handles player movement
    /// </summary>
    public void PlayerMovement(string vert, string hori)
    {
        switch (vert)
        {
            case "1":
                movement = new Vector3(0, 0, 1);
                break;
            case "-1":
                movement = new Vector3(0, 0, -1);
                break;
            default:
                break;
        }

        transform.Translate(movement * Time.deltaTime * speed, Space.Self);


        switch (hori)
        {
            case "1":
                rotation = new Vector3(0, 0, 1);
                break;
            case "-1":
                rotation = new Vector3(0, 0, -1);
                break;
            default:
                break;
        }

        transform.Rotate(rotation * Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other);
            Destroy(this.gameObject);
            print("Player defeated");
            print("Bullet deleted");
        }
    }
}
