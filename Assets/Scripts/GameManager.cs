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

    public SpriteRenderer bgRenderer;
    public SpriteRenderer mountainRenderer;

    public Sprite[] bgs;
    public Sprite[] mountains;

    [HideInInspector]
    public bool GameOver = false;

    float timer = 1f;
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
            bgRenderer.sprite = bgs[1];
            mountainRenderer.sprite = mountains[1];

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                bgRenderer.sprite = bgs[2];
                mountainRenderer.sprite = mountains[1];
                Time.timeScale = 0;
                gameOverText.SetActive(true);
            }
        }
    }

    public void DestroySnowBalls(int count)
    {
        bottomSnowBall.GetComponent<Snowball>().DestroySnowBalls();
    }

    public void UpdateAllTimers()
    {
        GameObject[] dbs = GameObject.FindGameObjectsWithTag("DialogueBox");
        foreach (GameObject db in dbs)
        {
            db.GetComponent<DialogueBox>().GiveMoreTime();
        }
    }

}
