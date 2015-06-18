using UnityEngine;
using System.Collections;

public class Dracula_Script : MonoBehaviour {

	// Use this for initialization
	void Awake()
	{
		GameManager_Script._Player = this.gameObject;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
