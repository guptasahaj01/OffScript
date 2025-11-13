using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f) Destroy(gameObject);
    }
}