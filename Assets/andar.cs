using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using TMPro;

public class andar : MonoBehaviour
{
    public Rigidbody jogador;
    public TMP_Text vida;
    public TMP_Text pontinhos;
    public AudioSource som;
    public AudioClip sombom;
    public AudioClip sommau;
    private bool jogoAcabou = false;

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

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

        bool esquerda = false;
        bool direita = false;

        // Controlo por toque: metade esquerda / metade direita do ecrã
        foreach (var toque in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            if (toque.screenPosition.x < Screen.width / 2f)
                esquerda = true;
            else
                direita = true;
        }

        // Teclado (útil para testar no editor)
        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed) esquerda = true;
            if (Keyboard.current.rightArrowKey.isPressed) direita = true;
        }

        if (esquerda)
        {
            jogador.AddForce(-5, 0, 0);
        }
        if (direita)
        {
            jogador.AddForce(5, 0, 0);
        }

        if (!jogoAcabou && jogador.position.y < -5)
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

        // Apanhar moedas/pontos
        if (quem.gameObject.tag == "Bom")
        {
            pontinhos.text = (int.Parse(pontinhos.text) + 10).ToString();
            som.PlayOneShot(sombom);
            Destroy(quem.gameObject);
        }

        // Chegar ao final do nível
        if (quem.gameObject.name == "FIM" || quem.gameObject.name == "cubo")
        {
            jogoAcabou = true;
            jogador.linearVelocity = Vector3.zero;
            FindAnyObjectByType<controlador>().passou();
        }
    }
}