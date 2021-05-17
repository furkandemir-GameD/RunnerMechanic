using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(Types)]
public class FinalLineAnimation : MonoBehaviour
{
    [SerializeField] private PaintingGeneralProperties paintingGeneralProperties;
    private Material _mat;
    private void Awake() => _mat = GetComponent<MeshRenderer>().material;
    void Update()
    {
        Vector2 firstPosition = new Vector2(_mat.mainTextureOffset.x, _mat.mainTextureOffset.y);
        Vector2 targetPosition = new Vector2(Time.time, _mat.mainTextureOffset.y);

        _mat.mainTextureOffset = Vector2.Lerp(firstPosition, targetPosition, paintingGeneralProperties.animationSpeed * Time.deltaTime);
    }
}
