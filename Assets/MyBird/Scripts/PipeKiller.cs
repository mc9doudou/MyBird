using UnityEngine;
namespace MyBird
{
    //PipeKiller와 충돌하는 모든 충돌체는 kill 한다

    //1. 충돌나지 않는다, 2. 충돌나도 kill 되지 않는다
    public class PipeKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}