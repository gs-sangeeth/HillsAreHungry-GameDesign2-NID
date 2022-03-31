using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [HideInInspector]
    public int demand;

    public Text text;
    public GameObject TimerImage;
    public Transform TimerImageEnd;


    private Collider2D coll;

    private Vector3 timerImageStartPos;
    private Vector3 differnce;
    private Vector3 difference;

    private float timeToFulfill;
    private float timer;
    private float percent;

    // Start is called before the first frame update
    void Start()
    {
        demand = Random.Range(2, 7);
        text.text = demand.ToString();

        timeToFulfill = demand * 3f;

        coll = gameObject.GetComponent<Collider2D>();

        timerImageStartPos = TimerImage.transform.position;
        differnce = TimerImageEnd.position - timerImageStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == coll)
            {
                if (GameManager.instance.snowBallCount >= demand)
                {
                    GameManager.instance.DestroySnowBalls(demand);
                    DialogueBoxSpawner.instance.StartTimer();
                    Destroy(gameObject);
                }
            }
        }

        //timeToFulfill -= Time.deltaTime;
        //if(timeToFulfill <= 0)
        //{
        //    Debug.Log("GAME OVER");
        //}

        Debug.Log(timer);

        if (timer <= timeToFulfill)
        {
            timer += Time.deltaTime;
            percent = timer / timeToFulfill;
            TimerImage.transform.position = timerImageStartPos + differnce * percent;
        }
    }
}
