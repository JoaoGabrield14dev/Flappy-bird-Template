using UnityEngine;

public class ObstacleMoviment : MonoBehaviour
{
    public float speed_obstacle;

    void Start()
    {
        Destroy(this.gameObject, 6);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-speed_obstacle, 0, 0);
    }
}
