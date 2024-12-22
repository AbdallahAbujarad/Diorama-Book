using UnityEngine;

public class BoxOpen : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    public static bool stoppedDragging = false;
    private bool isDragged = false;
    private float lerpSpeed = 10f;
    private float fallSpeed = 5f;
    private float counterAfterFalling = 0;
    public GameObject box;
    public GameObject openText;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            Vector3 targetPosition = mousePosition + offset;
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                lerpSpeed * Time.deltaTime
            );
        }
        if (isDragged)
        {
            openText.gameObject.transform.localScale = Vector3.Lerp(
                openText.gameObject.transform.localScale,
                new Vector3(0, 0, 0),
                Time.deltaTime * 3
            );
        }
        if (stoppedDragging)
        {
            transform.position += Vector3.down * Time.deltaTime * fallSpeed;
            box.gameObject.transform.position += Vector3.down * Time.deltaTime * fallSpeed;
            counterAfterFalling += Time.deltaTime;
            if (counterAfterFalling > 3)
            {
                gameObject.SetActive(false);
                box.gameObject.SetActive(false);
                openText.gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
        isDragged = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        stoppedDragging = true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z);
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}
