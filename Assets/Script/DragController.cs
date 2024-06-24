using System.Collections;
using UnityEngine;
public class DragController : MonoBehaviour
{
    public float power;
    LineRenderer lr;
    Rigidbody2D rb;
    Vector2 startDragPos;
    public bool isDrag;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                lr.enabled = true;
                startDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 endDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 _velocity = (startDragPos - endDragPos) * power;
                Vector2[] trajectory = Plot(rb, (Vector2)transform.position, _velocity, 500);
                lr.positionCount = trajectory.Length;
                Vector3[] positions = new Vector3[trajectory.Length];
                for (int i = 0; i < trajectory.Length; i++)
                {
                    positions[i] = trajectory[i];
                }
                lr.SetPositions(positions);
            }
        if (isDrag)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 endDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 _velocity = (endDragPos - startDragPos) * power;
                rb.velocity = -_velocity;
                lr.enabled = false;
                isDrag = false;
                StartCoroutine(dragDelay());
            }
        }
        
        
        
    }
    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        Vector2[] results = new Vector2[steps];
        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;
        for(int i = 0; i< steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }
        return results;

    }
    IEnumerator dragDelay()
    {
        yield return new WaitForSeconds(2f);
        isDrag = true;
    }

}
