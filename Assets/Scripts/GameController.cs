using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    static float Score = 00;

    public CanvasGroup gameOverCanGroup;
    public CanvasGroup hudCanGroup;
    public Text canvasScore;

    private bool gameOver = false;
    private PlayerController player;
    private float t = 0;
    private float duration = 3;
    

    
    


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        canvasScore.text = "00";
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
            gameOverCanGroup.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, t);
            if(t < 1) {
                t += Time.deltaTime / duration;
            }
            hudCanGroup.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, t);
            if (t > 0) {
                t += Time.deltaTime / duration;
            }
        }
    }
    public void AddScore(float points) {
        Score += points;
        canvasScore.text = Score.ToString();
    }
}
