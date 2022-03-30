using UnityEngine;

public class SnowBallCounter : MonoBehaviour
{
    public static SnowBallCounter instance;

    [HideInInspector]
    public int snowBallCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.snowBallCount);
    }
}
