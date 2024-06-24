using UnityEngine;
public class Ball : MonoBehaviour
{
    [SerializeField] Camera cam;
    public float maxY;
    [SerializeField] Transform Sp1;
    [SerializeField] Transform Sp2;
    [SerializeField] GameObject ring1;
    [SerializeField] GameObject ring2;
    public Vector3 ballPos;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject scoreObject;
    [SerializeField] AudioSource aud;
    [SerializeField] GameObject spawnerControl;
    private void Update()
    {
        float camTranformPos = cam.transform.position.y;
        cam.transform.position = new Vector3(0, transform.position.y, -10);
        spawnerControl.transform.position = new Vector3(0, cam.transform.position.y, -10);
        if (cam.transform.position.y > camTranformPos)
        {
            maxY = cam.transform.position.y;

        }
        else
        {
            cam.transform.position = new Vector3(0, maxY, -10);
        }
        if(scoreObject.GetComponent<score>().scoreCount == 1)
        {
            startText.GetComponent<Animator>().SetTrigger("startText");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ring"))
        {
            aud.Play();
            cam.GetComponent<Animator>().SetTrigger("scaleCam");
        }
        if (!other.CompareTag("restart"))
        {
        }
        
        
    }
    public void savePos(Transform pos)
    {
        ballPos = pos.position;
        ballPos = new Vector3(ballPos.x, ballPos.y+0.1f,ballPos.z);
    }
}
