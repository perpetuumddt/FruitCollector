using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScreenUIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    protected void SetActive(bool isActive)
    {
        canvasGroup.alpha = isActive ? 1 : 0;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
    }

    public virtual void ActivateScreen()
    {
        SetActive(true);
    }

    public virtual void DeactivateScreen()
    {
        SetActive(false);
    }
}
