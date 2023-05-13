using System.Collections.Generic;
using UnityEngine;

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

        public void Ctor() {

            toneSpriteDict = new Dictionary<ToneType, Sprite>();
            toneSpriteDict.Add(ToneType.Empty, spr_idle);
            toneSpriteDict.Add(ToneType.Ci, spr_ci);
            toneSpriteDict.Add(ToneType.Dong, spr_dong);
            toneSpriteDict.Add(ToneType.Da, spr_da);
            toneSpriteDict.Add(ToneType.Cicicici, spr_cicicici);
            toneSpriteDict.Add(ToneType.Duang, spr_duang);

            sprRenderer = GetComponentInChildren<SpriteRenderer>();

        }

        public void Loop(float fixdt) {

        }

        public void ChangeNote(ToneType toneType) {
            bool has = toneSpriteDict.TryGetValue(toneType, out var spr);
            if (has) {
                sprRenderer.sprite = spr;
            }
        }

    }

}