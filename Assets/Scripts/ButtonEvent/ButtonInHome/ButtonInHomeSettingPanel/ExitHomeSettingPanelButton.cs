using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalSpace.GameUtilities;


public class ExitHomeSettingPanelButton : MonoBehaviour
{
    [SerializeField] GameObject ref_HomeSettingPanel;


    private void Start()
    {
        CheckIsNotNull(ref_HomeSettingPanel, "ref_HomeSettingPanel in ExitHomeSettingPanelButton");
    }

    public void OnClickExitHomeSettingPanelButton()
    {
        ref_HomeSettingPanel.SetActive(false);
    }
}
