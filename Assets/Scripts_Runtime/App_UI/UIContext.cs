

public class UIContext {
    // panel


    // inject
    public AssetsContext assetsContext;


    public UIContext() {
    }

    public void Inject(AssetsContext assetsContext) {
        this.assetsContext = assetsContext;
    }

}