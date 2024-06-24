using UnityEngine;
public class Ring : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform sp;
    [SerializeField] GameObject scoreObject;
    private void Start()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        ball = GameObject.Find("Ball 1");
        Debug.Log(PlayerPrefs.GetInt("bestScore"));
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            scoreObject = GameObject.Find("ScoreObject");
            scoreObject.GetComponent<score>().scoreCount++;
            scoreObject.GetComponent<score>().scoreText.SetText(scoreObject.GetComponent<score>().scoreCount.ToString());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            ball.GetComponent<Ball>().savePos(sp);
            collision.GetComponent<DragController>().isDrag = true;
            if(scoreObject.GetComponent<score>().scoreCount > PlayerPrefs.GetInt("bestScore"))
            {
                
                scoreObject.GetComponent<score>().bestScore = scoreObject.GetComponent<score>().scoreCount;
                PlayerPrefs.SetInt("bestScore", scoreObject.GetComponent<score>().bestScore);
                scoreObject.GetComponent<score>().GoldText();
            }
        
        }
    }
    

}
