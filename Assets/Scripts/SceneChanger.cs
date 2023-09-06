using UnityEngine.SceneManagement;

namespace HitmasterClone
{
    public class SceneChanger
    {
        public SceneChanger(SceneNames scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}

