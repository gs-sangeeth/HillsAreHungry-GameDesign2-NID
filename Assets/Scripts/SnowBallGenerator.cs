using UnityEngine;

public class SnowBallGenerator : MonoBehaviour
{

    public float timeBetweenNewSnowBallFall = 5f;
    public GameObject snowBall;
    
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
        if(timer <= 0f)
        {
            Instantiate(snowBall, pos, Quaternion.identity);
            timer = timeBetweenNewSnowBallFall;
        }
    }

}
