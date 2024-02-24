using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public float weight;

    private Vector2 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    public void ResetPos()
    {
        GetComponent<DragAndDrop>()._dragging = false;
        transform.position = startPos;
    }
}
