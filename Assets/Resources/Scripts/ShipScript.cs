using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Rendering;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Rigidbody2D shipRigidBody;
    public Vector3 movement;
    public GameObject ammo;
    public float cooldownTime = 1.0f;
    
    // System.Timers.Timer cooldownTimer = new System.Timers.Timer();
    private float cooldownTimer = 0.0f;

    //Bullet Properties
    public float bulletSpeed = 3f;
    public float bulletWidth = 0.05f;
    public float bulletHeight = 0.05f;
    public int bulletPierce = 1;

    void Start()
    {
        shipRigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        getInputs();

        cooldownTimer -= Time.deltaTime;
    }

    void getInputs() {
        if (Input.GetKey("w")) {
            moveCharacter(transform.up);
        }
        if (Input.GetKey("a")) {
            moveCharacter(-transform.right);
        }
        if (Input.GetKey("d")) {
            moveCharacter(transform.right);
        }
        if (Input.GetKey("s")) {
            moveCharacter(-transform.up);
        }
        if (Input.GetKey("j")) {
            shoot();
        }
    }

    void moveCharacter(Vector3 direction) {
        transform.position += direction * movementSpeed* Time.deltaTime;
    }

    void shoot() {
        if (Input.GetKey("j") && cooldownTimer <= 0.0f) {
            GameObject shipBullet = Instantiate(ammo, transform.position, Quaternion.identity) as GameObject;
            shipBullet.gameObject.GetComponent<BulletScript>().setFriendly(true);
            shipBullet.gameObject.GetComponent<BulletScript>().updateValues(bulletSpeed, bulletWidth, bulletHeight, bulletPierce);

            cooldownTimer = cooldownTime;
        }
    }
}
