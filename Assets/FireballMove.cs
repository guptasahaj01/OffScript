using UnityEngine;

public class FireballArc : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float height = 2f;        // FLAT arc
    public float duration = 1.4f;
    private float t = 0f;

    void Start()
    {
        startPoint = transform.position;

        if (endPoint == Vector2.zero)
        {
            float randomX = startPoint.x + Random.Range(-4f, 4f);
            endPoint = new Vector2(randomX, startPoint.y - 6f);
        }
    }

    void Update()
    {
        t += Time.deltaTime / duration;

        Vector2 pos = Vector2.Lerp(startPoint, endPoint, t);

        // FLATTER ARC (physics projectile style)
        float arc = (t - t * t) * height * 2f;
        pos.y += arc;

        transform.position = pos;

        if (t >= 1f)
            Destroy(gameObject, 0.1f);
    }
}