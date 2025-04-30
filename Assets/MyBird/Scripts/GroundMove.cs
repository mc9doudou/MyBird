using UnityEngine;
namespace MyBird
{
    //배경 스크롤 구현
    public class GroundMove : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private float moveSpeed = 5f;
        #endregion
        private void Update()
        {
            //배경 이동 
            Move();
        }

        //배경을 왼쪽 (-x) 방향으로 이동 ,
        //배경의 x좌표가 -8.4보다 같거나 작으면 x 좌표를 제자리로 놓는다
        void Move()
        {
            if (GameManager.IsStart == false)
            {
                return;
            }

            float speed = (GameManager.IsDeath==true) ? (moveSpeed / 4f) : moveSpeed;
            
            //왼쪽으로 moveSpeed 만큼 이동 
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);

            //
            if (transform.localPosition.x <= -8.4f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x+8.4f, transform.localPosition.y, transform.localPosition.z);
            }
        }

       
    }
}