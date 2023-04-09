using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Test.Contracts.migrator.ContractDefinition
{
    public partial class Strdetails : StrdetailsBase { }

    public class StrdetailsBase 
    {
        [Parameter("bool", "check", 1)]
        public virtual bool Check { get; set; }
        [Parameter("bool", "isMinted", 2)]
        public virtual bool IsMinted { get; set; }
        [Parameter("uint256", "noOfCities", 3)]
        public virtual BigInteger NoOfCities { get; set; }
        [Parameter("uint256", "noOfDistricts", 4)]
        public virtual BigInteger NoOfDistricts { get; set; }
        [Parameter("uint256", "noOfMansions", 5)]
        public virtual BigInteger NoOfMansions { get; set; }
        [Parameter("uint256", "noOfPlaymates", 6)]
        public virtual BigInteger NoOfPlaymates { get; set; }
        [Parameter("address", "user", 7)]
        public virtual string User { get; set; }
    }
}
