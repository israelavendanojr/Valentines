using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] float interactRadius;
    [SerializeField ]LayerMask interactableLayer;
    public void Interaction()
    {
        Transform selectedInteractable = GetClosestTarget(FindNearestInteractable());
        if (selectedInteractable == null)
            return;
        selectedInteractable.GetComponent<IInteractable>().Interact();
    }
    public void Cancel()
    {
        Transform selectedInteractable = GetClosestTarget(FindNearestInteractable());
        if (selectedInteractable == null)
            return;
        selectedInteractable.GetComponent<ICancel>().Cancel();
    }

    private List<Transform> FindNearestInteractable()
    {
        Collider2D[] nearbyInteractables = Physics2D.OverlapCircleAll(transform.position, interactRadius);
        List<Transform> interactableTransform = new List<Transform>();
        for (int i = 0; i < nearbyInteractables.Length; i++)
        {
            var interactable = nearbyInteractables[i].GetComponent<IInteractable>();
            if (interactable != null)
                interactableTransform.Add(nearbyInteractables[i].transform);
        }

        return interactableTransform;
    }

    Transform GetClosestTarget(List<Transform> targets)
    {
        Transform closestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in targets)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestTarget = potentialTarget;
            }
        }

        return closestTarget;
    }

}
