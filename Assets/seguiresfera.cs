using UnityEngine;

public class seguiresfera : MonoBehaviour
{ 
    public Transform esfera;
    public Vector3 valores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = esfera.position+valores;
    }
}
