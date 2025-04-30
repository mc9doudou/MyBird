using UnityEngine;
namespace MyBird
{
    //������ ��ü �÷ο츦 �����ϴ� Ŭ����
    //��� -> �̵� -> ����(���ó��)
    //static ó�� : �̱��� Ŭ����, ����(static) ����  
    public class GameManager : MonoBehaviour
    {
        #region Property
        //�̵� ���� üũ
        public static bool IsStart { get; set; }
        //���� üũ
        public static bool IsDeath { get; set; }

        //���� ���ھ�
        public static int Score { get; set; }
        //�ְ� ����
        public static int BestScore { get; set; }
        #endregion

        private void Start()
        {
            //�ְ����� ��������, 
            BestScore = PlayerPrefs.GetInt("BestScore", 0);

            //�ʱ�ȭ
            IsStart = false;
            IsDeath = false;
            Score = 0;

        }

        private void Update()
        {
            
        }
        
    }
}