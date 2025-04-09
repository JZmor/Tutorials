using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public GameObject UI;
    
    public TextMeshProUGUI sellAmount;
    
    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.getBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
