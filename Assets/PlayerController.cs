using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletSpawner;
    public float rotationSpeed;
    public float fireRate;
    public GameObject muzzleFlash;

    private float timer = 0;

    
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotate player in direction of right stick
        if (Input.GetAxisRaw("LookandShoot2") != 0 || Input.GetAxisRaw("LookandShoot") != 0) {
            PlayerRotate();
        }

        //fire bullets when player holds trigger and the fire rate timer is up
        timer += 1 * Time.deltaTime;
        if (Input.GetAxisRaw("TriggerFire") != 0){
                PlayerFire();
        }
    }

    void PlayerRotate() {
            Vector3 lookDirection = new Vector3(Input.GetAxisRaw("LookandShoot2"), 0, Input.GetAxisRaw("LookandShoot"));
            transform.forward = Vector3.Lerp(transform.forward, lookDirection, rotationSpeed * Time.deltaTime);  
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
