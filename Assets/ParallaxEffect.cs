using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect; // 1 = se mueve con el personaje, 0 = no se mueve

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}