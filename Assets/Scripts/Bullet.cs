using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public GameObject damageEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Enemy") {
            Instantiate(damageEffect, collision.contacts[0].point, damageEffect.transform.rotation);
        }
    }
}
