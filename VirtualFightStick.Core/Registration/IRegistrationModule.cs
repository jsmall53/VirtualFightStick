using Microsoft.Practices.Unity;

namespace VirtualFightStick.Core.Registration
{
    interface IRegistrationModule
    {
        void Register(IUnityContainer container);
    }
}
