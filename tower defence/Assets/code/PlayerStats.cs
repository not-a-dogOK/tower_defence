using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;


	public GameObject GameOver;

	void Start ()
	{
		Money = startMoney;
		Lives = startLives;

		GameOver.SetActive(false);
	}
	void Update()
    {
		if (Lives <= 0)
		{
			GameOver.SetActive(true);
			Lives = 0;

		}
	}

}
