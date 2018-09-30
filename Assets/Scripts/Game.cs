using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour{
	public Ball ball;
	public Vector3 ballStartPos;

	public Player player1;
	public Goal player1Goal;
	public byte player1Score;
	public TextMesh player1ScoreText;

	public Player player2;
	public Goal player2Goal;
	public byte player2Score;
	public TextMesh player2ScoreText;

	// Use this for initialization
	void Start(){
		ballStartPos = ball.transform.position;
		player1Goal.OnTrigger += ()=>{
			player2ScoreText.text = (++player2Score).ToString();
			StartCoroutine(WinWait("Player 2"));
		};
		player2Goal.OnTrigger += ()=>{
			player1ScoreText.text = (++player1Score).ToString();
			StartCoroutine(WinWait("Player 1"));
		};
	}

	public IEnumerator WinWait(string winner){
		// insert win thing here
		yield return new WaitForSeconds(1);
		ResetGame();
	}

	private void Update(){
		float topSpeed = Mathf.Abs(ball.Rigidbody.velocity.y)+1;
		if(topSpeed < 10) topSpeed = 10;
		player1.speed = player2.speed = topSpeed;

		if(Input.GetKeyDown(KeyCode.Space)) ResetGame();
	}

	void ResetGame(){
		ball.Rigidbody.position = ballStartPos;
		ball.Start();
		player1.ResetPos();
		player2.ResetPos();
	}

	void RestartGame(){
		player1Score = player2Score = 0;
		ResetGame();
	}
}
/*
public struct PlayerInfo{
	public Player player;
	public Collider playerGoal;
	public byte playerScore;
}
*/
