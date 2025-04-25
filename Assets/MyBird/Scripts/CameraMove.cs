using UnityEngine;
namespace MyBird
{
    public class CameraMove : MonoBehaviour
    {
        public Transform target;
        public float yFiexed = 0f;
        public float zFiexed = -10f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 newPos = new Vector3(target.position.x, yFiexed, zFiexed);
            transform.position = newPos;
        }
    }
}