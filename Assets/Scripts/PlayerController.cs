using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletSpawner;
    public GameObject muzzleFlash;
    public float moveSpeed;
    public float rotationSpeed;
    public float fireRate;
    

    private float timer = 0;
    private Rigidbody rigid;
    
    

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody>();
	}

    void FixedUpdate() {
        PlayerMoveRigid(); 
    }

    // Update is called once per frame
    void Update () {
        PlayerMove();
        PlayerRotateFire();   
    }

    void PlayerMoveRigid() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * moveSpeed;
        rigid.velocity = movement;
    }

    void PlayerMove() {
        //move player based on axis input, just updating transform.position
        //if (Input.GetAxis("Vertical") != 0) {
        //    Vector3 moveVert = new Vector3(0, 0, (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime));
        //    //Vector3 newPosition = moveVert;
        //    //newPosition.z = Mathf.Clamp(newPosition.z, -9f, 9f);
        //    transform.position += moveVert;
        //    Vector3 playerPos = transform.position;
        //    if(playerPos.z >= 8) {
        //        playerPos.z = 8;
        //        transform.position = playerPos;
        //    }
        //    else if(playerPos.z <= -8) {
        //        playerPos.z = -8;
        //        transform.position = playerPos;
        //    }
        //}

        //if (Input.GetAxis("Horizontal") != 0) {
        //    Vector3 moveHoriz = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
        //    transform.position += moveHoriz;
        //    Vector3 playerPos = transform.position;
        //    if (playerPos.x >= 16) {
        //        playerPos.x = 16;
        //        transform.position = playerPos;
        //    } else if (playerPos.x <= -16) {
        //        playerPos.x = -16;
        //        transform.position = playerPos;
        //    }
        //}
    }

    void PlayerRotateFire() {
        if (Input.GetAxisRaw("LookandShoot2") != 0 || Input.GetAxisRaw("LookandShoot") != 0) {
            //rotate player in direction of right stick
            Vector3 lookDirection = new Vector3(Input.GetAxisRaw("LookandShoot2"), 0, Input.GetAxisRaw("LookandShoot"));
            transform.forward = Vector3.Lerp(transform.forward, lookDirection, rotationSpeed * Time.deltaTime);
        }
        //fire bullets when player holds trigger and the fire rate timer is up
        timer += 1 * Time.deltaTime;
        if (Input.GetAxisRaw("TriggerFire") != 0 || Input.GetKey(KeyCode.Mouse0)) {
            PlayerFire();
        }
    }

    void PlayerFire() {
        if (timer >= fireRate) {
            GameObject flash = Instantiate(muzzleFlash, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            Destroy(flash, flash.GetComponent<ParticleSystem>().main.duration);
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            timer = 0;
        }
    }
}
