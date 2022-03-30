using UnityEngine;

public class DialogueBoxSpawner : MonoBehaviour
{
    public GameObject dialogueBox;

    GameObject db;
    public float minInterval = 3f;
    public float maxInterval = 15f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minInterval, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && db == null)
        {
            db = Instantiate(dialogueBox,transform.position,Quaternion.identity);
        }
    }
}
