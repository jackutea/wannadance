namespace WD {

    public class Config {

        public static int BPM => 120;
        public static float BEAT => 60f / BPM;

        public int originalMission;

        public Config() {
            this.originalMission = 1;
        }

    }

}