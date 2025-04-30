using UnityEngine;
namespace MyBird
{
    //ī�޶� ���� - �÷��̾� �̵��� ���� ���� �̵��Ѵ� 
    public class CameraController : MonoBehaviour
    {
        #region Variables
        //�÷��̾� ������Ʈ
        public Transform player;
        [SerializeField]private float offsetX = 1.5f;
        #endregion
        private void Start()
        {
            //�÷��̾� ��ġ �ʱ�ȭ
            FollowPlayer();
        }

        private void LateUpdate()
        {
            FollowPlayer();
        }

        //ī�޶��� ��ġ�� �÷��̾��� ��ġ���� z�������� -10��ŭ ��ġ�ϰ� �����.
        //ī�޶��� ��ġ���� �÷��̾��� x��ġ���� �����ϰ� ���󰣴�
        void FollowPlayer()
        {
            /*Vector3 camera = new Vector3(player.position.x, 0, player.position.z-10f);
            transform.position = camera;*/
            this.transform.position = new Vector3(player.position.x+ offsetX, transform.position.y, transform.position.z);
        }
    }
}