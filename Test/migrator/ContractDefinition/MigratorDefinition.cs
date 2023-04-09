using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Test.Contracts.migrator.ContractDefinition
{


    public partial class MigratorDeployment : MigratorDeploymentBase
    {
        public MigratorDeployment() : base(BYTECODE) { }
        public MigratorDeployment(string byteCode) : base(byteCode) { }
    }

    public class MigratorDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50604051610a87380380610a8783398101604081905261002f9161007c565b600480546001600160a01b039384166001600160a01b031991821617909155600580549290931691161790556100af565b80516001600160a01b038116811461007757600080fd5b919050565b6000806040838503121561008f57600080fd5b61009883610060565b91506100a660208401610060565b90509250929050565b6109c9806100be6000396000f3fe608060405234801561001057600080fd5b50600436106100935760003560e01c806382a4b0321161006657806382a4b03214610138578063b4f0d5a61461014b578063cc3d967b1461015e578063d0ebdbe7146101cf578063d5009584146101e257600080fd5b806321513130146100985780633c931e1c146100b65780637adc021c1461011b5780637f91838c14610130575b600080fd5b6100a06101fd565b6040516100ad919061084d565b60405180910390f35b6100c96100c43660046108b6565b61025f565b6040516100ad91908151151581526020808301519082015260408083015190820152606080830151908201526080808301519082015260a0918201516001600160a01b03169181019190915260c00190565b61012e6101293660046108b6565b61030e565b005b6100a06103e8565b61012e6101463660046108d8565b610448565b61012e6101593660046108d8565b610544565b61017161016c3660046108b6565b6105dc565b6040516100ad919081511515815260208083015115159082015260408083015190820152606080830151908201526080808301519082015260a0808301519082015260c0918201516001600160a01b03169181019190915260e00190565b61012e6101dd3660046108b6565b6106a4565b6005546040516001600160a01b0390911681526020016100ad565b6060600080548060200260200160405190810160405280929190818152602001828054801561025557602002820191906000526020600020905b81546001600160a01b03168152600190910190602001808311610237575b5050505050905090565b6102a36040518060c001604052806000151581526020016000815260200160008152602001600081526020016000815260200160006001600160a01b031681525090565b506001600160a01b03908116600090815260036020818152604092839020835160c081018552815460ff16151581526001820154928101929092526002810154938201939093529082015460608201526004820154608082015260059091015490911660a082015290565b60005b60005481101561036d57816001600160a01b03166000828154811061033857610338610921565b6000918252602090912001546001600160a01b03160361035b5761035b81610720565b806103658161094d565b915050610311565b506001600160a01b03166000818152600260209081526040808320805461ff00191661010017905560039091528120805460ff191660019081179091558054808201825591527fb10e2d527612073b26eecdfd717e6a320cf44b4afac2b0732d9fcbe2b7fa0cf60180546001600160a01b0319169091179055565b60606001805480602002602001604051908101604052809291908181526020018280548015610255576020028201919060005260206000209081546001600160a01b03168152600190910190602001808311610237575050505050905090565b6001600160a01b03811660009081526002602052604090205460ff166104f9576001600160a01b0381166000818152600260208190526040822060018082018a90559181018890556003810187905560048101869055805460ff19168217815560050180546001600160a01b03199081168517909155825491820183559180527f290decd9548b62a8d60345a988386fc84ba6bc95484008f6362f93160ef3e563018054909116909117905561053d565b60405162461bcd60e51b8152602060048201526014602482015273155cd95c88185b1c9958591e481cddd85c1c195960621b60448201526064015b60405180910390fd5b5050505050565b6001600160a01b03811660009081526003602052604090205460ff1661059e576001600160a01b0381166000908152600360208190526040909120600181018790556002810186905590810184905560040182905561053d565b60405162461bcd60e51b8152602060048201526013602482015272416c7265616479206d696e746564206e66747360681b6044820152606401610534565b6106296040518060e001604052806000151581526020016000151581526020016000815260200160008152602001600081526020016000815260200160006001600160a01b031681525090565b506001600160a01b03908116600090815260026020818152604092839020835160e081018552815460ff808216151583526101009091041615159281019290925260018101549382019390935290820154606082015260038201546080820152600482015460a082015260059091015490911660c082015290565b6004546001600160a01b031633146106fe5760405162461bcd60e51b815260206004820152601960248201527f4e6f742061757468726f697a65642066726f6d206f776e6572000000000000006044820152606401610534565b600580546001600160a01b0319166001600160a01b0392909216919091179055565b60008054819061073290600190610966565b8154811061074257610742610921565b9060005260206000200160009054906101000a90046001600160a01b031681838154811061077257610772610921565b9060005260206000200160006101000a8154816001600160a01b0302191690836001600160a01b03160217905550808054806107b0576107b061097d565b600082815260208120820160001990810180546001600160a01b031916905590910190915581546107e3919083906107e8565b505050565b8280548282559060005260206000209081019282156108285760005260206000209182015b8281111561082857825482559160010191906001019061080d565b50610834929150610838565b5090565b5b808211156108345760008155600101610839565b6020808252825182820181905260009190848201906040850190845b8181101561088e5783516001600160a01b031683529284019291840191600101610869565b50909695505050505050565b80356001600160a01b03811681146108b157600080fd5b919050565b6000602082840312156108c857600080fd5b6108d18261089a565b9392505050565b600080600080600060a086880312156108f057600080fd5b853594506020860135935060408601359250606086013591506109156080870161089a565b90509295509295909350565b634e487b7160e01b600052603260045260246000fd5b634e487b7160e01b600052601160045260246000fd5b60006001820161095f5761095f610937565b5060010190565b60008282101561097857610978610937565b500390565b634e487b7160e01b600052603160045260246000fdfea264697066735822122087039e0bd3053f431d10605f0bde5d1f2f50fd9cfe13b05c1c702ac02bc7422c64736f6c634300080e0033";
        public MigratorDeploymentBase() : base(BYTECODE) { }
        public MigratorDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "manager", 2)]
        public virtual string Manager { get; set; }
    }

    public partial class AddDetailsFunction : AddDetailsFunctionBase { }

    [Function("AddDetails")]
    public class AddDetailsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "noCities", 1)]
        public virtual BigInteger NoCities { get; set; }
        [Parameter("uint256", "noDistricts", 2)]
        public virtual BigInteger NoDistricts { get; set; }
        [Parameter("uint256", "noMansions", 3)]
        public virtual BigInteger NoMansions { get; set; }
        [Parameter("uint256", "noPlaymates", 4)]
        public virtual BigInteger NoPlaymates { get; set; }
        [Parameter("address", "user", 5)]
        public virtual string User { get; set; }
    }

    public partial class AddRlcDetailsFunction : AddRlcDetailsFunctionBase { }

    [Function("AddRlcDetails")]
    public class AddRlcDetailsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "noRedchain", 1)]
        public virtual BigInteger NoRedchain { get; set; }
        [Parameter("uint256", "noBlackchain", 2)]
        public virtual BigInteger NoBlackchain { get; set; }
        [Parameter("uint256", "noPlatinumchain", 3)]
        public virtual BigInteger NoPlatinumchain { get; set; }
        [Parameter("uint256", "noscarlettoken", 4)]
        public virtual BigInteger Noscarlettoken { get; set; }
        [Parameter("address", "user", 5)]
        public virtual string User { get; set; }
    }

    public partial class ConfirmMintingFunction : ConfirmMintingFunctionBase { }

    [Function("ConfirmMinting")]
    public class ConfirmMintingFunctionBase : FunctionMessage
    {
        [Parameter("address", "user", 1)]
        public virtual string User { get; set; }
    }

    public partial class GetMintedUsersListFunction : GetMintedUsersListFunctionBase { }

    [Function("GetMintedUsersList", "address[]")]
    public class GetMintedUsersListFunctionBase : FunctionMessage
    {

    }

    public partial class GetUsersListFunction : GetUsersListFunctionBase { }

    [Function("GetUsersList", "address[]")]
    public class GetUsersListFunctionBase : FunctionMessage
    {

    }

    public partial class GetManagerFunction : GetManagerFunctionBase { }

    [Function("getManager", "address")]
    public class GetManagerFunctionBase : FunctionMessage
    {

    }

    public partial class GetUserDetailsFunction : GetUserDetailsFunctionBase { }

    [Function("getUserDetails", typeof(GetUserDetailsOutputDTO))]
    public class GetUserDetailsFunctionBase : FunctionMessage
    {
        [Parameter("address", "user", 1)]
        public virtual string User { get; set; }
    }

    public partial class GetUserRlcDetailsFunction : GetUserRlcDetailsFunctionBase { }

    [Function("getUserRlcDetails", typeof(GetUserRlcDetailsOutputDTO))]
    public class GetUserRlcDetailsFunctionBase : FunctionMessage
    {
        [Parameter("address", "user", 1)]
        public virtual string User { get; set; }
    }

    public partial class SetManagerFunction : SetManagerFunctionBase { }

    [Function("setManager")]
    public class SetManagerFunctionBase : FunctionMessage
    {
        [Parameter("address", "manager", 1)]
        public virtual string Manager { get; set; }
    }







    public partial class GetMintedUsersListOutputDTO : GetMintedUsersListOutputDTOBase { }

    [FunctionOutput]
    public class GetMintedUsersListOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetUsersListOutputDTO : GetUsersListOutputDTOBase { }

    [FunctionOutput]
    public class GetUsersListOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetManagerOutputDTO : GetManagerOutputDTOBase { }

    [FunctionOutput]
    public class GetManagerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "manager", 1)]
        public virtual string Manager { get; set; }
    }

    public partial class GetUserDetailsOutputDTO : GetUserDetailsOutputDTOBase { }

    [FunctionOutput]
    public class GetUserDetailsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Strdetails ReturnValue1 { get; set; }
    }

    public partial class GetUserRlcDetailsOutputDTO : GetUserRlcDetailsOutputDTOBase { }

    [FunctionOutput]
    public class GetUserRlcDetailsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual RlcDetails ReturnValue1 { get; set; }
    }


}
