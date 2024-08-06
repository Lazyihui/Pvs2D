using UnityEngine  ;

public class MainContext {
    public AssetsContext assetsContext;

    public UIContext uiContext;

    public MainContext() {
        assetsContext = new AssetsContext();
        uiContext = new UIContext();
    }


    public void Inject(Canvas canvas) {
        uiContext.Inject(assetsContext, canvas);
    }
}