using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public List<Material> allMaterials;

    private SkinnedMeshRenderer skinnedMeshRenderer;
    private int randomMaterial;
    // Start is called before the first frame update
    void Start()
    {
        randomMaterial = Random.Range(0, allMaterials.Count);
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.material = allMaterials[randomMaterial];
    }
}
