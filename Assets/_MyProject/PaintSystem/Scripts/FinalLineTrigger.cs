using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class FinalLineTrigger : MonoBehaviour
{
    [SerializeField] private GameObject deactiveObject;
    [SerializeField] private PaintingGeneralProperties paintingGeneralProperties;
    private Transform HVLP;
    private BeforePainting beforePainting;
    private void Awake() 
    {
        HVLP = GameObject.FindGameObjectWithTag("HVLP").transform;
        beforePainting = HVLP.gameObject.GetComponent<BeforePainting>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {     
            PaintHandler.FinalPointTrigger(other, paintingGeneralProperties, beforePainting, HVLP, deactiveObject);
            GameManager.Instance.StartPaint();
        }
        else if (other.CompareTag("AI"))
        {
            GameManager.Instance.FailGame();
        }
    }
}
