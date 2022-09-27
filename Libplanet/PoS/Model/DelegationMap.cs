using System.Collections.Generic;
using System.Linq;
using Bencodex.Types;

namespace Libplanet.PoS.Model
{
    public class DelegationMap
    {
        public DelegationMap(Address address)
        {
            Address = DeriveAddress(address);
            Delegations = new SortedSet<Address>();
            UnbondingDelegations = new SortedSet<Address>();
        }

        public DelegationMap(IValue serialized)
        {
            List serializedList = (List)serialized;
            Address = serializedList[0].ToAddress();
            Delegations = new SortedSet<Address>(
                ((List)serializedList[1]).Select(item => item.ToAddress()));
            UnbondingDelegations = new SortedSet<Address>(
                ((List)serializedList[2]).Select(item => item.ToAddress()));
        }

        public DelegationMap(DelegationMap delegationMap)
        {
            Address = delegationMap.Address;
            Delegations = delegationMap.Delegations;
            UnbondingDelegations = delegationMap.UnbondingDelegations;
        }

        public Address Address { get; }

        public SortedSet<Address> Delegations { get; set; }

        public SortedSet<Address> UnbondingDelegations { get; set; }

        public static Address DeriveAddress(
            Address address)
        {
            return address.Derive("DelegationMap");
        }

        public IValue Serialize()
        {
            return List.Empty
                .Add(Address.Serialize())
                .Add(new List(Delegations.Select(item => item.Serialize())))
                .Add(new List(UnbondingDelegations.Select(item => item.Serialize())));
        }
    }
}
