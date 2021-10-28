using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsConflicted;
    private Renderer mainRenderer;

    private void Awake()
    {
        mainRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Cell"))
        {
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print("We hit smth");
        if (other.gameObject.CompareTag("Cell"))
        {
            IsConflicted = true;
            mainRenderer.material.color = new Color(0.78f, 0f, 0.04f, 0.71f);

        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Cell"))
        {
            IsConflicted = false;
            mainRenderer.material.color = Color.green;

        }
    }
}
