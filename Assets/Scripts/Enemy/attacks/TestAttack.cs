using UnityEngine;

public class TestAttack : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float frequency = 1.0f;
    public float amplitude = 1.0f;
    public float speed = 1.0f;
    public int numPoints = 50;

    private Vector3[] positions;
    private float time = 0.0f;

    void Start()
    {
        lineRenderer.positionCount = numPoints;
        positions = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float x = (float)i / (float)(numPoints - 1);
            positions[i] = new Vector3(x, 0, 0);
        }

        lineRenderer.SetPositions(positions);
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        for (int i = 0; i < numPoints; i++)
        {
            float x = (float)i / (float)(numPoints - 1);
            float y = Mathf.Sin(x * frequency + time) * amplitude;
            positions[i] = new Vector3(x, y, 0);
        }

        lineRenderer.SetPositions(positions);
    }
}