using UnityEngine;

public class andar : MonoBehaviour
{
    public Rigidbody jogador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jogador.AddForce(0,0,10);
    }
}
