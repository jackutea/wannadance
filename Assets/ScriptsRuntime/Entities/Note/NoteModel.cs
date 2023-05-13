using System;
using UnityEngine;

namespace WD {

    // 音符
    [Serializable]
    public class NoteModel {

        public ToneType toneType;
        public AudioClip clip;
        public bool isReplay;
        public float beatMultiple;

    }

}