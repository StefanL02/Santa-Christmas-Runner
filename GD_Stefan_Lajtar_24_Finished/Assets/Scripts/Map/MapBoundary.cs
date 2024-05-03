using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    public static float leftSide = -3.4f;
    public static float rightSide = 3.4f;
    public float visibleLeft;
    public float visibleRight;

    // Update is called once per frame
    void Update()
    {
        visibleLeft = leftSide;
        visibleRight = rightSide;
    }
}
