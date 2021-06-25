using UnityEngine;
using UnityEngine.UI;
public class hungerBar : MonoBehaviour
{


    public Image healthBarImage;
    public GameHeader player;
    void Update()
    {
        healthBarImage.fillAmount = Mathf.Clamp(player.hunger / player.maxHunger, 0, 1f);
    }
}
