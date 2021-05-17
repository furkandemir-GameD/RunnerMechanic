using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D.Examples;
using System;
using PaintIn3D;

[RequireComponent(typeof(MeshRenderer))]
public class ChangeCounterManager : MonoBehaviour
{
    [SerializeField] private PaintingGeneralProperties paintingGeneralProperties;
    [SerializeField] private Material changeMaterial;
    [SerializeField] private P3dChangeCounter p3DChangeCounter;

    private const int maxChangeCount = 323968;
    private float currentValue;

    private void Update()
    {
        currentValue = (float) p3DChangeCounter.Count / (float) maxChangeCount ;
        UIManager.Instance.FillAmount(currentValue);
        if (currentValue >= paintingGeneralProperties.percentPaintThreshold)
        {
            currentValue = 1f;
            UIManager.Instance.FillAmount(currentValue);
            GameManager.Instance.WinGame();
            this.enabled = false;
        }
    }
}
