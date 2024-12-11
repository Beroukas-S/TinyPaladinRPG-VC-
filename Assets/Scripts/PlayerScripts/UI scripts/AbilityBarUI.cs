using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AbilityBarUI : MonoBehaviour
{
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private UnityEngine.UI.Image swordImage;
    [SerializeField] private UnityEngine.UI.Image shieldImage;
    [SerializeField] private UnityEngine.UI.Image flameImage;
    [SerializeField] private UnityEngine.UI.Image growImage;
    [SerializeField] private PlayerBlock playerBlock;
    [SerializeField] private Shooting shooting;

    private void Update()
    {
        if (playerCombat.timer > 0)
        {
            swordImage.color = Color.red;
        }
        else
        {
            swordImage.color = Color.white;
        }

        if (playerBlock.timer > 0)
        {
            shieldImage.color = Color.red;
        }
        else
        {
            shieldImage.color = Color.white;
        }
        if (shooting.timer > 0 || !PlayerStats.Instance.fireball)
        {
            flameImage.color = Color.red;
        }
        else
        {
            flameImage.color = Color.white;
        }
        //για το grow ότι καταλήξει

    }
}
