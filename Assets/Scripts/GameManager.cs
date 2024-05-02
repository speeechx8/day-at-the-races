using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private Button raceBtn;
	[SerializeField]
	private Bettor[] bettor;

	[SerializeField]
	private Slime[] slime;
	[SerializeField]
	private GameObject winnerPanel;
	[SerializeField]
	private Image betWin;
	[SerializeField]
	private Image slimeWin;

	private static string[] whoBet = new string[3];
	private static int[] betAmt = new int[3];
	private static string[] racer = new string[3];
	private bool raceStarted;
	private bool raceOver;
	private string slimeWinner;
	private string bettorWinner;
	private Button winBtn;
	private GameObject finish;
	private FinishLine finishLine;

	// Use this for initialization
	void Awake () {
		raceBtn = raceBtn.GetComponent<Button>();
		winBtn = winnerPanel.GetComponentInChildren<Button>();
		betWin = betWin.GetComponent<Image>();
		slimeWin = slimeWin.GetComponent<Image>();
		finish = GameObject.Find("FinishLine");
		finishLine = finish.GetComponent<FinishLine>();
		raceStarted = false;
		winnerPanel.SetActive(false);
		GetBettors();
		GetRacers();
	}
	
	// Update is called once per frame
	void Update () {
		raceBtn.onClick.AddListener(RaceStart);
		if(raceStarted)
		{
			Race();
		}
		if(raceOver)
		{
			winBtn.onClick.AddListener(CollectMoney);
		}
	}

	private void CollectBet()
	{
		for(int i = 0; i < bettor.Length; i++)
		{
			if(bettor[i].BetPlaced)
			{
				whoBet[i] = bettor[i].tag;
				betAmt[i] = bettor[i].BetAmt;
				racer[i] = bettor[i].Racer;
			}
		}
	}

	private void GetBettors()
	{
		for(int i = 0; i < bettor.Length; i++)
		{
			bettor[i] = bettor[i].GetComponent<Bettor>();
		}
	}

	private void GetRacers()
	{
		for(int i = 0; i < slime.Length; i++)
		{
			slime[i] = slime[i].GetComponent<Slime>();
		}
	}

	private void RaceStart()
	{
		CollectBet();
		for(int i = 0; i < slime.Length; i++)
		{
			slime[i].StartRace();
		}
		raceStarted = true;
	}

	private void Race()
	{
		
	}

	private void GetWinner()
	{
		// bool hasWinner = false;
		// if(!hasWinner)
		// {
		// 	for(int i = 0; i < slime.Length; i++)
		// 	{
		// 		if(slime[i].HasFinished)
		// 		{
		// 			slimeWinner = slime[i].tag;
		// 			Debug.Log("Winner is " + slimeWinner);
		// 			slimeWin.sprite = slime[i].SlimeSprite;
		// 			hasWinner = true;
		// 		}
		// 	}
		// }
		// return hasWinner;

		slimeWinner = finishLine.Winner;
	}

	public void FirstPlace(string winner)
	{
		slimeWinner = winner;
	}

	private void CompareWinners()
	{
		for(int i = 0; i < bettor.Length; i++)
		{
			if(bettor[i].Racer == slimeWinner)
			{
				bettorWinner = bettor[i].tag;
				betWin.sprite = bettor[i].BettorSprite;
			}
			else
			{
				betWin.enabled = false;
			}
		}
	}

	private void DisplayWinners()
	{
		winnerPanel.SetActive(true);
		// Bettor picture and slime picture should be set here since the panel is inactive until here
	}

	private void CollectMoney()
	{
		// Winner collects money when win button is pressed
		for(int i = 0; i < bettor.Length; i++)
		{
			if(bettorWinner == bettor[i].tag)
			{
				bettor[i].Money += bettor[i].BetAmt * 2;
				raceStarted = false;
				raceOver = false;
				Debug.Log("Money recieved");
			}
		}
		betWin.enabled = true;
		winnerPanel.SetActive(false);
	}
}
