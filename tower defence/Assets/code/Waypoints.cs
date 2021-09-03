using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] points;


    // takes all waypoints dad childs and makes then into an array

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}
