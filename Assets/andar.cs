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

    private void OnCollisionEnter(Collision quem)
    {
        if (quem.gameObject.tag == "Mau")
        {
            Debug.Log("bateu");
            transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider quem)
    {
        if (quem.gameObject.tag == "Bom")
        {
            Debug.Log("passou");
        }
    }
}