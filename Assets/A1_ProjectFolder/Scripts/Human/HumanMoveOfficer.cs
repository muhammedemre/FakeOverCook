using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class HumanMoveOfficer : SerializedMonoBehaviour
{
    [SerializeField] private HumanActor HumanActor;
    [SerializeField] private float smoothTime = 0.03f, humanSpeed, rotationSmoothTime = 0.001f, facingTreshold;
    [SerializeField] private Rigidbody2D rigidBody;
    float[] refList = new float[] {0f, 0f, 0f, 0f};

    [SerializeField] private List<float> sideMagnitudes = new List<float>(){0f, 0f, 0f, 0f};
    [SerializeField] private float testSpeed = 0f;
    
    Vector3 refRotation = Vector3.zero;
    private Vector3 previousPos;
    
    public bool ableToMove = true;

    private void Start()
    {
        previousPos = transform.position;
    }

    public void Move(bool moveUp, bool moveDown, bool moveLeft, bool moveRight)
    {
        // print("moveUp : "+ moveUp + " moveDown : "+ moveDown +" moveLeft : "+ moveLeft + " moveRight : "+ moveRight );
        MoveUpMagnitude(moveUp, 0);
        MoveUpMagnitude(moveDown, 1);
        MoveUpMagnitude(moveLeft, 2);
        MoveUpMagnitude(moveRight, 3);

        CalculateTheVelocity();
    }

    void MoveUpMagnitude(bool isMoving, int sideIndex)
    {
        if (isMoving)
        {
            sideMagnitudes[sideIndex] = Mathf.SmoothDamp(sideMagnitudes[sideIndex], 1, ref refList[sideIndex], smoothTime);
        }
        else
        {
            sideMagnitudes[sideIndex] = Mathf.SmoothDamp(sideMagnitudes[sideIndex], 0, ref refList[sideIndex], smoothTime);
        }
    }

    void CalculateTheVelocity()
    {
        float yVelocity = sideMagnitudes[0] - sideMagnitudes[1];
        float xVelocity = sideMagnitudes[3] - sideMagnitudes[2];
        Vector2 newVelocity = new Vector2(xVelocity, yVelocity).normalized;
        rigidBody.velocity = newVelocity * humanSpeed;
        testSpeed = rigidBody.velocity.magnitude;

        if (rigidBody.velocity.magnitude > facingTreshold)
        {
            CalculateTheFacingAngle(transform.position);
        }

        
    }

    public void CalculateTheFacingAngle(Vector3 targetPosition)
    {
        Vector3 diffPosition = targetPosition - previousPos;
        float angle = Mathf.Atan2(diffPosition.y, diffPosition.x) * Mathf.Rad2Deg;
        
        Transform modelAnchor = HumanActor.HumanAnimationOfficer.humanModelAnchor;
        
        Vector3 targetRot = Quaternion.AngleAxis(angle, Vector3.forward).eulerAngles + new Vector3(0f, 0f, -90f);
        modelAnchor.eulerAngles = Vector3.SmoothDamp(modelAnchor.eulerAngles, targetRot, ref refRotation, rotationSmoothTime);
        
        previousPos = transform.position;
    }
    
}
