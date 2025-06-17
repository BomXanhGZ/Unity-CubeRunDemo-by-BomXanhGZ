using UnityEngine;
using static GlobalSpace.GameUtilities;


public class UIGamePause : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;

    public GameObject ref_OptionPanel { set; get; }
    public GameObject ref_GoBackButton { set; get; }
    public GameObject ref_ContinueButton { set; get; }


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in UIGamePause");
    }   

    public void ShowPauseGameUI()
    {

        CheckIsNotNull(ref_OptionPanel, "ref_OptionPanel in UIGamePause");
        CheckIsNotNull(ref_ContinueButton, "ref_ContinueButton in UIGamePause");
        CheckIsNotNull(ref_GoBackButton, "ref_GoBackButton in UIGamePause");

        if (ref_GameManagerData.is_pause_)
        {
            ref_OptionPanel.SetActive(true);
            ref_ContinueButton.SetActive(true);
            ref_GoBackButton.SetActive(true);

        }

        else
        {
            ref_ContinueButton.SetActive(false);
            ref_GoBackButton.SetActive(false);
            ref_OptionPanel.SetActive(false);
        }
    }
}
