using UnityEngine;
using TMPro;
namespace MyBird
{
    //���ھ� �ؽ�Ʈ�� �׸���
    public class DrawScore : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI scoreText;
        #endregion

        void Update()
        {
            scoreText.text = GameManager.Score.ToString();
        }
    }
}