using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private EventHandler eventHandler;
    
    [SerializeField] private Animator animator;
    private static readonly int IsDancing = Animator.StringToHash("isDancing");
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    private static readonly int IsPickingUp = Animator.StringToHash("isPickingUp");

    private string _questFruitName;

    [SerializeField] private TrackerController trackerController;

    [SerializeField] private GameObject puffEffect;
    [SerializeField] private GameObject collectedEffect;

    private void OnEnable()
    {
        eventHandler.OnGameStarted += GoIdle;
        eventHandler.OnFruitPickedUp += FruitPickedUp;
        eventHandler.OnGameFinished += GameFinished;
    }

    private void OnDisable()
    {
        eventHandler.OnGameStarted -= GoIdle;
        eventHandler.OnFruitPickedUp -= FruitPickedUp;
        eventHandler.OnQuestCompleted -= GameFinished;
    }

    private void GoIdle()
    {
        animator.SetTrigger(IsIdle);
    }

    private void GameFinished()
    {
        StartCoroutine(GoDanceRoutine());
    }

    private void FruitPickedUp(GameObject obj)
    {
        StartCoroutine(PickUpRoutine());
        if (obj.gameObject.name == _questFruitName+"(Clone)")
        {
            Instantiate(collectedEffect, obj.transform.position, quaternion.identity);
            eventHandler.InvokeOnFruitCollected(obj);
        }
        else
        {
            Instantiate(puffEffect, obj.transform.position, quaternion.identity);
            trackerController.TrackOnFruitCollected(obj);
            Destroy(obj);
        }
    }

    private IEnumerator PickUpRoutine()
    {
        animator.SetTrigger(IsPickingUp);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger(IsIdle);
    }

    private IEnumerator GoDanceRoutine()
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger(IsDancing);
    }

    public void SetQuestFruitName(string fruitName)
    {
        _questFruitName = fruitName;
    }
}
