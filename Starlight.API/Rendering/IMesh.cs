namespace Starlight.API.Rendering;

public interface IMesh: IRenderingObject
{
    
    #region Attributes
    
    public IMeshAttribute[] Attributes { get; }

    public IEnumerable<byte> GetAttribute(IMeshAttribute attribute, int offset, int count);
    public void SetAttribute(IMeshAttribute attribute, IEnumerable<byte> data, int offset);
    public void AddAttribute(IMeshAttribute attribute, IEnumerable<byte> data);
    public void ContainsAttribute(IMeshAttribute attribute);
    public void RemoveAttribute(IMeshAttribute attribute);

    #endregion
}