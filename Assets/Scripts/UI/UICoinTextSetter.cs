using TMPro;
using UnityEngine;
using static GlobalSpace.GameUtilities;


public class UICoinTextSetter : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;

    public TextMeshProUGUI ref_CoinTotalText { set; get; }


    private void Start()
    {

        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in UICoinTextSetter");
    }

    public void SetTextCoin()
    {
        CheckIsNotNull(ref_CoinTotalText, "ref_CoinTotalText in UICoinTextSetter");
        
        //todo

        string coin_text = ref_GameManagerData.score_.ToString();
        ref_CoinTotalText.text = "x" + coin_text;
    }
}
