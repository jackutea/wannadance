using System;
using UnityEngine;

namespace WD {

    [Serializable]
    public class MissionEntity {

        public int typeID;
        public bool isTutorial;

        // 总任务
        [SerializeField] NoteSo[] binding_so_totalMissions;
        NoteModel[] totalMissions;
        public NoteModel[] TotalMissions => totalMissions;

        // 当前任务
        public int targetContinousCompletedCount; // 连续完成次数

        // 完成度
        public int continousCompletedCount;

        public MissionEntity() { }

        public void Init() {
            var soMissions = binding_so_totalMissions;
            totalMissions = new NoteModel[soMissions.Length];
            for (int i = 0; i < soMissions.Length; i += 1) {
                totalMissions[i] = soMissions[i].model;
            }
        }

    }

}