using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pan : MonoBehaviour
{
    public List<Transform> transforms = new List<Transform>();

    private List<Object> objects = new List<Object>();

    public bool isComponentFilled;

    public Transform barBeam;
    public Transform pan_2;

    private void Awake()
    {
        isComponentFilled = false;
    }

    public void AddComponent(Object obj)
    {
        objects.Add(obj);

        obj.transform.position = transforms[objects.IndexOf(obj)].position;

        obj.transform.SetParent(transforms[objects.IndexOf(obj)]);

        obj.transform.DOScale(new Vector3(.5f, .5f, .5f), 1f);

        CheckFilled();
    }

    private void CheckFilled()
    {
        if (objects.Count == transforms.Count)
        {
            isComponentFilled = true;
        }

        if (isComponentFilled)
        {
            barBeam.transform.DORotate(new Vector3(0f, 0f, 0f), 1f);
            transform.DORotate(new Vector3(0f, 0f, 0f), 1f);
            pan_2.transform.DORotate(new Vector3(0f, 0f, 0f), 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].CheckPans();
        }
    }
}
