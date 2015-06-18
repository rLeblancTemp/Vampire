using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisionEnnemy : MonoBehaviour {

	Vector2 PlayerPosition;
	Vector2 ActualPosition;
    

	public float DistanceVision;
	float LevelOfdetection;
	float DistanceIncrementation;
	float DistanceToPlayer;

	public float DistanceTir;
	public float HuntingSpeed;

	//Patrouille
	public List<GameObject> CheckPoints;

	public string Pattern = "Ronde";


	// Use this for initialization
	void Start () {
		DistanceIncrementation = DistanceVision * 1.1f;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		ActualPosition = new Vector2 (transform.position.x, transform.position.y);
		PlayerPosition = new Vector2(GameManager_Script._Player.transform.position.x, GameManager_Script._Player.transform.position.y);
		DistanceToPlayer = Vector2.Distance(ActualPosition, PlayerPosition);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerPosition - ActualPosition);
		if (hit != null)
		{
				if (DistanceToPlayer <= DistanceVision)
			{
				transform.GetChild(0).GetComponent<TextMesh>().text = "!";

				if (DistanceToPlayer <= DistanceTir)
				{
					//tirer
				} else {
					gameObject.GetComponent<Rigidbody2D>().velocity = (PlayerPosition - ActualPosition).normalized * HuntingSpeed;
				}


			} 
				else if (DistanceToPlayer <= DistanceIncrementation)
			{
				transform.GetChild(0).GetComponent<TextMesh>().text = "?";
			} 
				else 
			{
				transform.GetChild(0).GetComponent<TextMesh>().text = ":-)";
				//retourner à sa routine
				gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.DrawSphere(transform.position, DistanceVision);
	}
}
