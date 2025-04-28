using UnityEngine;
namespace MyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        #region Variables
        public GameObject pipePrefab;

        [SerializeField] private float pipeTimer = 1f;
        private float countdown = 0f;

        [SerializeField] private float maxSpawnY = 3.3f;
        [SerializeField] private float minSpawnY = -1.6f;

        [SerializeField] private float maxSpawnTime = 1.05f;
        [SerializeField] private float minSpawnTime = 0.95f;
        #endregion
        //1�ʸ��� ��� �ϳ��� ����, ���� ���۽�(IsStart == true)
        void Update()
        {
            if (GameManager.IsStart == false)
                return;
            
            //Ÿ�̸�
            countdown += Time.deltaTime;
            if (countdown>= pipeTimer)
            {
                //Ÿ�̸� ��� 
                SpawnPipe();

                //Ÿ�̸� �ʱ�ȭ
                countdown = 0f;
                pipeTimer = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }

        //��� ���� 
        void SpawnPipe()
        {
            float spawnY = this.transform.position.y + Random.Range(minSpawnY, maxSpawnY);
            Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);
            Instantiate(pipePrefab,spawnPosition, Quaternion.identity);
        }

    }
}
