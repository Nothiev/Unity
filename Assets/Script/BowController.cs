using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public Animator bowAnimator;

    private GameObject currentArrow;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartDrawing();
                    break;
                case TouchPhase.Ended:
                    Release();
                    break;
            }
        }
    }

    private void StartDrawing()
    {
        currentArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        bowAnimator.SetBool("IsDrawing", true);
    }

    private void Release()
    {
        FireArrow();
        bowAnimator.SetBool("IsDrawing", false);
    }

    private void FireArrow()
    {
        if (currentArrow != null)
        {
            Rigidbody rb = currentArrow.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(arrowSpawnPoint.forward * 500);
                currentArrow = null;
            }
        }
    }
}
