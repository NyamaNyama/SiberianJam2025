using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Параметры врага")]
    public float speed = 2f;
    public int hp = 3;
    public int damage = 1;

    private int currentHP;
    private int currentPoint;
    private WaypointPath path;

    public void Init(WaypointPath waypointPath)
    {
        path = waypointPath;
        transform.position = path.GetWaypoint(0).position;
        currentPoint = 1;
        currentHP = hp;
    }

    void Update()
    {
        if (path == null || currentPoint >= path.Length) return;

        Transform target = path.GetWaypoint(currentPoint);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint++;
            if (currentPoint >= path.Length)
            {
                GameManager.Instance.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
            Destroy(gameObject);
    }
}
