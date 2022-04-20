using UnityEngine;

public class SnowBallGenerator : MonoBehaviour
{

    public float timeBetweenNewSnowBallFall = 5f;
    public GameObject snowBall;
    public GameObject meteor;

    [Range(0f, 100f)]
    public float meteorChance;

    private float timer;

    private void Start()
    {
        timer = timeBetweenNewSnowBallFall;
    }


    private void Update()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0;

        timer -= Time.deltaTime;

        int ran = Random.Range(1, 100);

        if (timer <= 0f)
        {
            if (ran < meteorChance)
            {
                Instantiate(meteor, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(snowBall, pos, Quaternion.identity);
            }
            timer = timeBetweenNewSnowBallFall;
        }
    }

}
