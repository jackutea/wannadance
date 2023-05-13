using System.Collections.Generic;
using UnityEngine;

namespace WD {

    public class AssetsCore : MonoBehaviour {

        [SerializeField] RoleEntity prefabRole;
        [SerializeField] MusicEntity prefabMusic;
        [SerializeField] List<MissionSo> missionSos;

        public RoleEntity GetRolePrefab() {
            return prefabRole;
        }

        public MusicEntity GetMusicPrefab() {
            return prefabMusic;
        }

        public MissionEntity GetMissionEntity(int missionID) {
            var so = missionSos.Find(x => x.mission.typeID == missionID);
            return so?.mission;
        }

    }

}