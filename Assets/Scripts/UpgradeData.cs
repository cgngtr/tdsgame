using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    WeaponUnlock,
    ItemUpgrade,
    ItemUnlock
}

public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;
}
