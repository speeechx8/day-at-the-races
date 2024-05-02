using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class Slime : MonoBehaviour {

	private splineMove move;
	private bool hasFinished;
	private Sprite slimeSprite;

	public bool HasFinished
	{
		get
		{
			return hasFinished;
		}
	}

	public Sprite SlimeSprite
	{
		get
		{
			return slimeSprite;
		}
	}

	// Use this for initialization
	void Awake () 
	{
		hasFinished = false;
		move = gameObject.GetComponent<splineMove>();
		slimeSprite = gameObject.GetComponent<Sprite>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartRace()
	{
		if(move != null)
		{
			move.StartMove();
		}
		else
		{
			Debug.Log(this + " is null");
		}
	}

	public void RandomSpeed()
	{
		float rand = Random.Range(1.3f, 1.45f);
		move.ChangeSpeed(rand);
	}

	public void OnFinish()
	{
		hasFinished = true;
	}
}
