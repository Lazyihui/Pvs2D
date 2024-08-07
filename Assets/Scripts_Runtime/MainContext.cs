using UnityEngine  ;

public class MainContext {
    public AssetsContext assetsContext;

    public UIContext uiContext;


        public IDService idService;
    public MainContext() {
        assetsContext = new AssetsContext();
        uiContext = new UIContext();
        idService = new IDService();
    }


    public void Inject(Canvas canvas) {
        uiContext.Inject(assetsContext, canvas,idService);
    }
}