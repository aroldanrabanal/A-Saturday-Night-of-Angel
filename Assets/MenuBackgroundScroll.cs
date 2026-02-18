using UnityEngine;

public class MenuBackgroundScroll : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -50f)
        {
            transform.position = new Vector3(50f, transform.position.y, transform.position.z);
        }
    }
}