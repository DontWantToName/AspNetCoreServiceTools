using System;
public class IdentifyingAttribute : Attribute
    {
        public ServiceLifeTimeIdentifying ServiceLifeTime;

        public IdentifyingAttribute(ServiceLifeTimeIdentifying serviceLifeTime)
        {
            ServiceLifeTime = serviceLifeTime;
        }
    }
    public enum ServiceLifeTimeIdentifying
    {
        Transient = 0,
        Scoped = 1,
        Singleton = 2
    }
