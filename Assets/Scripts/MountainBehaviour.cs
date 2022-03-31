using UnityEngine;

public class MountainBehaviour : MonoBehaviour
{
    public static MountainBehaviour instance;

    public GameObject dialogueBox;

    private GameObject db;
    public float minInterval = 3f;
    public float maxInterval = 15f;
    float timer;

    public Sprite[] expressions;
    public SpriteRenderer expressionRenderer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        timer = Random.Range(minInterval, maxInterval);

        expressionRenderer.sprite = expressions[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (db == null)
        {
            timer -= Time.deltaTime;
            expressionRenderer.sprite = expressions[0];
        }
        if (timer <= 0 && db == null)
        {
            db = Instantiate(dialogueBox, transform.position, Quaternion.identity);
            timer = Random.Range(minInterval, maxInterval);
            expressionRenderer.sprite = expressions[1];
        }
        if(db != null)
        {
            float timerPercent = db.GetComponent<DialogueBox>().percent;
            if(timerPercent < 0.25)
            {
                expressionRenderer.sprite = expressions[1];
            }
            else if(timerPercent < 0.5)
            {
                expressionRenderer.sprite = expressions[2];
            }
            else if(timerPercent < 0.75)
            {
                expressionRenderer.sprite = expressions[3];
            }
            else
            {
                expressionRenderer.sprite = expressions[4];
            }
        }
    }

    public void StartTimer()
    {
        timer = Random.Range(minInterval, maxInterval);
    }
}
