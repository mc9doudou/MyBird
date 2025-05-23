using UnityEngine;
namespace MyBird
{
    //���׸� �̱��� Ŭ���� : �� ��ȯ�� �ı����� ������
    public class PersistanceSingleton<T> : Singleton<T> where T: Singleton<T>
    {
        protected override void Awake()
        {
            base.Awake();

            //�� ��ȯ�� �ı����� �ʴ´�
            DontDestroyOnLoad(gameObject);
        }
    }
}