using TMPro;
using UnityEngine;
using static GlobalSpace.GameUtilities;


public class GameCanvasUICTrlBridge : MonoBehaviour
{
    [SerializeField] GameObject ref_OptionButton;
    [SerializeField] GameObject ref_OptionPanel;
    [SerializeField] GameObject ref_GoBackButton;
    [SerializeField] GameObject ref_ContinueButton;
    [SerializeField] GameObject ref_ReplayButton;
    [SerializeField] GameObject ref_VictoryText;
    [SerializeField] GameObject ref_GameOverText;
    [SerializeField] GameObject ref_TotalCoinImg;
    [SerializeField] TextMeshProUGUI ref_TotalCoinText;


    private void Start()
    {
        CheckNullAllRef();

        SelfReferenceToUIWInGame();
        SelfReferenceToUIGameOver();
        SelfReferenceToUIGamePause();
        SelfReferenceToUICoinTextSetter();
    }

    void CheckNullAllRef()
    {
        CheckIsNotNull(ref_OptionButton, "ref_OptionButton in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_OptionPanel, "ref_OptionPanel in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_GoBackButton, "ref_GoBackButton in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_ContinueButton, "ref_ContinueButton in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_ReplayButton, "ref_ReplayButton in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_VictoryText, "ref_VictoryText in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_GameOverText, "ref_GameOverText in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_TotalCoinImg, "ref_TotalCoinImg in GameCanvasUICtrlBridge");
        CheckIsNotNull(ref_TotalCoinText, "ref_TotalCoinText in GameCanvasUICtrlBridge");
    }

    void SelfReferenceToUIWInGame()
    {
        UIWinGame local_ref_UIWinGame = UIData.GetInstance.GetComponent<UIWinGame>();
        if( CheckIsNotNull(local_ref_UIWinGame, "local_ref_UIWinGame in SelfReferenceToUIWInGame(Func In GameCanvasUICTrlBridge)") == false )
        { return; }

        local_ref_UIWinGame.ref_CoinTotalImg = this.ref_TotalCoinImg;
        local_ref_UIWinGame.ref_GoBackButton = this.ref_GoBackButton;
        local_ref_UIWinGame.ref_OptionButton = this.ref_OptionButton;
        local_ref_UIWinGame.ref_OptionPanel = this.ref_OptionPanel;
        local_ref_UIWinGame.ref_VictoryText = this.ref_VictoryText;
    }

    void SelfReferenceToUIGameOver()
    {
        UIGameOver local_ref_UIGameOver = UIData.GetInstance.GetComponent<UIGameOver>();
        if( CheckIsNotNull(local_ref_UIGameOver, "local_ref_UIGameOver in SelfReferenceToUIGameOver(Func In GameCanvasUICTrlBridge)") == false)
        { return; }

        local_ref_UIGameOver.ref_GameOverText = this.ref_GameOverText;
        local_ref_UIGameOver.ref_OptionPanel = this.ref_OptionPanel;
        local_ref_UIGameOver.ref_GoBackButton = this.ref_GoBackButton;
        local_ref_UIGameOver.ref_OptionButton = this.ref_OptionButton;
        local_ref_UIGameOver.ref_ReplayButton = this.ref_ReplayButton;
    }

    void SelfReferenceToUIGamePause()
    {
        UIGamePause local_ref_UIGamePause = UIData.GetInstance.GetComponent<UIGamePause>();
        if( CheckIsNotNull(local_ref_UIGamePause , "local_ref_UIGamePause in SelfReferenceToUIGamePause(Func In GameCanvasUICTrlBridge)") == false )
        { return; }

        local_ref_UIGamePause.ref_OptionPanel = this.ref_OptionPanel;
        local_ref_UIGamePause.ref_ContinueButton = this.ref_ContinueButton;
        local_ref_UIGamePause.ref_GoBackButton = this.ref_GoBackButton;
    }

    void SelfReferenceToUICoinTextSetter()
    {
        UICoinTextSetter local_ref_UICoinTextSetter = UIData.GetInstance.GetComponent<UICoinTextSetter>();
        if( CheckIsNotNull(local_ref_UICoinTextSetter ,"local_ref_UICoinTextSetter in SelfReferenceToUICoinTextSetter(Func In GameCanvasUICTrlBridge)") == false ) 
        { return; }

        local_ref_UICoinTextSetter.ref_CoinTotalText = this.ref_TotalCoinText;
    }
}
