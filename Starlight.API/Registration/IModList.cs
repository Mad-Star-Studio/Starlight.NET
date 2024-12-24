namespace Starlight.API.Registration;

public interface IModList: ITypeRegistry
{
    public IEnumerable<Mod> Mods { get; }
}