using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestSytemPlayer : MonoBehaviour
{
    // Your player-related logic goes here

    public static void ApplyUpgrade(Upgrade upgrade)
    {
        // Implement logic to apply the upgrade to the player
        // For example, you might increase player health, damage, etc.
        Debug.Log($"Applying upgrade: {upgrade.upgradeName} (+{upgrade.upgradeValue})");
    }
}
