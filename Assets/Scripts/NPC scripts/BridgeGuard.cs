using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BridgeGuard : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private CanvasGroup guardCanvas;
    [SerializeField] private bool messageConfirm;
    [SerializeField] private CanvasGroup playerCanvas;
    [SerializeField] private bool inRange = false;
    [SerializeField] private bool interacted = false;
    [SerializeField] private bool messageIsOn = false;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TextMeshProUGUI playerText;

    public delegate void TalkedToBridgeGuard();
    public static event TalkedToBridgeGuard OnTalkingToBridgeGuard;

    private void Update()
    {
        if (inRange && Input.GetButtonDown("E") && !messageIsOn && !interacted)
        {
            MessageShow();
            ImmobilizePlayer();
        }
        if (inRange && Input.GetButtonDown("Y") && messageIsOn)
        { 
            MessageShow();
            MobilizePlayer();
            OnTalkingToBridgeGuard?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 1;
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 0;
            inRange = false;
        }
    }

    private void MessageShow()
    {
        if (!messageIsOn)
        {
            guardCanvas.alpha = 1;
            playerText.text = "Y";
            guardCanvas.interactable = true;
            guardCanvas.blocksRaycasts = true;
            interacted = true;
            messageIsOn = true;
        }
        else 
        {
            guardCanvas.alpha = 0;
            playerCanvas.alpha = 0;
            playerText.text = "E";
            guardCanvas.interactable = false;
            guardCanvas.blocksRaycasts = false;
            messageIsOn = false;
        }
    }

    private void ImmobilizePlayer()
    {
        playerMovement.immobilized = true;
        playerRB.velocity = Vector2.zero;
    }

    private void MobilizePlayer()
    {
        playerMovement.immobilized = false;
    }



}
