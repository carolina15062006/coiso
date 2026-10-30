using UnityEngine;

public class seguiresfera : MonoBehaviour
{
    public Transform esfera;
    public Vector3 valores;

    void Update()
    {
        transform.position = esfera.position + valores;
    }
}