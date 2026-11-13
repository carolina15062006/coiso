using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ComecarJogo()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do jogo!");
        Application.Quit();
    }
}