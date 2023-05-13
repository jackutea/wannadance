using System.Collections.Generic;
using UnityEngine;
using GameArki.FPEasing;

namespace WD {

    public class RoleEntity : MonoBehaviour {

        [SerializeField] Sprite spr_idle;
        [SerializeField] Sprite spr_dong;
        [SerializeField] Sprite spr_ci;
        [SerializeField] Sprite spr_da;
        [SerializeField] Sprite spr_cicicici;
        [SerializeField] Sprite spr_duang;

        Dictionary<ToneType, Sprite> toneSpriteDict;

        SpriteRenderer sprRenderer;

        Vector3 oringinPos;
        [SerializeField] Vector3 targetOffset = new Vector3(0, 1, 0);
        EasingModel[] combineEasing;
        public bool isCoach;

        float time;

        public void Ctor() {

            oringinPos = transform.position;

            toneSpriteDict = new Dictionary<ToneType, Sprite>();
            toneSpriteDict.Add(ToneType.Empty, spr_idle);
            toneSpriteDict.Add(ToneType.Ci, spr_ci);
            toneSpriteDict.Add(ToneType.Dong, spr_dong);
            toneSpriteDict.Add(ToneType.Da, spr_da);
            toneSpriteDict.Add(ToneType.Cicicici, spr_cicicici);
            toneSpriteDict.Add(ToneType.Duang, spr_duang);

            sprRenderer = GetComponentInChildren<SpriteRenderer>();

            time = 0;
            combineEasing = new EasingModel[3];
            combineEasing[0] = new EasingModel() {
                type = EasingType.InCubic,
                timeWeight = 0.15f,
                maxValuePercentReduce = 0,
                isFlipValue = false
            };
            combineEasing[1] = new EasingModel() {
                type = EasingType.OutQuad,
                timeWeight = 0.25f,
                maxValuePercentReduce = 0,
                isFlipValue = true
            };
            combineEasing[2] = new EasingModel() {
                type = EasingType.Immediate,
                timeWeight = 0.6f,
                maxValuePercentReduce = 0,
                isFlipValue = true
            };

        }

        public void Loop(float fixdt) {
            float duration = Config.BEAT;
            if (time >= duration) {
                time -= duration;
                if (!isCoach) {
                ChangeNote(ToneType.Empty);
                }
            }
            Vector3 offset = EasingHelper.Ease3D_Combine(combineEasing, time, duration, Vector3.zero, targetOffset);
            transform.position = oringinPos + offset;
            time += fixdt;
        }

        public void ChangeNote(ToneType toneType) {
            bool has = toneSpriteDict.TryGetValue(toneType, out var spr);
            if (has) {
                sprRenderer.sprite = spr;
            }
        }

    }

}