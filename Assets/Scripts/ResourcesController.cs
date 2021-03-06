using UnityEngine;

using UnityEngine.UI;



public class ResourcesController : MonoBehaviour

{

    public Text ResourceDescription;

    public Text ResourceUpgradeCost;

    public Text ResourceUnlockCost;
    public Button ResourceButton;
    public Image ResourceImage;



    private ResourceConfig _config;



    private int _level = 1;
    private void Start()

    {

        ResourceButton.onClick.AddListener(UpgradeLevel);

    }



    public void SetConfig(ResourceConfig config)

    {

        _config = config;



        // ToString("0") berfungsi untuk membuang angka di belakang koma

        ResourceDescription.text = $"{ _config.Name } Lv. { _level }\n+{ GetOutput().ToString("0") }";

        ResourceUnlockCost.text = $"Unlock Cost\n{ _config.UnlockCost }";

        ResourceUpgradeCost.text = $"Upgrade Cost\n{ GetUpgradeCost() }";

    }



    public double GetOutput()

    {

        return _config.Output * _level;

    }



    public double GetUpgradeCost()

    {

        return _config.UpgradeCost * _level;

    }



    public double GetUnlockCost()

    {

        return _config.UnlockCost;

    }
     
}
public void UpgradeLevel()

{

    double upgradeCost = GetUpgradeCost();

    if (GameManager.Instance.TotalGold < upgradeCost)

    {

        return;

    }



    GameManager.Instance.AddGold(-upgradeCost);

    _level++;



    ResourceUpgradeCost.text = $"Upgrade Cost\n{ GetUpgradeCost() }";

    ResourceDescription.text = $"{ _config.Name } Lv. { _level }\n+{ GetOutput().ToString("0") }";

}

