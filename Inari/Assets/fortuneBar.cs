using UnityEngine;
using UnityEngine.UI;

public class fortuneBar : MonoBehaviour
{
    public Image healthBarImage;
    public GameHeader player;
    void Update()
    {
        healthBarImage.fillAmount = Mathf.Clamp(player.fortune / player.maxFortune, 0, 1f);
  
    }
}

