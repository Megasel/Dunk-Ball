using UnityEngine;
using TMPro;
using YG;
public class score : MonoBehaviour
{
    public int scoreCount;
    public TextMeshPro scoreText;
    public int bestScore;
    [SerializeField] Color colText;
    [SerializeField] GameObject yandex;
    private void Start()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            bestScore = PlayerPrefs.GetInt("bestScore");
            YandexGame.NewLeaderboardScores("LeaderBoard", PlayerPrefs.GetInt("bestScore"));
        }
        else
        {
            bestScore = 0;
        }

        
        scoreText.SetText(0.ToString());
    }
    public void GoldText()
    {
        scoreText.color = colText;
        Debug.Log("afw");
    }
}
