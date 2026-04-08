using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HW3PlayerDialogue : MonoBehaviour
{
    public List<string> dialogue = new List<string>();

    public GameObject portalPrefab; // assign in inspector

    private Transform portalSpawnPoint;

    private bool canSpeak = false;
    private bool isSpeaking = false;

    private bool spawnPortalAfterDialogue = false;
    private bool portalSpawned = false;

    private GameObject _talkPanel;
    private TextMeshProUGUI _talkText;
    private int _talkIndex = 0;

    private void Start()
    {
        _talkText = GameObject.Find(HW3Structs.GameObjects.talkText)
                    .GetComponent<TextMeshProUGUI>();

        _talkPanel = GameObject.Find(HW3Structs.GameObjects.talkPanel);
        _talkPanel.SetActive(false);
    }

    void Update()
    {
        if (isSpeaking && Input.GetKeyDown(KeyCode.E))
        {
            // reached last dialogue line
            if (dialogue.Count - 1 == _talkIndex)
            {
                isSpeaking = false;
                _talkPanel.SetActive(false);

                if (spawnPortalAfterDialogue)
                    SpawnPortal();
            }
            else
            {
                _talkIndex++;
                _talkText.text = dialogue[_talkIndex];
            }
        }
        else if (canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            isSpeaking = true;
            _talkPanel.SetActive(true);

            _talkIndex = 0;
            _talkText.text = dialogue[_talkIndex];
        }
    }

    void SpawnPortal()
    {
        if (portalSpawned || portalSpawnPoint == null)
            return;

        Instantiate(
            portalPrefab,
            portalSpawnPoint.position,
            portalSpawnPoint.rotation
        );

        portalSpawned = true;
    }

    public void SetCanSpeak(bool newCanSpeak)
    {
        canSpeak = newCanSpeak;
    }

    public bool IsSpeaking()
    {
        return isSpeaking;
    }

    public void CopyDialogue(List<string> newDialogue)
    {
        dialogue.Clear();
        dialogue.AddRange(newDialogue);
    }

    public void SetSpawnPortal(bool shouldSpawn)
    {
        spawnPortalAfterDialogue = shouldSpawn;
    }

    public void SetPortalSpawnPoint(Transform spawnPoint)
    {
        portalSpawnPoint = spawnPoint;
    }
}