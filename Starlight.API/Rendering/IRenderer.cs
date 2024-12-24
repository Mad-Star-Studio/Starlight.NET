namespace Starlight.API.Rendering;

public interface IRenderer
{
    public static IRenderer Current { get; set; }
    
    #region Properties

    public RenderingProfile Profile { get; set; }

    #endregion
    
    public void Render();
}