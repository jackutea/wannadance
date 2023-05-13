using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WD {

    public class ClientMain : MonoBehaviour {

        [SerializeField] AssetsCore assetsCore;
        [SerializeField] MusicEntity musicEntity;
        [SerializeField] MissionSo mission1;

        void Start() {

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 240;

            musicEntity.Ctor();

            var mission = mission1.mission;
            mission.Init();

            musicEntity.SetSequence(mission.TotalMissions);

            WDLog.Log("ClientMain.Start");

        }

        void FixedUpdate() {
            float dt = Time.fixedDeltaTime;
            musicEntity.FixedTick(dt);
        }

    }
}
