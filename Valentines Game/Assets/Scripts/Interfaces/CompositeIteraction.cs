using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeIteraction : MonoBehaviour, IInteractable, ICancel
{
    [SerializeField] private List<GameObject> interactables;
    public void Interact()
    {
        for (int i = 0; i < interactables.Count; i++)
        {
            var interactable = interactables[i].GetComponent<IInteractable>();
            if (interactables != null)
                interactable.Interact();
        }

    }
    public void Cancel()
    {

    }

}
