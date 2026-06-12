using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;

    private MeshRenderer mr;

    void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
