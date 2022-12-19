using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        bool estMort = false;
        public Deathscreen Deathscreen;

        private HealthManager healthManager;
        private GameObject player;
        private MeshRenderer invisible;
        private MeshCollider playerCollider;

        private Vector3 spawnposition;

        void Start()
        {
            player = GameObject.Find("Player");
            spawnposition = new Vector3(0.0f, 1.0f, 0.0f);
        }

        void FixedUpdate()
        {
            if(estMort)
            {
                player.transform.position = spawnposition;
            }
        }

        public void SetupPlayer(GameObject _player)
        {
            player = _player;
            healthManager = player.GetComponentInChildren<HealthManager>();
            invisible = player.GetComponent<MeshRenderer>();
            playerCollider = player.GetComponent<MeshCollider>();
            invisible.enabled = true;
            playerCollider.enabled = true;
        }

        public void Decede()
        {
            if(estMort == false)
            {
                Deathscreen.Setup();
                invisible.enabled = false;
                playerCollider.enabled = false;
                estMort = true;
            }
        }

        public void Respawn()
        {
            healthManager.Respawn();
            estMort = false;
            invisible.enabled = true;
            playerCollider.enabled = true;
            Deathscreen.QuitScreen();
        }
}

