using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 6f;
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnBecameInvisible() => Destroy(gameObject);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (explosionPrefab) Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}