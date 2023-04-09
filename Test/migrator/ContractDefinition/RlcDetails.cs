using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Test.Contracts.migrator.ContractDefinition
{
    public partial class RlcDetails : RlcDetailsBase { }

    public class RlcDetailsBase 
    {
        [Parameter("bool", "isMinted", 1)]
        public virtual bool IsMinted { get; set; }
        [Parameter("uint256", "noofRedchain", 2)]
        public virtual BigInteger NoofRedchain { get; set; }
        [Parameter("uint256", "noOfBlackchain", 3)]
        public virtual BigInteger NoOfBlackchain { get; set; }
        [Parameter("uint256", "noOfPlatinumchain", 4)]
        public virtual BigInteger NoOfPlatinumchain { get; set; }
        [Parameter("uint256", "noOfScarletToken", 5)]
        public virtual BigInteger NoOfScarletToken { get; set; }
        [Parameter("address", "user", 6)]
        public virtual string User { get; set; }
    }
}
