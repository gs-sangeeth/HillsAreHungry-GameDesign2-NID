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

    [HideInInspector]
    public bool GameOver = false;

    public GameObject gameOverText;

    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        snowBallCountText.text = snowBallCount.ToString();
        if (GameOver)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }
    }

    public void DestroySnowBalls(int count)
    {
        bottomSnowBall.GetComponent<Snowball>().DestroySnowBalls();
    }

    public void UpdateAllTimers()
    {
        GameObject[] dbs = GameObject.FindGameObjectsWithTag("DialogueBox");
        foreach(GameObject db in dbs)
        {
            db.GetComponent<DialogueBox>().GiveMoreTime();
        }
    }

}
