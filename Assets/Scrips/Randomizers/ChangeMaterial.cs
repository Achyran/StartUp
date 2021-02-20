using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public List<Material> allMaterials;

    private MeshRenderer meshRenderer;
    private int randomMaterial;
    // Start is called before the first frame update
    void Start()
    {
        randomMaterial = Random.Range(0, allMaterials.Count);
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = allMaterials[randomMaterial];
    }
}
