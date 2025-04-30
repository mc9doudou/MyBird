using UnityEngine;
namespace MyBird
{
    //카메라 제어 - 플레이어 이동에 따라 같이 이동한다 
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //플레이어 오브젝트
        public Transform player;
        [SerializeField]private float offsetX = 1.5f;
        #endregion
        private void Start()
        {
            //플레이어 위치 초기화
            FollowPlayer();
        }

        private void LateUpdate()
        {
            FollowPlayer();
        }

        //카메라의 위치를 플레이어의 위치에서 z방향으로 -10만큼 위치하게 만든다.
        //카메라의 위치에서 플레이어의 x위치값만 동일하게 따라간다
        void FollowPlayer()
        {
            /*Vector3 camera = new Vector3(player.position.x, 0, player.position.z-10f);
            transform.position = camera;*/
            this.transform.position = new Vector3(player.position.x+ offsetX, transform.position.y, transform.position.z);
        }
    }
}