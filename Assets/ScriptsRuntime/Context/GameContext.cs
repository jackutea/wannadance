namespace WD {

    public class GameContext {

        AssetsCore assetsCore;
        public AssetsCore AssetsCore => assetsCore;

        Config config;
        public Config Config => config;

        public MissionEntity missionEntity;
        public MusicEntity musicEntity;
        public RoleEntity roleCoach;
        public RoleEntity rolePlayer;

        public ToneType inputToneType;
        public bool hasInput;

        public GameContext() {
            this.config = new Config();
            this.inputToneType = ToneType.Empty;
        }

        public void Inject(AssetsCore assetsCore) {
            this.assetsCore = assetsCore;
        }

    }

}