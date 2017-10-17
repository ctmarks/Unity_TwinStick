using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private bool gameOver = false;
    private PlayerController player;
    private float t = 0;
    private float duration = 3;
    public GameObject canvasGroup;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckEnemyAmount();
        CheckPlayerHealth();
        CheckGameState();
	}

    void CheckEnemyAmount() {
        GameObject[] enemyAmount = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyAmount.Length == 0) {
            gameOver = true;
        }
    }
    void CheckPlayerHealth() {
        //check to see if player is dead
    }
    void CheckGameState() {
        if(gameOver == true) {
            //if player health > 0 you win
            //if player health < 0 you lose
            Debug.Log("fade alpha");
            canvasGroup.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, t);
            if(t < 1) {
                t += Time.deltaTime / duration;
            }
        }
    }
}
