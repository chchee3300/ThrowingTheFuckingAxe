using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string selectableTag;
    private Transform _selection;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (_selection != null)
            DefaultTransform();
        if (Physics.Raycast(ray, out hit))
            HighlightSelection(hit);
    }


    private void DefaultTransform()
    {
        var selectionRenderer = _selection.GetComponent<Renderer>();
        selectionRenderer.material = defaultMaterial;
        _selection = null;
    }

    private void HighlightSelection(RaycastHit hit)
    {
        var selection = hit.transform;
        if (IsHighlightableItem(selection))
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }

            _selection = selection;
        }
    }

    private bool IsHighlightableItem(Transform selection)
    {
        return selection.CompareTag(selectableTag);
    }
}