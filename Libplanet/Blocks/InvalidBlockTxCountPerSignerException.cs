using System;
using System.Runtime.Serialization;
using Bencodex;
using Libplanet.Blockchain.Policies;
using Libplanet.Serialization;
using Libplanet.Tx;

namespace Libplanet.Blocks
{
    /// <summary>
    /// An exception thrown when the count of <see cref="Block{T}.Transactions"/>
    /// does not follow the constraint provided by <see cref="IBlockPolicy{T}"/>.
    /// </summary>
    [Serializable]
    public sealed class InvalidBlockTxCountPerSignerException : BlockPolicyViolationException
    {
        private static Codec _codec = new Codec();

        /// <summary>
        /// Initializes a new instance of <see cref="InvalidBlockTxCountPerSignerException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="signer">An offending <see cref="Address"/> with too many
        /// <see cref="Transaction{T}"/>'s in a <see cref="Block{T}"/>.</param>
        /// <param name="txCount">The invalid count of <see cref="Block{T}.Transactions"/>
        /// by <paramref name="signer"/> according to the <see cref="IBlockPolicy{T}"/>.</param>
        public InvalidBlockTxCountPerSignerException(string message, Address signer, int txCount)
            : base(message)
        {
            Signer = signer;
            TxCount = txCount;
        }

        private InvalidBlockTxCountPerSignerException(
            SerializationInfo info, StreamingContext context)
            : base(info.GetString(nameof(Message)) ?? string.Empty)
        {
            Signer = new Address(_codec.Decode(info.GetValue<byte[]>(nameof(Signer))));
            TxCount = info.GetInt32(nameof(TxCount));
        }

        public Address Signer { get; private set; }

        public int TxCount { get; private set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(Signer), _codec.Encode(Signer.Bencoded));
            info.AddValue(nameof(TxCount), TxCount);
        }
    }
}
