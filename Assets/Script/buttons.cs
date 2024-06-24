using UnityEngine;
using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;
public class buttons : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject ball;
    [SerializeField] Sprite[] flagSprites;
    [SerializeField] Image langButton;
    private void OnEnable() => YandexGame.RewardVideoEvent += rewardedAd;
    private void OnDisable() => YandexGame.RewardVideoEvent -= rewardedAd;
    
        
    public void ShowRewarded()
    {
        YandexGame.RewVideoShow(0);
    }
    public void restart()
    {
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(0);
    }
    public void rewardedAd(int id)
    {
        ball.transform.position = ball.GetComponent<Ball>().ballPos;
        panel.SetActive(false);
    }
    
}
