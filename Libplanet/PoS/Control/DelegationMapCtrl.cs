using Libplanet.Action;
using Libplanet.PoS.Model;

namespace Libplanet.PoS.Control
{
    internal static class DelegationMapCtrl
    {
        internal static DelegationMap? GetDelegationMap(
            IAccountStateDelta states,
            Address delegationMapAddress)
        {
            if (states.GetState(delegationMapAddress) is { } value)
            {
                return new DelegationMap(value);
            }

            return null;
        }

        internal static (IAccountStateDelta, DelegationMap) FetchDelegationMap(
            IAccountStateDelta states,
            Address address)
        {
            Address delegationMapAddress = DelegationMap.DeriveAddress(address);
            DelegationMap delegationMap;
            if (states.GetState(delegationMapAddress) is { } value)
            {
                delegationMap = new DelegationMap(value);
            }
            else
            {
                delegationMap = new DelegationMap(address);
                states = states.SetState(delegationMap.Address, delegationMap.Serialize());
            }

            return (states, delegationMap);
        }

        internal static IAccountStateDelta AddDelegation(
           IAccountStateDelta states,
           Address delegationAddress)
        {
            if (DelegateCtrl.GetDelegation(states, delegationAddress) is { } delegation)
            {
                DelegationMap subDelegationMap;
                (states, subDelegationMap) = FetchDelegationMap(
                    states, delegation.DelegatorAddress);
                subDelegationMap.Delegations.Add(delegationAddress);
                states = states.SetState(subDelegationMap.Address, subDelegationMap.Serialize());

                DelegationMap objDelegationMap;
                (states, objDelegationMap) = FetchDelegationMap(
                    states, delegation.ValidatorAddress);
                objDelegationMap.Delegations.Add(delegationAddress);
                states = states.SetState(objDelegationMap.Address, objDelegationMap.Serialize());
            }
            else
            {
                throw new NullDelegationException(delegationAddress);
            }

            return states;
        }

        internal static IAccountStateDelta RemoveDelegation(
           IAccountStateDelta states,
           Address delegationAddress)
        {
            if (DelegateCtrl.GetDelegation(states, delegationAddress) is { } delegation)
            {
                Address subDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.DelegatorAddress);
                if (GetDelegationMap(states, subDelegationMapAddress) is { } subDelegationMap)
                {
                    subDelegationMap.Delegations.Remove(delegationAddress);
                    states = states.SetState(
                        subDelegationMap.Address, subDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(subDelegationMapAddress);
                }

                Address objDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.ValidatorAddress);
                if (GetDelegationMap(states, objDelegationMapAddress) is { } objDelegationMap)
                {
                    objDelegationMap.Delegations.Remove(delegationAddress);
                    states = states.SetState(
                        objDelegationMap.Address, objDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(objDelegationMapAddress);
                }
            }
            else
            {
                throw new NullDelegationException(delegationAddress);
            }

            return states;
        }

        internal static IAccountStateDelta ReplaceDelegation(
           IAccountStateDelta states,
           Address srcDelegationAddress,
           Address dstDelegationAddress)
        {
            states = RemoveDelegation(states, srcDelegationAddress);
            states = AddDelegation(states, dstDelegationAddress);

            return states;
        }

        internal static IAccountStateDelta UnbondDelegation(
           IAccountStateDelta states,
           Address delegationAddress)
        {
            if (DelegateCtrl.GetDelegation(states, delegationAddress) is { } delegation)
            {
                Address subDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.DelegatorAddress);
                if (GetDelegationMap(states, subDelegationMapAddress) is { } subDelegationMap)
                {
                    subDelegationMap.Delegations.Remove(delegationAddress);
                    subDelegationMap.UnbondingDelegations.Add(delegationAddress);
                    states = states.SetState(
                        subDelegationMap.Address, subDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(subDelegationMapAddress);
                }

                Address objDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.ValidatorAddress);
                if (GetDelegationMap(states, objDelegationMapAddress) is { } objDelegationMap)
                {
                    objDelegationMap.Delegations.Remove(delegationAddress);
                    objDelegationMap.UnbondingDelegations.Add(delegationAddress);
                    states = states.SetState(
                        objDelegationMap.Address, objDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(objDelegationMapAddress);
                }
            }
            else
            {
                throw new NullDelegationException(delegationAddress);
            }

            return states;
        }

        internal static IAccountStateDelta RebondDelegation(
           IAccountStateDelta states,
           Address delegationAddress)
        {
            if (DelegateCtrl.GetDelegation(states, delegationAddress) is { } delegation)
            {
                Address subDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.DelegatorAddress);
                if (GetDelegationMap(states, subDelegationMapAddress) is { } subDelegationMap)
                {
                    subDelegationMap.Delegations.Add(delegationAddress);
                    subDelegationMap.UnbondingDelegations.Remove(delegationAddress);
                    states = states.SetState(
                        subDelegationMap.Address, subDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(subDelegationMapAddress);
                }

                Address objDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.ValidatorAddress);
                if (GetDelegationMap(states, objDelegationMapAddress) is { } objDelegationMap)
                {
                    objDelegationMap.Delegations.Add(delegationAddress);
                    objDelegationMap.UnbondingDelegations.Remove(delegationAddress);
                    states = states.SetState(
                        objDelegationMap.Address, objDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(objDelegationMapAddress);
                }
            }
            else
            {
                throw new NullDelegationException(delegationAddress);
            }

            return states;
        }

        internal static IAccountStateDelta CompleteDelegation(
           IAccountStateDelta states,
           Address delegationAddress)
        {
            if (DelegateCtrl.GetDelegation(states, delegationAddress) is { } delegation)
            {
                Address subDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.DelegatorAddress);
                if (GetDelegationMap(states, subDelegationMapAddress) is { } subDelegationMap)
                {
                    subDelegationMap.UnbondingDelegations.Remove(delegationAddress);
                    states = states.SetState(
                        subDelegationMap.Address, subDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(subDelegationMapAddress);
                }

                Address objDelegationMapAddress = DelegationMap.DeriveAddress(
                    delegation.ValidatorAddress);
                if (GetDelegationMap(states, objDelegationMapAddress) is { } objDelegationMap)
                {
                    objDelegationMap.UnbondingDelegations.Remove(delegationAddress);
                    states = states.SetState(
                        objDelegationMap.Address, objDelegationMap.Serialize());
                }
                else
                {
                    throw new NullDelegationMapException(objDelegationMapAddress);
                }
            }
            else
            {
                throw new NullDelegationException(delegationAddress);
            }

            return states;
        }
    }
}
