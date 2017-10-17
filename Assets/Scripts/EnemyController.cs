using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);
        if (nav.stoppingDistance <= 0) {
            meleeAttack();
        }
        //transform.rotation = Quaternion.LookRotation(transform.position + player.position);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "PlayerBullet") {            
            Destroy(gameObject);
        }
    }

    void meleeAttack() {
        
    }

}
