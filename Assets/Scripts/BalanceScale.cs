using UnityEngine;

public class BalanceScale : MonoBehaviour
{
    public Transform leftSide; // Reference to the left side of the scale
    public Transform rightSide; // Reference to the right side of the scale
    public Transform pivotPoint; // Reference to the pivot point of the scale

    public float maxRotation; // Maximum rotation angle

    private bool isBalanced;

    private bool isFinished;

    private void Awake()
    {
        isBalanced = false;

        isFinished = false;
    }

    void Update()
    {
        if (isFinished) return;
        // Calculate the total weight on each side
        float leftWeight = CalculateWeight(leftSide);
        float rightWeight = CalculateWeight(rightSide);

        // Calculate the difference in weights
        float weightDifference = leftWeight - rightWeight;
        switch (weightDifference)
        {
            case -1:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 355f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 5f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 5f);
                break;
            case -2:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 350f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 10f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 10f);
                break;
            case -3:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 345f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 15f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 15f);
                break;
            case -4:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 340f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 20f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 20f);
                break;
            case -5:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 335f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 25f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 25f);
                break;
            case 1:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 5f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 355f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 355f);
                break;
            case 2:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 10f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 350f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 350f);
                break;
            case 3:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 15f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 345f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 345f);
                break;
            case 4:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 20f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 340f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 340f);
                break;
            case 5:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 25f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 335f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 335f);
                break;
            default:
                pivotPoint.eulerAngles = new Vector3(0f, 0f, 0f);
                leftSide.localEulerAngles = new Vector3(0f, 0f, 0f);
                rightSide.localEulerAngles = new Vector3(0f, 0f, 0f);
                break;
        }

        if (weightDifference > 5)
        {
            pivotPoint.eulerAngles = new Vector3(0f, 0f, 25f);
            leftSide.localEulerAngles = new Vector3(0f, 0f, 335f);
            rightSide.localEulerAngles = new Vector3(0f, 0f, 335f);
        }
        else if (weightDifference < -5)
        {
            pivotPoint.eulerAngles = new Vector3(0f, 0f, 335f);
            leftSide.localEulerAngles = new Vector3(0f, 0f, 25f);
            rightSide.localEulerAngles = new Vector3(0f, 0f, 25f);
        }

        if (Mathf.Abs(weightDifference) < 0.001f && leftSide.GetComponent<ScaleSide>().weights.Count != 0 && rightSide.GetComponent<ScaleSide>().weights.Count != 0)
        {
            isBalanced = true;
        }
        else
        {
            isBalanced = false;
        }

        if (isBalanced)
        {
            isFinished = true;
            GameManager.Instance.CheckLevelUp();
        }
    }

    float CalculateWeight(Transform side)
    {
        return side.GetComponent<ScaleSide>().GetWeight();
    }
}
