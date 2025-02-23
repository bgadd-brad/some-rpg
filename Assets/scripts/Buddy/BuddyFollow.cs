using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyFollow : MonoBehaviour
{
    [SerializeField]
    GameObject targetToFollow;
    Rigidbody2D targetRB;
    
    [SerializeField]
    float padRadius;
    [SerializeField]
    float offset;
    float newOffset;
    float xDir = -1f;
    Vector2 currenVelocity;
    [SerializeField]
    float moveSpeed;

    private void Start() {
        newOffset = offset;
        if (targetToFollow == null) {
            targetToFollow = GameObject.FindGameObjectWithTag("Player");
        }
        targetRB = targetToFollow.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        FollowTarget();
        FlipSprite();
    }

    void FollowTarget()
    {
        newOffset = offset;
        float targetVelocity = targetRB.velocity.x;

        if(targetVelocity == 0)
        {
            Vector2 newPos = new Vector3((targetToFollow.transform.position.x + padRadius * xDir), targetToFollow.transform.position.y);
            transform.position = Vector2.Lerp(transform.position, newPos, Time.deltaTime * moveSpeed);            
        } else { 
            xDir = Mathf.Sign(targetVelocity)  * -1;
            newOffset *= xDir; 
            Vector2 newPos = new Vector2(targetToFollow.transform.position.x + newOffset, targetToFollow.transform.position.y);
            transform.position = Vector2.Lerp(transform.position, newPos, Time.deltaTime * moveSpeed);
        }
    }

    void FlipSprite() {
        if(xDir != 0)
        { 
            transform.localScale = new Vector2(xDir, transform.localScale.y);
        }
    }

}
