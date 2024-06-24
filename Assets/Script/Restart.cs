using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] Image rewardFill;
    [SerializeField] GameObject panel;
    bool isGameOver = false;
    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject buttonRewarded;
    [SerializeField] GameObject rewarded;
    [SerializeField] Text bestText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ring"))
        {
            
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("ball"))
        {
            PlayerPrefs.SetInt("bestScore", scoreObject.GetComponent<score>().bestScore);
            if (scoreObject.GetComponent<score>().scoreCount < 1 || rewardFill.fillAmount < 0.99f)
            {
                
                SceneManager.LoadScene(0);
            }
            else
            {
                bestText.text = PlayerPrefs.GetInt("bestScore").ToString();
                isGameOver = true;
                panel.SetActive(true);
            }
        }
    }
    private void Update()
    {
        if(isGameOver)
        {
            rewardFill.fillAmount -= 0.2f * Time.deltaTime;
        }
        if(rewardFill.fillAmount == 0)
        {
            rewarded.GetComponent<Animator>().SetTrigger("isRewarded");
        }
        
    }

}

