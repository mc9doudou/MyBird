using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace MyBird
{
    //게임 결과 보여주기: 베스트스코어, 스코어 보여주고, 다시하기, 메뉴가기 버튼 기능 구현
    public class ResultUI : MonoBehaviour
    {
        #region Variables
        //Info UI
        public SceneFader fader;
        [SerializeField] private string loadToScene = "Title";

        public TextMeshProUGUI bestScore;
        public TextMeshProUGUI score;
        public TextMeshProUGUI newText;

        #endregion

        private void OnEnable()
        {
            //BestScore와 GameManager.Score 비교
            BestScore();
            score.text = GameManager.Score.ToString();
        }

        private void Update()
        {
           
        }

        public void BestScore()
        {
            if (GameManager.Score>GameManager.BestScore)
            {
                //최고점수 갱신
                GameManager.BestScore = GameManager.Score;
                //파일 저장
                PlayerPrefs.SetInt("BestScore", GameManager.Score);
                newText.text = "NEW";
            }
            else
            {
                newText.text = "";
            }
                bestScore.text = GameManager.BestScore.ToString();
        }
        


        public void Retry()
        {
            fader.FadeTo(SceneManager.GetActiveScene().name);
            /*Scene PlayScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(PlayScene.name);*/
            //Debug.Log("다시 시작");
        }

        public void GoMenu()
        {
            fader.FadeTo(loadToScene);
            //Debug.Log("메뉴로 가기");
        }

    
    }

}