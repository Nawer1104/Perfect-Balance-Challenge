using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject vfxAttach;

    private BoxCollider2D collider2D;

    bool isAttached;

    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();

        isAttached = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision != null && collision.gameObject.CompareTag("Pan"))
        {
            if (collision.GetComponent<Pan>().isComponentFilled)
            {
                return;
            } 
            else
            {
                GetComponent<DragAndDrop>()._dragging = false;

                GameObject vfx = Instantiate(vfxAttach, transform.position, Quaternion.identity) as GameObject;

                Destroy(vfx, 1f);

                collider2D.enabled = false;

                collision.GetComponent<Pan>().AddComponent(this);
            }
        }


    }
}
