using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LeaderTalk : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private CanvasGroup leaderCanvas;
    [SerializeField] private CanvasGroup playerCanvas;
    [SerializeField] public bool inRange = false;
    //[SerializeField] private bool interacted = false;
    [SerializeField] public bool messageIsOn = false;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TextMeshProUGUI playerText;

    [SerializeField] private Quest firstQuest;
    [SerializeField] private Quest secondQuest;
    [SerializeField] private LeaderOptions leaderMessage;
    [SerializeField] private TextMeshProUGUI messageText;

    [SerializeField] private UnityEvent OnPressedY1;
    //[SerializeField] private UnityEvent OnPressedY2;




    private void Update()
    {
        if (inRange && Input.GetButtonDown("E") && !messageIsOn)// && !interacted)
        {
            MessageShow();
            ImmobilizePlayer();
        }
        if (inRange && Input.GetButtonDown("Y") && messageIsOn)
        {
            MessageShow();
            MobilizePlayer();
            if (firstQuest.active)
            {
                OnPressedY1.Invoke();
            }
            //if (secondQuest.completed)
            //{
            //    OnPressedY2.Invoke();
            //}
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
            CanvasStuffOn();
            messageText.text = leaderMessage.firstMessage;
            if (firstQuest.active)
            {
                messageText.text = leaderMessage.secondMessage;
            }
            if (secondQuest.completed)
            {
                messageText.text = leaderMessage.thirdMessage;
            }
        }
        else
        {
            CanvasStuffOff();
        }
            
    }

    private void ImmobilizePlayer()
    {
        playerMovement.immobilized = true;
        player.ChangeMovementState(Player.MovementState.Idle);
        playerRB.velocity = Vector2.zero;
    }

    private void MobilizePlayer()
    {
        playerMovement.immobilized = false;
    }

    private void CanvasStuffOn()
    {
        leaderCanvas.alpha = 1;
        playerText.text = "Y";
        leaderCanvas.interactable = true;
        leaderCanvas.blocksRaycasts = true;
        //interacted = true;
        messageIsOn = true;
    }

    private void CanvasStuffOff()
    {
        leaderCanvas.alpha = 0;
        playerCanvas.alpha = 0;
        playerText.text = "E";
        leaderCanvas.interactable = false;
        leaderCanvas.blocksRaycasts = false;
        messageIsOn = false;

    }



}
