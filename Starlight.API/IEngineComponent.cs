namespace Starlight.API;

public interface IEngineComponent
{
    public void Initialize();

    public void Update();

    public void Render();

    public void TearDown();
}
