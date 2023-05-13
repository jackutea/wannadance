using System.Collections.Generic;
using UnityEngine;

namespace WD {

    public class MusicEntity : MonoBehaviour {

        const int BPM = 120;
        const float BEAT = 60f / BPM;

        List<NoteModel> all;
        Dictionary<ToneType, AudioSource> players;

        int currentNote;
        float stageTime;

        public void Ctor() {

            this.all = new List<NoteModel>();

            this.players = new Dictionary<ToneType, AudioSource>();

            var note_dong = transform.Find("note_dong").GetComponent<AudioSource>();
            var note_ci = transform.Find("note_ci").GetComponent<AudioSource>();
            var note_da = transform.Find("note_da").GetComponent<AudioSource>();
            var note_duang = transform.Find("note_duang").GetComponent<AudioSource>();
            var note_cicicici = transform.Find("note_cicicici").GetComponent<AudioSource>();
            var note_empty = transform.Find("note_empty").GetComponent<AudioSource>();
            players.Add(ToneType.Dong, note_dong);
            players.Add(ToneType.Ci, note_ci);
            players.Add(ToneType.Da, note_da);
            players.Add(ToneType.Duang, note_duang);
            players.Add(ToneType.Cicicici, note_cicicici);
            players.Add(ToneType.Empty, note_empty);

        }

        public void FixedTick(float fixdt) {
            var note = GetCurrent();
            if (note == null) {
                return;
            }

            bool has = TryGetPlayer(note.toneType, out var player);
            if (!has) {
                return;
            }

            if (player.clip != note.clip) {
                player.clip = note.clip;
                player.Stop();
                player.Play();
            }

            stageTime += fixdt;

            float tar = BEAT * note.beatMultiple;

            if (stageTime >= tar) {
                stageTime -= tar;
                player.clip = null;
                bool isOver = NextNote();
                WDLog.Log($"ENDTIME: {Time.time}");
            }

        }

        bool NextNote() {
            bool isOver = false;
            currentNote += 1;
            if (currentNote >= all.Count) {
                isOver = true;
                currentNote %= all.Count;
            }
            return isOver;
        }

        NoteModel GetCurrent() {
            if (currentNote < 0 || currentNote >= all.Count) {
                return null;
            }
            return all[currentNote];
        }

        bool TryGetPlayer(ToneType type, out AudioSource player) {
            return players.TryGetValue(type, out player);
        }

        public void SetSequence(NoteModel[] notes) {
            all.Clear();
            all.AddRange(notes);
        }

    }

}