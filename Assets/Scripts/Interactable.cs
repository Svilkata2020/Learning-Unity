using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    protected virtual void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {

    }
}
