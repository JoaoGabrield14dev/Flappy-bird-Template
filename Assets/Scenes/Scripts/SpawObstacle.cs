using UnityEngine;

public class SpawObstacle : MonoBehaviour
{
    public GameObject obstacle_obj;
    public Transform spaw_position;
    public float time_to_spaw;

    private float time_cooldown;

    void Start()
    {
        
    }

    void Update()
    {
        CooldownSpaw();
    }

    void CooldownSpaw()
    {

        if (time_cooldown > time_to_spaw)
        {
            Instantiate(obstacle_obj, new Vector3(spaw_position.position.x, Random.Range(-5, 5), spaw_position.position.z), Quaternion.identity);
            time_cooldown = 0;
        }
        else
        {
            time_cooldown += Time.deltaTime;
        }

    }
}
