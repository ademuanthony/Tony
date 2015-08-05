using System;

namespace Tony.Common.DependencyInjection.Resolver
{
    /// <summary>
    /// Responsible for registering types in unity configuration by implementing IComponent
    /// </summary>
    public interface IRegisterComponent
    {
        /// <summary>
        /// Register type method
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        /// <summary>
        /// Register type with method with System.Type parameter
        /// </summary>
        /// <param name="fromType"></param>
        /// <param name="toType"></param>
        void RegisterType(Type fromType, Type toType, bool withInterception = false);

        /// <summary>
        /// Register type with container controlled life time manager
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;


        void RegisterTypeWithControlledLifeTime(Type fromType, Type toType, bool withInterception = false);
    }
}
