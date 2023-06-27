using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SOLID.Scripts.UI
{
    public class RestartButton : MonoBehaviour
    {
        private Button button;

        /// <summary>
        /// Since this is a demo, there is no point in doing initialization from entry point
        /// </summary>
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(ReloadScene);
        }

        public void ReloadScene()
        {
            var _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(_currentSceneIndex);
        }
    }
}
