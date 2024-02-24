using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSide : MonoBehaviour
{
    public Transform[] positions;

    public List<Weight> weights;

    private float weight;

    public GameObject vfxAttach;

    private void Awake()
    {
        weight = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<Weight>() != null && !weights.Contains(collision.GetComponent<Weight>()))
        {
            if (weights.Count >= 4)
            {
                collision.GetComponent<Weight>().ResetPos();
                return;
            }

            weights.Add(collision.GetComponent<Weight>());

            GameObject vfx = Instantiate(vfxAttach, transform.position, Quaternion.identity) as GameObject;

            Destroy(vfx, 1f);

            collision.GetComponent<DragAndDrop>()._dragging = false;

            collision.gameObject.transform.position = positions[weights.IndexOf(collision.GetComponent<Weight>())].position;

            weight += collision.GetComponent<Weight>().weight;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<Weight>() != null)
        {
            if (weights.Contains(collision.GetComponent<Weight>()))
            {
                weight -= collision.GetComponent<Weight>().weight;

                weights.Remove(collision.GetComponent<Weight>());
            }
        }
    }

    public float GetWeight()
    {
        return weight;
    }
}
