using UnityEngine;
namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;
        private AudioSource audioSource;
        public Animator animator;

        public DrawScore drawScore;
       
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

        //UI
        public GameObject ReadyUI;
        public GameObject resultUI;
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();
            audioSource = this.GetComponent<AudioSource>();
            //초기화
            //sampleAction += drawScore.drawScoreText;
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
            /*if (GameManager.IsDeath)
            {
                return;
            }*/

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
                //Debug.Log("크라운드 충돌");
                DieBird();
            }
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //collision : 부딛힌 콜라이더 정보를 가지고 있다
            if (collision.gameObject.tag == "Point")
            {
                GameManager.Score++;

                    //SFX
                    audioSource.Play();

                //sampleAction?.Invoke();
                //Debug.Log($"점수 획득:{GameManager.Score}");
            }
            else if (collision.gameObject.tag == "Pipe")
            {
                //Debug.Log("기동 충돌");
                DieBird();
            }
        }

        #endregion

        #region Custom Method
        //인풋 함수처리
        void InputBird()
        {
            if (GameManager.IsDeath)
                return;
#if UNITY_EDITOR
            //스페이스키 또는 마우스 왼클릭 입력받기 
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);
#else
            //터치 인풋 처리
            if (Input.touchCount > 0)
            {
                //첫번째 터치만 처리
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    keyJump |= true;
                }
            }
#endif

            //게임 시작전이고 키가 눌리면 
            if (GameManager.IsStart == false && keyJump == true)
            {
            StartMove();
            }
        }

        //버드 점프하기
        void JumpBird()
        {
            if (GameManager.IsDeath)
                return;
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
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;
            
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        //버드 죽음
        void DieBird()
        {
            //두번 죽음 체크
            if (GameManager.IsDeath)
                return;

            GameManager.IsDeath = true;
            animator.enabled = false;
            rb2D.linearVelocity = Vector2.zero;

            //VFX, SFX

            //UI
            resultUI.SetActive(true);

        }

        //버드 이동 시작
        void StartMove()
        {
            GameManager.IsStart = true;
            ReadyUI.SetActive(false);
        }

        
#endregion
    }
}