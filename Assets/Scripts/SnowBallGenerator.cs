using UnityEngine;

public class SnowBallGenerator : MonoBehaviour
{

    public float timeBetweenNewSnowBallFall = 5f;
    public GameObject snowBall;
    public Transform target;
    
    private float timer;

    private void Start()
    {
        timer = timeBetweenNewSnowBallFall;
    }


    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Instantiate(snowBall, target);
            timer = timeBetweenNewSnowBallFall;
        }
    }

}
