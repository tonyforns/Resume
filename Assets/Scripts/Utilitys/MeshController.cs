using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{

    private MeshFilter mesh;
    private MeshRenderer meshRenderer;
    public Mesh testMesh;

    void Start()
    {
        mesh = GetComponent<MeshFilter>();
        mesh.mesh = testMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
