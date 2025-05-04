using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackRadius = 3f; // ������ ����� �����

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // ���� �������
        Gizmos.DrawWireSphere(transform.position, attackRadius); // ������ ���� �������
    }
}
