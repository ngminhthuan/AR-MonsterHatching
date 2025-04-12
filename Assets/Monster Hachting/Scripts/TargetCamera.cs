using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject targetCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTargetFound()
    {
        Debug.Log("Camera Found target");
    }
    public void OnTargetLost()
    {
        Debug.Log("Camera Lost target");
    }
}
