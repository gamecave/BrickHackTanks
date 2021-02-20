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

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    /// <summary>
    /// Handles player movement
    /// </summary>
    void PlayerMovement()
    { 
        movement = new Vector3(0, 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * Time.deltaTime * speed, Space.Self);

        rotation = new Vector3(0, Input.GetAxis("Horizontal"), 0);
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
