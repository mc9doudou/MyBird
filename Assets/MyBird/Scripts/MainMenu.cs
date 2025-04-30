using UnityEngine;
namespace MyBird
{
    public class MainMenu : MonoBehaviour
    {
        #region
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";

        //치트키
        [SerializeField] private bool isCheat = false;
        #endregion

        private void Update()
        {
#if UNITY_EDITOR
            //치트키
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetSaveData();
            }
#endif
        }

        public void StartGameScene()
        {
            fader.FadeTo(loadToScene);
        }
    
        void ResetSaveData()
        {
            if (isCheat == false)
            {
                return;
            }
            Debug.Log("ResetSaveData");
            PlayerPrefs.DeleteAll();
        }
    }
}