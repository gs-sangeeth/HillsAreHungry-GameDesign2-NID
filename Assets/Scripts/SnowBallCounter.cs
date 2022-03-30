using UnityEngine;

public class SnowBallCounter : MonoBehaviour
{
    public static SnowBallCounter instance;

    [HideInInspector]
    public int snowBallCount = 0;

    void Start()
    {
        instance = this;
    }
}
