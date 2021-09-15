using System;
using Bencodex.Types;
using Libplanet.Blockchain;
using Libplanet.Blockchain.Policies;
using Libplanet.Blocks;
using Libplanet.Store;
using Libplanet.Store.Trie;
using Libplanet.Tests.Common.Action;
using Libplanet.Tests.Store.Trie;
using Xunit;

namespace Libplanet.Tests.Blockchain
{
    public partial class BlockChainTest
    {
        [Fact]
        public void ValidateNextBlock()
        {
            Block<DumbAction> validNextBlock = new BlockContent<DumbAction>
            {
                Index = 1,
                Difficulty = 1024,
                TotalDifficulty = _fx.GenesisBlock.TotalDifficulty + 1024,
                Miner = _fx.GenesisBlock.Miner,
                PreviousHash = _fx.GenesisBlock.Hash,
                Timestamp = _fx.GenesisBlock.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
            }.Mine(_fx.GetHashAlgorithm(1)).Evaluate(_blockChain);
            _blockChain.Append(validNextBlock);
            Assert.Equal(_blockChain.Tip, validNextBlock);
        }

        [Fact]
        private void ValidateNextBlockProtocolVersion()
        {
            Block<DumbAction> block1 = new BlockContent<DumbAction>
            {
                Index = 1,
                Difficulty = 1024,
                TotalDifficulty = _fx.GenesisBlock.TotalDifficulty + 1024,
                Miner = _fx.GenesisBlock.Miner,
                PreviousHash = _fx.GenesisBlock.Hash,
                Timestamp = _fx.GenesisBlock.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
                ProtocolVersion = 1,
            }.Mine(_fx.GetHashAlgorithm(1)).Evaluate(_blockChain);
            _blockChain.Append(block1);

            Block<DumbAction> block2 = new BlockContent<DumbAction>
            {
                Index = 2,
                Difficulty = 1024,
                TotalDifficulty = block1.TotalDifficulty + 1024,
                Miner = _fx.GenesisBlock.Miner,
                PreviousHash = block1.Hash,
                Timestamp = _fx.GenesisBlock.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
                ProtocolVersion = 0,
            }.Mine(_fx.GetHashAlgorithm(2)).Evaluate(_blockChain);
            Assert.Throws<InvalidBlockProtocolVersionException>(() => _blockChain.Append(block2));

            Assert.Throws<InvalidBlockProtocolVersionException>(() =>
            {
                Block<DumbAction> block3 = new BlockContent<DumbAction>
                {
                    Index = 2,
                    Difficulty = 1024,
                    TotalDifficulty = block1.TotalDifficulty + 1024,
                    Miner = _fx.GenesisBlock.Miner,
                    PreviousHash = block1.Hash,
                    Timestamp = _fx.GenesisBlock.Timestamp.AddDays(1),
                    Transactions = _emptyTransaction,
                    ProtocolVersion = BlockMetadata.CurrentProtocolVersion + 1,
                }.Mine(_fx.GetHashAlgorithm(2)).Evaluate(_blockChain);
                _blockChain.Append(block3);
            });
        }

        [Fact]
        private void ValidateNextBlockInvalidIndex()
        {
            _blockChain.Append(_validNext);

            Block<DumbAction> prev = _blockChain.Tip;
            Block<DumbAction> blockWithAlreadyUsedIndex = new BlockContent<DumbAction>
            {
                Index = prev.Index,
                Difficulty = 1,
                TotalDifficulty = 1 + prev.TotalDifficulty,
                Miner = prev.Miner,
                PreviousHash = prev.Hash,
                Timestamp = prev.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
            }.Mine(_fx.GetHashAlgorithm(prev.Index)).Evaluate(_blockChain);
            Assert.Throws<InvalidBlockIndexException>(
                () => _blockChain.Append(blockWithAlreadyUsedIndex)
            );

            Block<DumbAction> blockWithIndexAfterNonexistentIndex = new BlockContent<DumbAction>
            {
                Index = prev.Index + 2,
                Difficulty = 1,
                TotalDifficulty = 1 + prev.TotalDifficulty,
                Miner = prev.Miner,
                PreviousHash = prev.Hash,
                Timestamp = prev.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
            }.Mine(_fx.GetHashAlgorithm(prev.Index + 2)).Evaluate(_blockChain);
            Assert.Throws<InvalidBlockIndexException>(
                () => _blockChain.Append(blockWithIndexAfterNonexistentIndex)
            );
        }

        [Fact]
        private void ValidateNextBlockInvalidDifficulty()
        {
            _blockChain.Append(_validNext);

            Block<DumbAction> invalidDifficultyBlock = new BlockContent<DumbAction>
            {
                Index = 2,
                Difficulty = 1,
                TotalDifficulty = _validNext.TotalDifficulty,
                Miner = _fx.GenesisBlock.Miner,
                PreviousHash = _validNext.Hash,
                Timestamp = _validNext.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
            }.Mine(_fx.GetHashAlgorithm(2)).Evaluate(_blockChain);
            Assert.Throws<InvalidBlockDifficultyException>(() =>
                    _blockChain.Append(invalidDifficultyBlock));
        }

