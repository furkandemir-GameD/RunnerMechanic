using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BeforePainting : MonoBehaviour
{
    [SerializeField] private ParticleSystem startPS;
    [SerializeField] private PaintingGeneralProperties paintingGeneralProperties;
    private Transform handTransform;
    private void Awake() => handTransform = GameObject.FindWithTag("PlayerHand").transform;
    public void CharachterHandMovement()
    {
        startPS.Play();
        Run.After(paintingGeneralProperties.handMoveDuration, async () => { startPS.Stop(); });
        Vector3 characterHandPosition = new Vector3(handTransform.position.x - 0.2f, handTransform.position.y, handTransform.position.z);
        transform.DOMove(characterHandPosition, paintingGeneralProperties.handMoveDuration);
        
        Vector3 rotateAngle = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        transform.DORotate(rotateAngle, paintingGeneralProperties.handRotateDuration);
    }
}