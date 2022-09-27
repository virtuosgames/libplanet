using System.Collections.Generic;
using System.Collections.Immutable;
using Libplanet.Action;
using Libplanet.Assets;
using Libplanet.Crypto;
using Libplanet.PoS;
using Libplanet.PoS.Control;
using Libplanet.PoS.Model;
using Xunit;

namespace Libplanet.Tests.PoS
{
    public class DelegationMapCtrlTest : PoSTest
    {
        private readonly PublicKey _operatorPublicKey;
        private readonly Address _operatorAddress;
        private readonly Address _delegatorAddress;
        private readonly Address _validatorAddress;
        private readonly Address _initDelegationAddress;
        private readonly Address _delegationAddress;
        private readonly Address _undelegationAddress;
        private ImmutableHashSet<Currency> _nativeTokens;
        private IAccountStateDelta _states;

        public DelegationMapCtrlTest()
        {
            _operatorPublicKey = new PrivateKey().PublicKey;
            _operatorAddress = _operatorPublicKey.ToAddress();
            _delegatorAddress = CreateAddress();
            _validatorAddress = Validator.DeriveAddress(_operatorAddress);
            _initDelegationAddress = Delegation.DeriveAddress(_operatorAddress, _validatorAddress);
            _delegationAddress = Delegation.DeriveAddress(_delegatorAddress, _validatorAddress);
            _undelegationAddress = Undelegation.DeriveAddress(_delegatorAddress, _validatorAddress);
            _nativeTokens = ImmutableHashSet.Create(
                Asset.GovernanceToken, Asset.ConsensusToken, Asset.Share);
            _states = InitializeStates();
        }

        [Theory]
        [InlineData(500, 500, 100, 100, 100)]
        public void CompleteUnbondingTest(
            int operatorMintAmount,
            int delegatorMintAmount,
            int selfDelegateAmount,
            int delegateAmount,
            int undelegateAmount)
        {
            Initialize(operatorMintAmount, delegatorMintAmount, selfDelegateAmount, delegateAmount);
            DelegationMap subDelegationMap;
            DelegationMap objDelegationMap;

            (_, subDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _operatorAddress);
            Assert.Equal(
                new SortedSet<Address>() { _initDelegationAddress },
                subDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>(),
                subDelegationMap.UnbondingDelegations);
            (_, subDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _delegatorAddress);
            Assert.Equal(
                new SortedSet<Address>() { _delegationAddress },
                subDelegationMap.Delegations);
            (_, objDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _validatorAddress);
            Assert.Equal(
                new SortedSet<Address>() { _initDelegationAddress, _delegationAddress },
                objDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>(),
                objDelegationMap.UnbondingDelegations);

            _states = UndelegateCtrl.Execute(
                _states,
                _delegatorAddress,
                _validatorAddress,
                Asset.Share * undelegateAmount,
                _nativeTokens,
                1);

            (_, subDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _operatorAddress);
            Assert.Equal(
                new SortedSet<Address>() { _initDelegationAddress },
                subDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>(),
                subDelegationMap.UnbondingDelegations);
            (_, subDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _delegatorAddress);
            Assert.Equal(
                new SortedSet<Address>(),
                subDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>() { _delegationAddress },
                subDelegationMap.UnbondingDelegations);
            (_, objDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _validatorAddress);
            Assert.Equal(
                new SortedSet<Address>() { _initDelegationAddress },
                objDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>() { _delegationAddress },
                objDelegationMap.UnbondingDelegations);

            _states = UndelegateCtrl.Complete(
                _states,
                _undelegationAddress,
                1000000);

            (_, subDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _operatorAddress);
            Assert.Equal(
                new SortedSet<Address>() { _initDelegationAddress },
                subDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>(),
                subDelegationMap.UnbondingDelegations);
            (_, subDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _delegatorAddress);
            Assert.Equal(
                new SortedSet<Address>(),
                subDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>(),
                subDelegationMap.UnbondingDelegations);
            (_, objDelegationMap) = DelegationMapCtrl.FetchDelegationMap(
                _states, _validatorAddress);
            Assert.Equal(
                new SortedSet<Address>() { _initDelegationAddress },
                objDelegationMap.Delegations);
            Assert.Equal(
                new SortedSet<Address>(),
                objDelegationMap.UnbondingDelegations);
        }

        private void Initialize(
            int operatorMintAmount,
            int delegatorMintAmount,
            int selfDelegateAmount,
            int delegateAmount)
        {
            _states = InitializeStates();
            _states = _states.MintAsset(
                _operatorAddress, Asset.GovernanceToken * operatorMintAmount);
            _states = _states.MintAsset(
                _delegatorAddress, Asset.GovernanceToken * delegatorMintAmount);
            _states = ValidatorCtrl.Create(
                _states,
                _operatorAddress,
                _operatorPublicKey,
                Asset.GovernanceToken * selfDelegateAmount,
                _nativeTokens,
                1);
            _states = DelegateCtrl.Execute(
                _states,
                _delegatorAddress,
                _validatorAddress,
                Asset.GovernanceToken * delegateAmount,
                _nativeTokens,
                1);
        }
    }
}
