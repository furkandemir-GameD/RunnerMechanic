using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PaintHandler : MonoBehaviour
{
    public static void FinalPointTrigger(Collider other,PaintingGeneralProperties paintingGeneralProperties,BeforePainting beforePainting,Transform HVLP,GameObject deactiveObject)
    {
        other.transform.DOMoveZ(0, paintingGeneralProperties.charachterHandMovementDuration);
        Run.After(paintingGeneralProperties.charachterHandMovementDuration, () =>
        {
            beforePainting.CharachterHandMovement();
            FreezeObject(other.gameObject);

        });
        Run.After(paintingGeneralProperties.cameraTransitionDuration, () =>
        {
            GameObject.FindWithTag("CameraManager").GetComponent<CameraTransitionManager>().CameraTransistionFPS();
            HVLP.GetComponent<HVLPControl>().enabled = true;
            deactiveObject.SetActive(false);
        });
    }
    private static void FreezeObject(GameObject frozenObject)
    {
        frozenObject.GetComponent<CharacterController>().enabled = false;
        frozenObject.GetComponent<Rigidbody>().isKinematic = true;
        frozenObject.GetComponent<Animator>().enabled = false;
    }
}
