using UnityEngine;

namespace WD {

    public class GameController {

        GameContext ctx;

        public GameController() { }

        public void Inject(GameContext ctx) {
            this.ctx = ctx;
        }

        public void EnterMission(int missionTypeID) {

            Clear();

            var assets = ctx.AssetsCore;
            var mission = assets.GetMissionEntity(missionTypeID);
            mission.Init();
            ctx.missionEntity = mission;

            var music = assets.GetMusicPrefab();
            music = GameObject.Instantiate(music);
            music.Ctor();
            music.SetSequence(mission.TotalMissions);
            ctx.musicEntity = music;

            var coach = assets.GetRolePrefab();
            coach = GameObject.Instantiate(coach);
            coach.transform.position = new Vector3(5, 3, 0);
            coach.Ctor();
            coach.isCoach = true;
            ctx.roleCoach = coach;

            var player = assets.GetRolePrefab();
            player = GameObject.Instantiate(player);
            player.transform.position = new Vector3(-5, 3, 0);
            player.Ctor();
            ctx.rolePlayer = player;

            // Bind
            music.OnChangeToNoteHandle += (toneType) => {
                ctx.roleCoach.ChangeNote(toneType);
            };

        }

        void Clear() {
            if (ctx.musicEntity != null) {
                GameObject.Destroy(ctx.musicEntity.gameObject);
                ctx.musicEntity = null;
            }

            if (ctx.roleCoach != null) {
                GameObject.Destroy(ctx.roleCoach.gameObject);
                ctx.roleCoach = null;
            }

            if (ctx.rolePlayer != null) {
                GameObject.Destroy(ctx.rolePlayer.gameObject);
                ctx.rolePlayer = null;
            }

            ctx.missionEntity = null;
        }

        public void Tick() {

            ToneType inputToneType = ToneType.Empty;
            if (Input.GetKey(KeyCode.W)) {
                inputToneType = ToneType.Dong;
            }
            if (Input.GetKey(KeyCode.A)) {
                inputToneType = ToneType.Ci;
            }
            if (Input.GetKey(KeyCode.S)) {
                inputToneType = ToneType.Da;
            }
            if (Input.GetKey(KeyCode.E)) {
                inputToneType = ToneType.Cicicici;
            }
            if (Input.GetKey(KeyCode.D)) {
                inputToneType = ToneType.Duang;
            }

            if (inputToneType != ToneType.Empty) {
                ctx.inputToneType = inputToneType;
                ctx.hasInput = true;
            }

        }

        public void FixedTick(float fixdt) {

            if (ctx.musicEntity != null) {
                ctx.musicEntity.Loop(fixdt);
            }

            if (ctx.roleCoach != null) {
                ctx.roleCoach.Loop(fixdt);
            }

            if (ctx.rolePlayer != null) {
                ctx.rolePlayer.Loop(fixdt);
            }

            ToneType inputToneType = ctx.inputToneType;
            if (ctx.hasInput) {
                ctx.hasInput = false;
                ctx.rolePlayer.ChangeNote(inputToneType);
                ctx.inputToneType = ToneType.Empty;
            }

        }

    }

}