using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Test.Contracts.migrator.ContractDefinition;

namespace Test.Contracts.migrator
{
    public partial class MigratorService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MigratorDeployment migratorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MigratorDeployment>().SendRequestAndWaitForReceiptAsync(migratorDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MigratorDeployment migratorDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MigratorDeployment>().SendRequestAsync(migratorDeployment);
        }

        public static async Task<MigratorService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MigratorDeployment migratorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, migratorDeployment, cancellationTokenSource);
            return new MigratorService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MigratorService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddDetailsRequestAsync(AddDetailsFunction addDetailsFunction)
        {
             return ContractHandler.SendRequestAsync(addDetailsFunction);
        }

        public Task<TransactionReceipt> AddDetailsRequestAndWaitForReceiptAsync(AddDetailsFunction addDetailsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDetailsFunction, cancellationToken);
        }

        public Task<string> AddDetailsRequestAsync(BigInteger noCities, BigInteger noDistricts, BigInteger noMansions, BigInteger noPlaymates, string user)
        {
            var addDetailsFunction = new AddDetailsFunction();
                addDetailsFunction.NoCities = noCities;
                addDetailsFunction.NoDistricts = noDistricts;
                addDetailsFunction.NoMansions = noMansions;
                addDetailsFunction.NoPlaymates = noPlaymates;
                addDetailsFunction.User = user;
            
             return ContractHandler.SendRequestAsync(addDetailsFunction);
        }

        public Task<TransactionReceipt> AddDetailsRequestAndWaitForReceiptAsync(BigInteger noCities, BigInteger noDistricts, BigInteger noMansions, BigInteger noPlaymates, string user, CancellationTokenSource cancellationToken = null)
        {
            var addDetailsFunction = new AddDetailsFunction();
                addDetailsFunction.NoCities = noCities;
                addDetailsFunction.NoDistricts = noDistricts;
                addDetailsFunction.NoMansions = noMansions;
                addDetailsFunction.NoPlaymates = noPlaymates;
                addDetailsFunction.User = user;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDetailsFunction, cancellationToken);
        }

        public Task<string> AddRlcDetailsRequestAsync(AddRlcDetailsFunction addRlcDetailsFunction)
        {
             return ContractHandler.SendRequestAsync(addRlcDetailsFunction);
        }

        public Task<TransactionReceipt> AddRlcDetailsRequestAndWaitForReceiptAsync(AddRlcDetailsFunction addRlcDetailsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRlcDetailsFunction, cancellationToken);
        }

        public Task<string> AddRlcDetailsRequestAsync(BigInteger noRedchain, BigInteger noBlackchain, BigInteger noPlatinumchain, BigInteger noscarlettoken, string user)
        {
            var addRlcDetailsFunction = new AddRlcDetailsFunction();
                addRlcDetailsFunction.NoRedchain = noRedchain;
                addRlcDetailsFunction.NoBlackchain = noBlackchain;
                addRlcDetailsFunction.NoPlatinumchain = noPlatinumchain;
                addRlcDetailsFunction.Noscarlettoken = noscarlettoken;
                addRlcDetailsFunction.User = user;
            
             return ContractHandler.SendRequestAsync(addRlcDetailsFunction);
        }

        public Task<TransactionReceipt> AddRlcDetailsRequestAndWaitForReceiptAsync(BigInteger noRedchain, BigInteger noBlackchain, BigInteger noPlatinumchain, BigInteger noscarlettoken, string user, CancellationTokenSource cancellationToken = null)
        {
            var addRlcDetailsFunction = new AddRlcDetailsFunction();
                addRlcDetailsFunction.NoRedchain = noRedchain;
                addRlcDetailsFunction.NoBlackchain = noBlackchain;
                addRlcDetailsFunction.NoPlatinumchain = noPlatinumchain;
                addRlcDetailsFunction.Noscarlettoken = noscarlettoken;
                addRlcDetailsFunction.User = user;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRlcDetailsFunction, cancellationToken);
        }

        public Task<string> ConfirmMintingRequestAsync(ConfirmMintingFunction confirmMintingFunction)
        {
             return ContractHandler.SendRequestAsync(confirmMintingFunction);
        }

        public Task<TransactionReceipt> ConfirmMintingRequestAndWaitForReceiptAsync(ConfirmMintingFunction confirmMintingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmMintingFunction, cancellationToken);
        }

        public Task<string> ConfirmMintingRequestAsync(string user)
        {
            var confirmMintingFunction = new ConfirmMintingFunction();
                confirmMintingFunction.User = user;
            
             return ContractHandler.SendRequestAsync(confirmMintingFunction);
        }

        public Task<TransactionReceipt> ConfirmMintingRequestAndWaitForReceiptAsync(string user, CancellationTokenSource cancellationToken = null)
        {
            var confirmMintingFunction = new ConfirmMintingFunction();
                confirmMintingFunction.User = user;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmMintingFunction, cancellationToken);
        }

        public Task<List<string>> GetMintedUsersListQueryAsync(GetMintedUsersListFunction getMintedUsersListFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMintedUsersListFunction, List<string>>(getMintedUsersListFunction, blockParameter);
        }

        
        public Task<List<string>> GetMintedUsersListQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMintedUsersListFunction, List<string>>(null, blockParameter);
        }

        public Task<List<string>> GetUsersListQueryAsync(GetUsersListFunction getUsersListFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetUsersListFunction, List<string>>(getUsersListFunction, blockParameter);
        }

        
        public Task<List<string>> GetUsersListQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetUsersListFunction, List<string>>(null, blockParameter);
        }

        public Task<string> GetManagerQueryAsync(GetManagerFunction getManagerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetManagerFunction, string>(getManagerFunction, blockParameter);
        }

        
        public Task<string> GetManagerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetManagerFunction, string>(null, blockParameter);
        }

        public Task<GetUserDetailsOutputDTO> GetUserDetailsQueryAsync(GetUserDetailsFunction getUserDetailsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetUserDetailsFunction, GetUserDetailsOutputDTO>(getUserDetailsFunction, blockParameter);
        }

        public Task<GetUserDetailsOutputDTO> GetUserDetailsQueryAsync(string user, BlockParameter blockParameter = null)
        {
            var getUserDetailsFunction = new GetUserDetailsFunction();
                getUserDetailsFunction.User = user;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetUserDetailsFunction, GetUserDetailsOutputDTO>(getUserDetailsFunction, blockParameter);
        }

        public Task<GetUserRlcDetailsOutputDTO> GetUserRlcDetailsQueryAsync(GetUserRlcDetailsFunction getUserRlcDetailsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetUserRlcDetailsFunction, GetUserRlcDetailsOutputDTO>(getUserRlcDetailsFunction, blockParameter);
        }

        public Task<GetUserRlcDetailsOutputDTO> GetUserRlcDetailsQueryAsync(string user, BlockParameter blockParameter = null)
        {
            var getUserRlcDetailsFunction = new GetUserRlcDetailsFunction();
                getUserRlcDetailsFunction.User = user;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetUserRlcDetailsFunction, GetUserRlcDetailsOutputDTO>(getUserRlcDetailsFunction, blockParameter);
        }

        public Task<string> SetManagerRequestAsync(SetManagerFunction setManagerFunction)
        {
             return ContractHandler.SendRequestAsync(setManagerFunction);
        }

        public Task<TransactionReceipt> SetManagerRequestAndWaitForReceiptAsync(SetManagerFunction setManagerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setManagerFunction, cancellationToken);
        }

        public Task<string> SetManagerRequestAsync(string manager)
        {
            var setManagerFunction = new SetManagerFunction();
                setManagerFunction.Manager = manager;
            
             return ContractHandler.SendRequestAsync(setManagerFunction);
        }

        public Task<TransactionReceipt> SetManagerRequestAndWaitForReceiptAsync(string manager, CancellationTokenSource cancellationToken = null)
        {
            var setManagerFunction = new SetManagerFunction();
                setManagerFunction.Manager = manager;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setManagerFunction, cancellationToken);
        }
    }
}
