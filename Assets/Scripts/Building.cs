using UnityEngine;

public class Building : MonoBehaviour
{
    public bool IsConflicted;
    public bool IsActive;
    public Renderer Renderer;
    private readonly Color acceptableColor = new Color(0.34f, 0.74f, 0.32f, 0.84f);
    private readonly Color conflictedColor = new Color(0.75f, 0.31f, 0.38f, 0.84f);

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Building>() != null)
        {
            IsConflicted = false;
            RenderAcceptable();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Building>() != null)
        {
            IsConflicted = true;
            RenderConflicted();
        }
    }

    public void RenderAcceptable()
    {
        if (IsActive)
            Renderer.material.color = acceptableColor;
    }

    public void RenderConflicted()
    {
        if (IsActive)
            Renderer.material.color = conflictedColor;
    }
}
