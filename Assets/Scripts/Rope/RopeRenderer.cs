using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private int _segments = 10;
    public void Draw(Vector3 A, Vector3 B, float length)
    {
        _lineRenderer.enabled = true;

        float interpolant = Vector3.Distance(A, B) / length;

        float offset = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 A_down = A + Vector3.down * offset;
        Vector3 B_down = B + Vector3.down * offset;

        _lineRenderer.positionCount = _segments + 1;
        for (int i = 0; i < _segments + 1; i++)
        {
            _lineRenderer.SetPosition(i, Bezier.GetPoint(A, A_down, B_down, B, (float)i / _segments));
        }
    }

    public void Hide()
    {
        _lineRenderer.enabled = false;
    }
}
