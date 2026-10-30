using UnityEngine;
using UnityEngine.SceneManagement;

public class mudarnivel : MonoBehaviour
{
    public void carregarproximonivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}