using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolopupka
{
public class RTSMovment : MonoBehaviour
{

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject setDestinationEffect;

    private Vector3 targetPosition;

    
    bool IsMoving;
    void Start()
    {
        
    }

    void Update()
    {

        if (InputManager.Instance.IsMouseButtonDownThisFrame())
        {
            targetPosition = MouseWorld.GetPosition();
            Instantiate(setDestinationEffect, targetPosition, Quaternion.identity);

            IsMoving = true;
        }

        if (!IsMoving)
        {
            return;
        }

        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, new Vector3(moveDirection.x, 0, moveDirection.z), Time.deltaTime * rotateSpeed);

        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        }
        else
        {
            IsMoving = false;
        }
    }
}
}
