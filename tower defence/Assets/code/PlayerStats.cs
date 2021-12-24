using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

    /*
     * Change your class so that it inherits from MonoBehaviour.
        You won't be able to have a constructor for your class anymore,
        but you will be able to attach it directly to a game object and have it drive things like position and rotation.

     */

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;


    public GameObject GameOver;

    void Start()
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
