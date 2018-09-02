using Microsoft.Practices.Unity;

namespace VirtualFightStick.Core.Registration
{
    interface IRegistrationFactory
    {
        void RegisterApplication(IUnityContainer container);
    }
}
