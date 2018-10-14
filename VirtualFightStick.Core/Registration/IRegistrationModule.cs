using Microsoft.Practices.Unity;

namespace VirtualFightStick.Core.Registration
{
    public interface IRegistrationModule
    {
        void Register(IUnityContainer container);
    }
}
