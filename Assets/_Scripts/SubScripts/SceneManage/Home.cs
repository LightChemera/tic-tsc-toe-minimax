using UnityEngine.SceneManagement;
using UnityEngine;

public class Home : MonoBehaviour
{

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
