using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador : MonoBehaviour
{
    public void reiniciar()
    {
        Debug.Log("REINICIAR chamado!");
        SceneManager.LoadScene("Nivel 1");
    }

    public void passou()
{
    Debug.Log("PASSOU DE NÍVEL");
}
     
}