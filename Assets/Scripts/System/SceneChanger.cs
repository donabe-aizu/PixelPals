using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class SceneChanger : MonoBehaviour
    {
        public void SceneChange(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}