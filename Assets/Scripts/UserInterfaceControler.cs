using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceControler : MonoBehaviour
{
    [SerializeField] private GameObject hammerpower_hud;
    [SerializeField] private Text hammerpower_text;
    private PlayerControler pCon;
    
    void Start()
    {
        pCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
    }

    
    void Update()
    {
        HammerPowerHud();
    }

    void HammerPowerHud()
    {
        if (SceneControler.sCon.CanStartGame)
        {
            hammerpower_hud.SetActive(true);
            hammerpower_text.enabled = true;
        }
        else
        {
            hammerpower_hud.SetActive(false);
            hammerpower_text.enabled = false;
        }

        hammerpower_text.text = pCon.hammerPower.ToString();
    }
}
