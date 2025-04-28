using UnityEngine;
using System.Collections;
namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;

        //점프
        private bool keyJump = false;           //점프 키 인풋 체크
        [SerializeField]
        private float jumpForce = 5f;           //위방향으로 주는 힘

        //회전
        private Vector3 birdRotation;
        //위로 올라갈때 회전 속도
        [SerializeField]
        private float upRotate = 2.5f;
        //내려갈때 회전 속도
        [SerializeField]
        private float downRotate = -5f;

        //이동
        //이동속도 - Translate 시작하면 자동 오른쪽으로 이동
        [SerializeField] 
        private float moveSpeed = 5f;

        //대기
        [SerializeField] private float readyForce = 1f; 
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();
            
            //초기화
            
        }
        private void FixedUpdate()
        {
            if (keyJump)
            {
                JumpBird();
                keyJump = false;
            }
        }
        private void Update()
        {
            //인풋처리 
            InputBird();

            if (GameManager.IsStart == false)
            {   
                //버드 대기
                ReadyBird();
                return;
            }

            //버드 회전
            RotateBird();

            //새 이동
            MoveBird();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //collision : 부딛힌 콜라이더 정보를 가지고 있다
            if (collision.gameObject.tag == "Ground")
            {
                Debug.Log("크라운드 충돌");
            }
            else if (collision.gameObject.tag == "Pipe")
            {
                Debug.Log("기동 충돌");
            }

        }

        private void OnTiggerEnter2D(Collision2D collision)
        {
            //collision : 부딛힌 콜라이더 정보를 가지고 있다
            if (collision.gameObject.tag == "Point")
            {
                Debug.Log("점수 획득");
            }
        }

        #endregion

        #region Custom Method
        //인풋 함수처리
        void InputBird()
        {
            //스페이스키 또는 마우스 왼클릭 입력받기 
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            //게임 시작전이고 키가 눌리면 
            if (GameManager.IsStart == false && keyJump == true)
            {
                GameManager.IsStart = true;
            }
        }

        //버드 점프하기
        void JumpBird()
        {
            //아래쪽에서 위쪽으로 힘을 준다
            //rb2D.AddForce(Vector2.up * jumpForce);
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        //버드 회전하기
        void RotateBird()
        {
            //점프해서 올라갈때 최대 + 30도 까지 회전  : retateSpeed = 2.5f uprotate
            //내려갈때 최소 - 90도까지 회전    : rotateSpeed = -5f downrotate
            float rotateSpeed = 0f;
            if (rb2D.linearVelocity.y >0f)
            {
                rotateSpeed = upRotate;
            }
            else if (rb2D.linearVelocity.y < 0f)
            {
                rotateSpeed = downRotate;
            }
            birdRotation = new Vector3(0f, 0f,Mathf.Clamp((birdRotation.z + rotateSpeed),-90f,30f));
            this.transform.eulerAngles = birdRotation;
        } 
        
        //버드 대기
        void ReadyBird()
        {
            //아래쪽에서 떨어지지 않도록 위쪽으로 힘을 준다
            if (rb2D.linearVelocity.y < 0f)
            {
                rb2D.linearVelocity = Vector2.up * readyForce;
            }
        }

        //버드 이동
        void MoveBird()
        {
            if (GameManager.IsStart == false)
                return;
            
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }
        #endregion
    }
}