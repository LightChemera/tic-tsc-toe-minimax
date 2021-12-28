using UnityEngine.SceneManagement;
using UnityEngine;

public class SrartGame : MonoBehaviour
{
    public void Play(int index)
    {      
        SceneManager.LoadScene(index);
    }
}
