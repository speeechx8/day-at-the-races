using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bettor : MonoBehaviour {

	[SerializeField]
	private Button betBtn;
	[SerializeField]
	private Text moneyLbl;
	[SerializeField]
	private Dropdown betAmtLbl;
	[SerializeField]
	private Dropdown racerChoice;
	private int money;
	private int betAmt;
	private string racer;
	private bool betPlaced;
	private Sprite bettorSprite;

	// Public access to GameManager to return amount of money won.
	public int Money
	{
		get
		{
			return money;
		}
		set
		{
			money = value;
		}
	}
	// Public access to GameManager to hold bet amount for each bettor.
	public int BetAmt
	{
		get
		{
			return betAmt;
		}
	}
	// Public access to GameManager to hold racer choice for each bettor.
	public string Racer
	{
		get
		{
			return racer;
		}
	}
	// Public access to GameManager to see if bet has been placed.
	public bool BetPlaced
	{
		get
		{
			return betPlaced;
		}
	}

	public Sprite BettorSprite
	{
		get
		{
			return bettorSprite;
		}
	}

	void Awake () 
	{
		money = 300;
		betAmt = 20;
		racer = null;
		betPlaced = false;
		betBtn = betBtn.GetComponent<Button>();
		bettorSprite = gameObject.GetComponent<Sprite>();
	}

	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!betPlaced)
		{
			betBtn.onClick.AddListener(Bet);
		}
	}

	private void Bet()
	{
		AmountBet();
		SlimeChoice();

		if((money >= betAmt) && !betPlaced)
		{
			money -= betAmt;
			betPlaced = true;
			UpdateMoneyLbl();
			Debug.Log(this);
			Debug.Log(betAmt);
			Debug.Log(racer);
		}
		else if(betPlaced)
		{
			Debug.Log("Bet already placed");
		}
		else
		{
			Debug.Log("Not enough money");
			betAmt = 0;
			racer = null;
			UpdateMoneyLbl();
		}
	}

	private void UpdateMoneyLbl()
	{
		moneyLbl.text = "$" + money;
		Debug.Log(money);
	}

	private void AmountBet()
	{
		int betValue = betAmtLbl.value;
		if(betValue == 0)
		{
			betAmt = 20;
		}
		else if(betValue == 1)
		{
			betAmt = 25;
		}
		else if(betValue == 2)
		{
			betAmt = 30;
		}
		else if(betValue == 3)
		{
			betAmt = 35;
		}
		else if(betValue == 4)
		{
			betAmt = 40;
		}
		else if(betValue == 5)
		{
			betAmt = 45;
		}
		else if(betValue == 6)
		{
			betAmt = 50;
		}
	}

	private void SlimeChoice()
	{
		int betOpt = racerChoice.value;
		if(betOpt == 0)
		{
			racer = "PurpleSlime";
		}
		else if(betOpt == 1)
		{
			racer = "BlueSlime";
		}
		else if(betOpt == 2)
		{
			racer = "GreenSlime";
		}
		else if(betOpt == 3)
		{
			racer = "RedSlime";
		}
	}
}
