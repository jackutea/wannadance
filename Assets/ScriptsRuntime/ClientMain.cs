using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WD {

    public class ClientMain : MonoBehaviour {

        GameContext gameContext;
        GameController gameController;

        [SerializeField] AssetsCore assetsCore;

        void Awake() {
            this.gameContext = new GameContext();
            this.gameController = new GameController();
        }

        void Start() {

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 240;

            gameContext.Inject(assetsCore);
            gameController.Inject(gameContext);

            gameController.EnterMission(gameContext.Config.originalMission);

            WDLog.Log("ClientMain.Start");

        }

        void Update() {
            float dt = Time.deltaTime;
            gameController.Tick();
        }

        void FixedUpdate() {
            float fixdt = Time.fixedDeltaTime;
            gameController.FixedTick(fixdt);
        }

    }
}
