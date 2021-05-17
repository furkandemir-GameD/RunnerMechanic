using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    public bool areaInObjectActive;
    public Transform particleCharachter;
    public List<Transform> objectInArea = new List<Transform>();
    public GameObject nearCharachter;
    public LineRenderer vfxBody;
    public Transform firstPoint;

    [SerializeField] private Transform secondPoint;
    [SerializeField] private HalfDonutProperties halfDonutProperties;
    [SerializeField] private Transform donutTransform;

    private List<float> objectInAreaDistance = new List<float>();
    private Transform startPoint;
    private void Start() => Init();
    void Update()
    {
        if (areaInObjectActive)
        {
            for (int i = 0; i < objectInArea.Count; i++)
            {
                float xAxisDistance = (donutTransform.position.x - objectInArea[i].position.x) * (donutTransform.position.x - objectInArea[i].position.x);
                float yAxisDistance = (donutTransform.position.y - objectInArea[i].position.y) * (donutTransform.position.y - objectInArea[i].position.y);
                float distance = Mathf.Sqrt(xAxisDistance + yAxisDistance);
                objectInAreaDistance[i] = distance;
                for (int j = 0; j < objectInAreaDistance.Count; j++)
                {
                    if (objectInAreaDistance[i] < objectInAreaDistance[j])
                    {
                        nearCharachter = objectInArea[i].gameObject;
                    }
                }
            }
            if (nearCharachter != null)
            {
                float charachterSize = nearCharachter.transform.localScale.y;
                Vector3 midPoint = new Vector3(nearCharachter.transform.position.x, nearCharachter.transform.position.y + charachterSize, nearCharachter.transform.position.z);
                vfxBody.SetPosition(0, firstPoint.position);
                vfxBody.SetPosition(1, midPoint);
                particleCharachter.position = nearCharachter.transform.position;
            }
        }
    }
    private void FixedUpdate()
    {
        if (nearCharachter != null)
        {
            Magnet();
        }
    }
    public void Magnet()
    {
        nearCharachter.GetComponent<Rigidbody>().AddForce((firstPoint.position - nearCharachter.transform.position) * halfDonutProperties.magnetForce);
    }
    public void StartPointTransform(Collision collision)
    {
        objectInArea.Remove(collision.transform);
        collision.transform.position = startPoint.position;
    }
    private void Init()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        objectInAreaDistance.Add(0);
        objectInAreaDistance.Add(0);
        objectInAreaDistance.Add(0);
    }
}
