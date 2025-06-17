using UnityEngine;
using static GlobalSpace.GameUtilities;


public class UIWinGame : MonoBehaviour
{
    [SerializeField] UICoinTextSetter ref_UICoinTextSetter;         //UI DATA

    public GameObject ref_OptionButton { set; get; }                   //UI
    public GameObject ref_OptionPanel { set; get; }
    public GameObject ref_GoBackButton { set; get; }
    public GameObject ref_VictoryText { set; get; }
    public GameObject ref_CoinTotalImg { set; get; }



    private void Start()
    {

        CheckIsNotNull(ref_UICoinTextSetter, "ref_UICoinTextSetter in UIWinGame");
    }

    public void ShowWinGameUI()
    {
        CheckIsNotNull(ref_OptionButton, "ref_OptionButton in UIWinGame");
        CheckIsNotNull(ref_OptionPanel, "ref_OptionPanel in UIWinGame");
        CheckIsNotNull(ref_GoBackButton, "ref_GoBackButton in UIWinGame");
        CheckIsNotNull(ref_VictoryText, "ref_VictoryText in UIWinGame");
        CheckIsNotNull(ref_CoinTotalImg, "ref_CoinTotalImg in UIWinGame");


        ref_OptionButton.SetActive(false);
        ref_OptionPanel.SetActive(true);
        ref_GoBackButton.SetActive(true);
        ref_VictoryText.SetActive(true);

        ref_CoinTotalImg.SetActive(true);   //Handle show val coin
        ref_UICoinTextSetter.SetTextCoin();
    }
}
