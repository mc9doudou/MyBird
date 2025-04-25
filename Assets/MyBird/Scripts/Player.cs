using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;

        //����
        private bool keyJump = false;           //���� Ű ��ǲ üũ
        [SerializeField]
        private float jumpForce = 5f;           //���������� �ִ� ��

        //ȸ��
        private Vector3 birdRotation;
        //���� �ö󰥶� ȸ�� �ӵ�
        [SerializeField]
        private float upRotate = 2.5f;
        //�������� ȸ�� �ӵ�
        [SerializeField]
        private float downRotate = -5f;

        //�̵�
        //�̵��ӵ� - Translate �����ϸ� �ڵ� ���������� �̵�
        [SerializeField] 
        private float moveSpeed = 5f;

       
        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //����
            rb2D = this.GetComponent<Rigidbody2D>();
            
            //�ʱ�ȭ
            
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
            //��ǲó�� 
            InputBird();
            //���� ȸ��
            RotateBird();
            //�� �̵�
            MoveBird();
        }
        #endregion

        #region Custom Method
        //��ǲ �Լ�ó��
        void InputBird()
        {
            //�����̽�Ű �Ǵ� ���콺 ��Ŭ�� �Է¹ޱ� 
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);
        }

        //���� �����ϱ�
        void JumpBird()
        {
            //�Ʒ��ʿ��� �������� ���� �ش�
            //rb2D.AddForce(Vector2.up * jumpForce);
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        //���� ȸ���ϱ�
        void RotateBird()
        {
            //�����ؼ� �ö󰥶� �ִ� + 30�� ���� ȸ��  : retateSpeed = 2.5f uprotate
            //�������� �ּ� - 90������ ȸ��    : rotateSpeed = -5f downrotate
            float rotateSpeed = 0f;
            if (rb2D.linearVelocity.y >0f)
            {
                rotateSpeed = upRotate;
            }
            else if (rb2D.linearVelocity.y <= 0f)
            {
                rotateSpeed = downRotate;
            }
            birdRotation = new Vector3(0f, 0f,Mathf.Clamp((birdRotation.z + rotateSpeed),-90f,30f));
            this.transform.eulerAngles = birdRotation;
        }   
        void MoveBird()
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }
        #endregion
    }
}