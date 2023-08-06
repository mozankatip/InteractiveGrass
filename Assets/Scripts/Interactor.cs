using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public GameObject interactor;
    private Material grassMat;

    void Start()
    {
        grassMat = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 interactorPos = interactor.GetComponent<Transform>().position;
        grassMat.SetVector("_InteractorPosition", interactorPos);
    }
}
