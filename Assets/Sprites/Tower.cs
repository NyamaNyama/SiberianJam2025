using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRadius = 3f; // Радиус атаки башни

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Цвет радиуса
        Gizmos.DrawWireSphere(transform.position, attackRadius); // Рисуем круг радиуса
    }
}
