using UnityEngine;

public class HammerControl : MonoBehaviour
{
    private Material hamMat;
    private PlayerControler pCon;

    void Start()
    {
        hamMat = GetComponentInChildren<MeshRenderer>().material;
        pCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
    }

    void Update()
    {
        ColorChange();
        
    }

    void ColorChange()
    {
        int colorCoef = pCon.hammerPower / 3;
        switch (colorCoef)
        {
            case 1:
                hamMat.color = new Color32(51, 0, 0, 255);
                break;
            case 2:
                hamMat.color = new Color32(102, 0, 0, 255);
                break;
            case 3:
                hamMat.color = new Color32(153, 0, 0, 255);
                break;
            case 4:
                hamMat.color = new Color32(204, 0, 0, 255);
                break;
            case 5:
                hamMat.color = new Color32(255, 0, 0, 255);
                break;
        }
    }
}
