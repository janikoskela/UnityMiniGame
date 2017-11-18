using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rigidBody;
	private readonly static string TAG_PICKUP = "pickup";
	public float speed;
	private int scoreCount = 0;
	public Text scoreText;
	private int pickupCount;
	public Text victoryText;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		GameObject[] pickupObjects = GameObject.FindGameObjectsWithTag(TAG_PICKUP);
		pickupCount = pickupObjects.Length;
	}

	void FixedUpdate () {
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontalMovement, 0.0f, verticalMovement) * speed;
		rigidBody.AddForce (movement);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag (TAG_PICKUP)) {
			other.gameObject.SetActive (false);
			scoreCount++;
			updateScoreText (scoreCount);
			if (scoreCount == pickupCount)
				victoryText.gameObject.SetActive (true);
		}
	}

	void updateScoreText(int scoreCount) {
		scoreText.text = "Score: " + scoreCount;
	}
}
