using UnityEngine;
namespace MyBird
{
    //������ ��ü �÷ο츦 �����ϴ� Ŭ����
    //��� -> �̵� -> ����(���ó��)
    //static ó�� : �̱��� Ŭ����, ����(static) ����  
    public class GameManager : MonoBehaviour
    {
        #region Property
        public static bool IsStart { get; set; }

        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            IsStart = false;
        }

        private void Update()
        {
            
        }
        
    }
}