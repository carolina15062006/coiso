using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador : MonoBehaviour
{
    public void reiniciar()
    {
        SceneManager.LoadScene("codigo");
    }
}