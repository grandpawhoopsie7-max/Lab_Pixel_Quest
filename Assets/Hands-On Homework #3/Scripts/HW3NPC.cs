using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HW3NPC : MonoBehaviour
{
    public List<string> dialogue = new List<string>();

    public bool spawnPortalAfterDialogue = true;   // choose if this NPC spawns portal
    public Transform portalSpawnPoint;              // choose WHERE portal appears

    private GameObject _talkIcon;

    private void Start()
    {
        _talkIcon = transform.Find(HW3Structs.GameObjects.talkIcon).gameObject;
        _talkIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == HW3Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(true);

            HW3PlayerDialogue playerDialogue =
                collision.GetComponent<HW3PlayerDialogue>();

            playerDialogue.CopyDialogue(dialogue);
            playerDialogue.SetCanSpeak(true);

            // tell player what this NPC should do
            playerDialogue.SetSpawnPortal(spawnPortalAfterDialogue);
            playerDialogue.SetPortalSpawnPoint(portalSpawnPoint);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == HW3Structs.Tags.playerTag)
        {
            _talkIcon.SetActive(false);
            collision.GetComponent<HW3PlayerDialogue>().SetCanSpeak(false);
        }
    }
}