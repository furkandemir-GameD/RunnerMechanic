using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
   private Material _mat;
    private void Awake()
    {
        _mat = GetComponent<MeshRenderer>().material;
        _mat.color = Color.white;
    }
}
