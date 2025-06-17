using TMPro;
using UnityEngine;
using static GlobalSpace.GameUtilities;


public class PlayLevelButtonText : MonoBehaviour
{
    string color = "#FF6347"; //hex
    string button_text { set; get; }
    TextMeshProUGUI ref_PlayLevelButtonText;


    public void SetTextPlayLevelButton(int _idx)
    {
        ref_PlayLevelButtonText = GetComponent<TextMeshProUGUI>();
        CheckIsNotNull(ref_PlayLevelButtonText, "ref_PlayLevelButtonText in PlayLevelButtonText");

        string name_button_text = (1 + _idx).ToString();
        ref_PlayLevelButtonText.text = $"<b><i><color={color}>{name_button_text}</color></i></b>";
        ref_PlayLevelButtonText.enableAutoSizing = true;
    }
}
