using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public GameObject bGate;
	public GameObject gGate;
	private int greenScore;
	private int blueScore;
	private int aux=1;
	public GUIText scoreText;
	public GameObject blueText;
	public GameObject greenText;
	public GameObject bluePlayer;
	public GameObject greenPlayer;
	public Rigidbody rb;
	public GameObject blueWinText;
	public GameObject greenWinText;
	public GameObject blueLoseText;
	public GameObject greenLoseText;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		UpdateScore ();
		greenScore = 0;
		blueScore = 0;
		blueText.SetActive (false);
		greenText.SetActive (false);
		blueWinText.SetActive (false);
		greenWinText.SetActive (false);
		blueLoseText.SetActive (false);
		greenLoseText.SetActive (false);
	}


	void OnTriggerEnter(Collider other)
	{
		gameObject.SetActive (false);
		if (other.gameObject.name == "BlueGate")
		{
			greenScore++;
			greenText.SetActive (true);
			UpdateScore ();
		}
		if (other.gameObject.name == "GreenGate")
		{
			blueScore++;
			blueText.SetActive (true);
			UpdateScore ();
		}
		if (blueScore == 7)
		{
			blueText.SetActive (false);
			greenText.SetActive (false);
			blueWinText.SetActive (true);
			greenLoseText.SetActive (true);
			blueScore = 0;
			greenScore = 0;
		}
		if(greenScore == 7)
		{
			blueText.SetActive (false);
			greenText.SetActive (false);
			blueLoseText.SetActive (true);
			greenWinText.SetActive (true);
			blueScore=0;
			greenScore=0;
		}
		Invoke ("resetGame", 3);
	}

	void UpdateScore()
	{
		scoreText.text = greenScore + " - " + blueScore;
	}

	void resetGame()
	{
		blueText.SetActive (false);
		greenText.SetActive (false);
		gameObject.SetActive (true);
		blueWinText.SetActive (false);
		greenWinText.SetActive (false);
		blueLoseText.SetActive (false);
		greenLoseText.SetActive (false);
		rb.velocity = new Vector3 (0f, 0f, 0f);
		transform.position = new Vector3 (0f, 0f, 0.315f);
		bluePlayer.transform.position = new Vector3 (0f, -3f, 0.49f);
		greenPlayer.transform.position = new Vector3 (0f, 3f, 0.49f);
		UpdateScore ();
	}
}
