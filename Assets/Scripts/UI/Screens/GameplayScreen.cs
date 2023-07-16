using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScreen : ScreenUIController
{
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private Transform floatingTextContainer;
    public void FloatingText(GameObject obj)
    {
        Instantiate(floatingTextPrefab, floatingTextContainer.position, Quaternion.identity, floatingTextContainer);
    }
    
    public override void ActivateScreen()
    {
        base.ActivateScreen();
    }

    public override void DeactivateScreen()
    {
        base.DeactivateScreen();
    }
}
