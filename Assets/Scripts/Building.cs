using UnityEngine;

public class Building : MonoBehaviour
{
    public bool IsConflicted;
    public bool IsActive;
    public Renderer Renderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Building>() != null)
        {
            IsConflicted = true;
            if (IsActive)
                Renderer.material.color = new Color(0.75f, 0.31f, 0.38f, 0.84f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Building>() != null)
        {
            IsConflicted = false;
            if (IsActive)
                Renderer.material.color = new Color(0.34f, 0.74f, 0.32f, 0.84f);
        }
    }
}
