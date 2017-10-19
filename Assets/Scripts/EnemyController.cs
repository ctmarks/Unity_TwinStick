using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float points;
    public GameController gameController;

    Transform player;
    NavMeshAgent nav;
    

    void Awake() {
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
        }
        //transform.rotation = Quaternion.LookRotation(transform.position + player.position);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "PlayerBullet") {
            gameController.AddScore(points);        
            Destroy(gameObject);
        }
    }
}
