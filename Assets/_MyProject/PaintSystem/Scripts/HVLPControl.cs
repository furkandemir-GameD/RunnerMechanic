using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HVLPControl : MonoBehaviour
{
    [SerializeField] private float delayBeforePainting;
    [SerializeField] private Transform paintableObjectTransform;
    [SerializeField] private ParticleSystem particlePaint;
    [SerializeField] private float paintMachineOffsetX;
    [SerializeField] private float paintMachineOffsetY;
    [SerializeField] private float paintMachineOffsetZ;
    private Transform playerTransform;
    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable()
    {
        Debug.Log("onenable");
        paintableObjectTransform.GetComponent<Animator>().SetBool("WhellCondiation", true);
        Run.After(delayBeforePainting, () =>
        {
            paintableObjectTransform.gameObject.GetComponent<Animator>().enabled = false;
            particlePaint.Play();
        });
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float paintMachineOffsetXTemp = playerTransform.position.x + paintMachineOffsetX;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition*2);
            transform.rotation = Quaternion.LookRotation(ray.direction);
            transform.position = ray.direction;

            Vector3 tempPosition;
            tempPosition.x = ray.direction.x + paintMachineOffsetXTemp;
            tempPosition.y = ray.direction.y + paintMachineOffsetY;
            tempPosition.z = ray.direction.z + paintMachineOffsetZ;
            transform.position = tempPosition;

            Vector3 tempAngle;
            tempAngle.x = paintableObjectTransform.eulerAngles.x;
            tempAngle.y = ray.direction.y + paintableObjectTransform.eulerAngles.y;
            tempAngle.z = paintableObjectTransform.eulerAngles.z;
            paintableObjectTransform.eulerAngles = tempAngle;
        }
    }
}
