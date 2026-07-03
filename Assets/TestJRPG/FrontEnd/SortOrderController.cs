using UnityEngine;
using UnityEngine.Serialization;

public class SortOrderController : MonoBehaviour
{
    private Renderer spriteRenderer;
    public bool _isStatic = false; 
    
    private const float precisionMultiplier = 10f; 

    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();

        if (_isStatic)
        {
            UpdateSortingOrder();
            enabled = false; 
        }
    }

    void LateUpdate()
    {
        UpdateSortingOrder();
    }

    private void UpdateSortingOrder()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.z  * precisionMultiplier);
    }
}
