
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class andar : MonoBehaviour
{
    public Rigidbody jogador;
    public TMP_Text vida;
    public TMP_Text pontinhos;
    public AudioSource som;
    public AudioClip sombom;
    public AudioClip sommau;

    void Start()
    {
        if (jogador == null) Debug.LogError("CAMPO VAZIO: Jogador");
        if (vida == null) Debug.LogError("CAMPO VAZIO: Vida");
        if (pontinhos == null) Debug.LogError("CAMPO VAZIO: Pontinhos");
        if (som == null) Debug.LogError("CAMPO VAZIO: Som");
        if (sombom == null) Debug.LogError("CAMPO VAZIO: Sombom");
        if (sommau == null) Debug.LogError("CAMPO VAZIO: Sommau");
    }

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

        if (jogador.position.y < -5)
        {
            FindAnyObjectByType<controlador>().reiniciar();
        }
    }

    private void OnCollisionEnter(Collision quem)
    {
        Debug.Log("Colidi com: " + quem.gameObject.name + " | tag: " + quem.gameObject.tag);

        if (quem.gameObject.tag == "Mau")
        {
            vida.text = (int.Parse(vida.text) - 1).ToString();
            som.PlayOneShot(sommau);

            if (int.Parse(vida.text) <= 0)
            {
                FindAnyObjectByType<controlador>().reiniciar();
            }
        }
    }

    private void OnTriggerEnter(Collider quem)
    {
        Debug.Log("Trigger com: " + quem.gameObject.name + " | tag: " + quem.gameObject.tag);

        if (quem.gameObject.tag == "Bom")
        {
            pontinhos.text = (int.Parse(pontinhos.text) + 10).ToString();
            som.PlayOneShot(sombom);
            Destroy(quem.gameObject);
        }
        
        if (quem.gameObject.name == "cubo")
       {
         FindAnyObjectByType<controlador>().passou();
       }
    }
}