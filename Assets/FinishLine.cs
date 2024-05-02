using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

	private BoxCollider2D boxCol2d;

	private string winner;

	public string Winner
	{
		get
		{
			return winner;
		}
	}

	// Use this for initialization
	void Start () {
		boxCol2d = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		winner = col.tag;
		TurnOffBoxCollider();
		// 
	}

	private void TurnOffBoxCollider()
	{
		boxCol2d.enabled = false;
	}

	public void TurnOnBoxCollider()
	{
		boxCol2d.enabled = true;
	}
}
