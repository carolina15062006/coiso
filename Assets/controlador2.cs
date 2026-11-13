using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador2 : MonoBehaviour
{
    public GameObject fim;

    public void reiniciar()
    {
        Debug.Log("CAIU NO NÍVEL 2 - A reiniciar!");
        SceneManager.LoadScene("Nivel 2");
    }

    public void passou()
    {
        Debug.Log("ACABOU O NÍVEL 2 - A voltar ao Menu!");
        SceneManager.LoadScene("Menu");
    }
}