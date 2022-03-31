using UnityEngine;

public class DialogueBoxSpawner : MonoBehaviour
{
    public static DialogueBoxSpawner instance;

    public GameObject dialogueBox;

    private GameObject db;
    public float minInterval = 3f;
    public float maxInterval = 15f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        timer = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (db == null)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0 && db == null)
        {
            db = Instantiate(dialogueBox, transform.position, Quaternion.identity);
            timer = Random.Range(minInterval, maxInterval);
        }
    }

    public void StartTimer()
    {
        timer = Random.Range(minInterval, maxInterval);
    }
}
