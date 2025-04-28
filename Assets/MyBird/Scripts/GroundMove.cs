using UnityEngine;
namespace MyBird
{
    //��� ��ũ�� ����
    public class GroundMove : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private float moveSpeed = 5f;
        #endregion
        private void Update()
        {
            //��� �̵� 
            Move();
        }

        //����� ���� (-x) �������� �̵� ,
        //����� x��ǥ�� -8.4���� ���ų� ������ x ��ǥ�� ���ڸ��� ���´�
        void Move()
        {
            if (!GameManager.IsStart)
                return;

            //�������� moveSpeed ��ŭ �̵� 
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);

            //
            if (transform.localPosition.x <= -8.4f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x+8.4f, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}