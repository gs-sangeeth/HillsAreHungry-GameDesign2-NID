using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public int snowBallCount = 0;

    [HideInInspector]
    public GameObject bottomSnowBall;

    public Text snowBallCountText; 

    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        snowBallCountText.text = snowBallCount.ToString();
    }

    public void DestroySnowBalls(int count)
    {
        bottomSnowBall.GetComponent<Snowball>().DestroySnowBalls();
    }
}
