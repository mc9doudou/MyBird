using UnityEngine;
namespace MyBird
{
    //PipeKiller�� �浹�ϴ� ��� �浹ü�� kill �Ѵ�

    //1. �浹���� �ʴ´�, 2. �浹���� kill ���� �ʴ´�
    public class PipeKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}