        [Fact]
        private void ValidateNextBlockInvalidTotalDifficulty()
        {
            _blockChain.Append(_validNext);

            long difficulty = _policy.GetNextBlockDifficulty(_blockChain);
            Block<DumbAction> invalidTotalDifficultyBlock = new BlockContent<DumbAction>
            {
                Index = 2,
                Difficulty = difficulty,
                TotalDifficulty = _validNext.TotalDifficulty + difficulty - 1,
                Miner = _fx.GenesisBlock.Miner,
                PreviousHash = _validNext.Hash,
                Timestamp = _validNext.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
            }.Mine(_fx.GetHashAlgorithm(2)).Evaluate(_blockChain);
            Assert.Throws<InvalidBlockTotalDifficultyException>(() =>
                    _blockChain.Append(invalidTotalDifficultyBlock));
        }

        [Fact]
        private void ValidateNextBlockInvalidPreviousHash()
        {
            _blockChain.Append(_validNext);

            long difficulty = _policy.GetNextBlockDifficulty(_blockChain);
            Block<DumbAction> invalidPreviousHashBlock = new BlockContent<DumbAction>
            {
                Index = 2,
                Difficulty = difficulty,
                TotalDifficulty = _validNext.TotalDifficulty + difficulty,
                Miner = _fx.GenesisBlock.Miner,
                // Wrong PreviousHash for test; it should be _validNext.Hash:
                PreviousHash = _validNext.PreviousHash,
                Timestamp = _validNext.Timestamp.AddDays(1),
                Transactions = _emptyTransaction,
            }.Mine(_fx.GetHashAlgorithm(2)).Evaluate(_blockChain);
            Assert.Throws<InvalidBlockPreviousHashException>(() =>
                    _blockChain.Append(invalidPreviousHashBlock));
        }

        [Fact]
        private void ValidateNextBlockInvalidTimestamp()
        {
            _blockChain.Append(_validNext);

            long difficulty = _policy.GetNextBlockDifficulty(_blockChain);
            Block<DumbAction> invalidPreviousTimestamp = new BlockContent<DumbAction>
            {
                Index = 2,
                Difficulty = difficulty,
                TotalDifficulty = _validNext.TotalDifficulty + difficulty,
                Miner = _fx.GenesisBlock.Miner,
                PreviousHash = _validNext.Hash,
                Timestamp = _validNext.Timestamp.AddSeconds(-1),
                Transactions = _emptyTransaction,
            }.Mine(_fx.GetHashAlgorithm(2)).Evaluate(_blockChain);
            Assert.Throws<InvalidBlockTimestampException>(() =>
                    _blockChain.Append(invalidPreviousTimestamp));
        }

        [Fact]
        private void ValidateNextBlockInvalidStateRootHash()
        {
            IKeyValueStore stateKeyValueStore = new MemoryKeyValueStore();
            var policy = new BlockPolicy<DumbAction>(
                blockInterval: TimeSpan.FromMilliseconds(3 * 60 * 60 * 1000)
            );
            var stateStore = new TrieStateStore(stateKeyValueStore);
            var store = new DefaultStore(null);
            var genesisBlock = TestUtils.MineGenesis<DumbAction>(policy.GetHashAlgorithm)
                .Evaluate(policy.BlockAction, stateStore);
            store.PutBlock(genesisBlock);
            Assert.NotNull(store.GetStateRootHash(genesisBlock.Hash));

            var chain1 = new BlockChain<DumbAction>(
                policy,
                new VolatileStagePolicy<DumbAction>(),
                store,
                stateStore,
                genesisBlock
            );

            Block<DumbAction> block1 = new BlockContent<DumbAction>
            {
                Index = 1,
                Difficulty = 1024L,
                TotalDifficulty = genesisBlock.TotalDifficulty + 1024,
                Miner = genesisBlock.Miner,
                PreviousHash = genesisBlock.Hash,
                Timestamp = genesisBlock.Timestamp.AddSeconds(1),
                Transactions = _emptyTransaction,
            }.Mine(policy.GetHashAlgorithm(1)).Evaluate(chain1);

            var policyWithBlockAction = new BlockPolicy<DumbAction>(
                new SetStatesAtBlock(default, (Text)"foo", 1),
                policy.BlockInterval
            );
            var chain2 = new BlockChain<DumbAction>(
                policyWithBlockAction,
                new VolatileStagePolicy<DumbAction>(),
                store,
                stateStore,
                genesisBlock
            );
            Assert.Throws<InvalidBlockStateRootHashException>(() => chain2.Append(block1));
        }
    }
}
