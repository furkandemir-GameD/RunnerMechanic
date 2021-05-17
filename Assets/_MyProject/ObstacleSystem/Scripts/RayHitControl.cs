using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHitControl : MonoBehaviour
{
    [Header("Common Properties")]
    [SerializeField] private LayerMask maskHit;
    [SerializeField] private VFXHandler vFXHandler;

    [Header("Raycast Properities Left")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private float maxDistanceLeft;

    [Header("Raycast Properities Right")]
    [SerializeField] private Transform rightPoint;
    [SerializeField] private float maxDistanceRight;
    [SerializeField] private LayerMask hitAfterMask;

    private void Update()
    {
        RaycastHit hitLeft;
        RaycastHit hitRight;
        if (Physics.Raycast(leftPoint.position,Vector3.forward,out hitLeft,maxDistanceLeft,maskHit))
        {
            vFXHandler.objectInArea.Add(hitLeft.transform);
            hitLeft.transform.gameObject.layer = 0;
            vFXHandler.areaInObjectActive = true;
            SetActiveTrueFalse(1);
           
        }
        if (Physics.Raycast(rightPoint.position, Vector3.forward, out hitRight, maxDistanceRight, hitAfterMask))
        {
            vFXHandler.objectInArea.Remove(hitRight.transform);
            hitRight.transform.gameObject.layer = 10;
            if (vFXHandler.objectInArea.Count==0)
            {
                vFXHandler.areaInObjectActive = false;
                SetActiveTrueFalse(-1);
                vFXHandler.nearCharachter = null;
            }
        }
        if (vFXHandler.objectInArea.Count == 1)
        {
            vFXHandler.nearCharachter = vFXHandler.objectInArea[0].gameObject;
            vFXHandler.Magnet();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(leftPoint.position, Vector3.forward * 10f);
        Gizmos.DrawRay(rightPoint.position, Vector3.forward * 10f);
    }

    private void SetActiveTrueFalse(int i)
    {
        if (i==-1)
        {
            vFXHandler.firstPoint.gameObject.SetActive(false);
            vFXHandler.particleCharachter.gameObject.SetActive(false);
            vFXHandler.vfxBody.enabled = false;
        }
        else if (i==1)
        {
            Run.After(0.05f,()=>
            {
                vFXHandler.firstPoint.gameObject.SetActive(true);
                vFXHandler.particleCharachter.gameObject.SetActive(true);
                vFXHandler.vfxBody.enabled = true;
            });
        }
    }
}
