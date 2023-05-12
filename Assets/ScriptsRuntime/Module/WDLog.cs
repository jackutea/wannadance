using UnityEngine;

namespace WD {

    public static class WDLog {

        public static void Log(object msg) {
            Debug.Log(msg);
        }

        public static void LogWarning(object msg) {
            Debug.LogWarning(msg);
        }

        public static void LogError(object msg) {
            Debug.LogError(msg);
        }

        public static void Assert(bool condition, object msg) {
            Debug.Assert(condition, msg);
        }

        public static void Assert(bool condition) {
            Debug.Assert(condition);
        }
    }
}