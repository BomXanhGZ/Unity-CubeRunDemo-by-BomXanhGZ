
using UnityEngine;
using static GlobalSpace.GameUtilities;


public class HomeSettingButton : MonoBehaviour
{
    [SerializeField] GameObject ref_HomeSettingPanel;


    private void Start()
    {
        CheckIsNotNull(ref_HomeSettingPanel, "ref_HomeSettingPanel in HomeSettingButton");
    }

    public void OnClickHomeSettingButton()
    {
        ref_HomeSettingPanel.SetActive(true);
    }
}
