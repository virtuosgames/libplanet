using System;

namespace Libplanet.PoS
{
    public class NullDelegationMapException : Exception
    {
        public NullDelegationMapException(Address address)
            : base($"DelegationMap {address} not found")
        {
        }
    }
}
