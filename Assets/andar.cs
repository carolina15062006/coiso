using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class andar : MonoBehaviour
{
    public Rigidbody jogador;
    public TMP_Text vida;
    public TMP_Text pontinhos;

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
            vida.text = (int.Parse(vida.text) - 1).ToString();
        }
    }

    private void OnTriggerEnter(Collider quem)
    {
        if (quem.gameObject.tag == "Bom")
        {
            pontinhos.text = (int.Parse(pontinhos.text) + 10).ToString();
        }
    }
}