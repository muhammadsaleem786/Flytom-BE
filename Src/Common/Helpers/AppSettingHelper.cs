using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Numerics;

namespace Common.Helpers
{
    public static class AppSettingHelper
    {

        private static string GetSettingValue(string parentKey, string childKey)
        {
            try
            {
                IConfigurationRoot configuration = GetSettingConfiguration();

                if (!configuration.GetSection(parentKey).Exists())
                {
                    throw new Exception(MessageHelper.AppSettingMissing(parentKey));
                }

                if (!configuration.GetSection(parentKey).GetSection(childKey).Exists())
                {
                    throw new Exception(MessageHelper.AppSettingMissing(childKey));
                }

                return configuration.GetSection(parentKey).GetSection(childKey).Value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        private static IConfigurationRoot GetSettingConfiguration()
        {
            try
            {
                return new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
                            .Build();

                //return new ConfigurationBuilder()
                //            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //            .AddJsonFile($"appsettings.json")
                //            .Build();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }


        // Parent Section
        public const string Portal = "Portal";

        public const string CustomSettings = "Custom_Settings";

        // Child Section
        public const string JwtTokenSecret = "Jwt_Token_Secret";

        public const string JwtValueSecret = "Jwt_Value_Secret";

        public const string ApiToken = "Api_Token";

        public const string PasswordSalt = "Password_Salt";

        public const string PasswordSecret = "Password_Secret";

        public const string EnableSignature = "Enable_Signature";

        public const string EnableSwagger = "Enable_Swagger";

        public const string EnableSeeder = "Enable_Seeder";

        // Smtp Settings
        public static string GetSmtpServerName() => GetSettingValue("Smtp", "ServerName");
        public static int GetSmtpServerPort() => int.Parse(GetSettingValue("Smtp", "ServerPort"));
        public static string GetSmtpEmailAddress() => GetSettingValue("Smtp", "EmailAddress");
        public static string GetSmtpEmailPassword() => GetSettingValue("Smtp", "EmailPassword");
        public static string GetSmtpEmailFrom() => GetSettingValue("Smtp", "EmailFrom");      

        public static string GetConfirmEmailCallback => GetSettingValue("Links", "ConfirmEmailCallback");
        public static string GetForgotEmailCallback => GetSettingValue("Links", "ForgotEmailCallback");
        public static string GetFractalClientId => GetSettingValue("Fractal", "client_id");
        public static string GetFractalClientSecret => GetSettingValue("Fractal", "client_secret");
        public static string GetFractalRedirectUri => GetSettingValue("Fractal", "redirect_uri");
        public static string GetMasterKey => GetSettingValue("MasterKey", "key");


        public static bool GetEnableSeeder()
        {
            return bool.Parse(GetSettingValue(CustomSettings, EnableSeeder));
        }

        public static bool GetEnableSwagger()
        {
            return bool.Parse(GetSettingValue(CustomSettings, EnableSwagger));
        }

        public static bool GetEnableSignature()
        {
            return bool.Parse(GetSettingValue(CustomSettings, EnableSignature));
        }

        public static string GetJwtTokenSecret()
        {
            return GetSettingValue(CustomSettings, JwtTokenSecret);
        }

        public static string GetJwtValueSecret()
        {
            return GetSettingValue(CustomSettings, JwtValueSecret);
        }

        public static string GetApiToken()
        {
            return GetSettingValue(CustomSettings, ApiToken);
        }

        public static string GetPasswordSalt()
        {
            return GetSettingValue(CustomSettings, PasswordSalt);
        }

        public static string GetPasswordSecret()
        {
            return GetSettingValue(CustomSettings, PasswordSecret);
        }

        public static string GetDefaultConnection()
        {
            return GetSettingValue("ConnectionStrings", "DefaultConnection");
        }

        public static string GetNFTContractAddress()
        {
            return GetSettingValue("NFT", "NFTContractAddress");
        }

        public static string GetNFTOwnerPrivateKey()
        {
            return GetSettingValue("NFT", "OwnerPrivateKey");
        }


        public static string GetTwilioAccountSid()
        {
            return GetSettingValue("Twilio", "AccountSid");
        }
        public static string GetTwilioToken()
        {
            return GetSettingValue("Twilio", "AuthToken");
        }
        public static string GetTwilioNumber()
        {
            return GetSettingValue("Twilio", "FromNo");
        }
        public static string GetTwilioToNumber()
        {
            return GetSettingValue("Twilio", "ToNo");
        }
        public static string GetNFTTokenBaseUrl()
        {
            return GetSettingValue("NFT", "TokenBaseUrl");
        }

        public static string GetNFTTokenFilesPath()
        {
            return GetSettingValue("NFT", "TokenFilesPath");
        }
        public static string GetPaymentBaseUrl()
        {
            return GetSettingValue("PaymentGateway", "Url");
        }

        public static string GetGasTrakerApiUrl()
        {
            return GetSettingValue("Eth", "GasTrakerApiUrl");
        }
        public static string GetWalletPassword()
        {
            return GetSettingValue("Eth", "WalletPassword");
        }
        public static string GetCoinMarketCapApi()
        {
            return GetSettingValue("CoinMarketCap", "ApiKey");
        }
        public static int GetRateManagementDelayTime()
        {
            return int.Parse(GetSettingValue("RateManagement", "DelayTimeInMinute"));
        }

        public static string GetBscClientNodeUrl()
        {
            return GetSettingValue("BSC", "ClientNodeUrl");
        }
        public static string GetStripeAPIKey()
        {
            return GetSettingValue("StripeKey", "APIKey");
        }
        public static string GetDistributorAddress()
        {
            return GetSettingValue("DistributorAddress", "Address");
        }
        public static int GetBscChainId()
        {
            return int.Parse(GetSettingValue("BSC", "ChainId"));
        }

        //public static string GetPolygonClientNodeUrl()
        //{
        //    return GetSettingValue("BSC", "ClientNodeUrl");
        //}

        //public static int GetPolygonChainId()
        //{
        //    return int.Parse(GetSettingValue("BSC", "ChainId"));
        //}

        public static string GetEthClientNodeUrl()
        {
            return GetSettingValue("Eth", "EthClientNodeUrl");
        }

        public static int GetEthChainId()
        {
            return int.Parse(GetSettingValue("Eth", "EthChainId"));
        }

        public static int GetBridgeRlcManagementDelayTimeInSeconds()
        {
            return int.Parse(GetSettingValue("BridgeRlcManagement", "DelayTimeInSeconds"));
        }
        public static BigInteger GetETHandBSCGasPrice()
        {
            return BigInteger.Parse(GetSettingValue("LockingAmount", "GasPrice"));
        }
        public static BigInteger GetETHandBSCGasLimit()
        {
            return BigInteger.Parse(GetSettingValue("LockingAmount", "GasLimit"));
        }
        public static BigInteger GetBSCGasPrice()
        {
            return BigInteger.Parse(GetSettingValue("LockingAmount", "BSCGasPrice"));
        }
        public static BigInteger GetBSCGasLimit()
        {
            return BigInteger.Parse(GetSettingValue("LockingAmount", "BSCGasLimit"));
        }
        public static BigInteger GetETHGasPriceTransactions()
        {
            return BigInteger.Parse(GetSettingValue("Transactions", "GasPrice"));
        }
        public static BigInteger GetETHGasLimitTransactions()
        {
            return BigInteger.Parse(GetSettingValue("Transactions", "GasLimit"));
        }
        public static BigInteger GetBSCGasPriceTransactions()
        {
            return BigInteger.Parse(GetSettingValue("Transactions", "BSCGasPrice"));
        }
        public static BigInteger GetBSCGasLimitTransactions()
        {
            return BigInteger.Parse(GetSettingValue("Transactions", "BSCGasLimit"));
        }
    }
}