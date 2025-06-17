using UnityEngine;
using static GlobalSpace.GameUtilities;


public class UIGameOver : MonoBehaviour
{
    public GameObject ref_OptionPanel { set; get; }
    public GameObject ref_OptionButton { set; get; }
    public GameObject ref_GoBackButton { set; get; }
    public GameObject ref_ReplayButton { set; get; }
    public GameObject ref_GameOverText { set; get; }


    public void ShowGameOverUI()
    {
        CheckIsNotNull(ref_OptionButton, "ref_OptionButton in UIGameOver");
        CheckIsNotNull(ref_GameOverText, "ref_GameOverText in UIGameOver");
        CheckIsNotNull(ref_OptionPanel, "ref_optionPanel UIGameOver");
        CheckIsNotNull(ref_ReplayButton, "ref_ReplayButton in UIGameOver");
        CheckIsNotNull(ref_GoBackButton, "ref_goBackButton UIGameOver");

        ref_OptionPanel.SetActive(true);
        ref_OptionButton.SetActive(false);
        ref_GameOverText.SetActive(true);
        ref_ReplayButton.SetActive(true);
        ref_GoBackButton.SetActive(true);
    }
}
