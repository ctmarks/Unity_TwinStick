using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public GameObject damageEffect;
    public GameObject bulletSpark;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = gameObject.transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Enemy") {
            Quaternion effectRot = Quaternion.LookRotation(gameObject.transform.forward * -1);
            GameObject blood = Instantiate(damageEffect, collision.contacts[0].point, effectRot);
            Destroy(blood, blood.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }

        if(collision.gameObject.isStatic == true) {
            GameObject spark = Instantiate(bulletSpark, collision.contacts[0].point, bulletSpark.transform.rotation);
            Destroy(spark, spark.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
    }
}
