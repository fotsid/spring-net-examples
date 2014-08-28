using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Objects.Factory.Support;
using System.Collections;
using System.Reflection;

namespace MyService
{
    public class ServiceLocatorImplementer : IMethodReplacer
    {
        private readonly Type _forType;
        public ServiceLocatorImplementer(Type forType)
        {
            this._forType = forType;
        }

        protected IEnumerable GetAllImplementers()
        {
            var idObjects = Spring.Context.Support.ContextRegistry.GetContext()
                .GetObjectsOfType(_forType);

            return idObjects.Values;
        }

        public object Implement(object target, MethodInfo method, object[] arguments)
        {
            return GetAllImplementers();
        }
    }
}