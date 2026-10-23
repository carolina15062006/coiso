using UnityEngine;
using UnityEngine.InputSystem;

public class andar : MonoBehaviour
{
    public Rigidbody jogador;

    void Update()
    {
        jogador.AddForce(0, 0, 2);

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            jogador.AddForce(-5, 0, 0);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            jogador.AddForce(5, 0, 0);
        }
    }
}
