using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler : MonoBehaviour
{
    public bool collisionAfterHasRun = true;
    public bool hasRun = true;
    public bool collisionGround;

    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private LayerMask maskWall;
    [SerializeField] private OffsetCalculator offsetCalculator;
    [SerializeField] private AIProperties aIProperties;

    private float wallOffsetRight;
    private float wallOffsetLeft;
    private RaycastHit hitInfoLeft;
    private RaycastHit hitInfoRight;
    void Update()
    {
        if (GameManager.GameStates.GamePlayRun == GameManager.Instance.CurrentState)
        {
            if (hasRun && collisionAfterHasRun && collisionGround)
            {
                offsetCalculator.CastScan();
            }
        }
        else if(GameManager.GameStates.GameFail == GameManager.Instance.CurrentState)
        {
            animationHandler.Pause();
        }
    }
    public void WallOffset(int rand)
    {

        if (rand> aIProperties.intelligence)
        {
            if(Physics.Raycast(transform.position,Vector3.forward,out hitInfoLeft, 100f, maskWall))
            {
                wallOffsetLeft = hitInfoLeft.point.z - transform.position.z;
                wallOffsetLeft = Mathf.Abs(wallOffsetLeft);
            }
            if (Physics.Raycast(transform.position, -Vector3.forward, out hitInfoLeft, 100f, maskWall))
            {
                wallOffsetRight = hitInfoRight.point.z - transform.position.z;
                wallOffsetRight = Mathf.Abs(wallOffsetRight);
            }

            DirectionCalculate(wallOffsetLeft, wallOffsetRight);
        }
        else
        {
            _rb.velocity = new Vector3(-aIProperties.speed, 0, -0);
        }
    }
    private void DirectionCalculate(float offsetLeft,float offsetRight)
    {
        if (offsetLeft>offsetRight)
        {
            _rb.velocity = new Vector3(-aIProperties.speed, 0, aIProperties.escapeSpeed);
        }
        else
        {
            _rb.velocity = new Vector3(-aIProperties.speed, 0, -aIProperties.escapeSpeed);
        }
    }

}
