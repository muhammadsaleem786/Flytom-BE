﻿using DTO.Enums;
using System;

namespace DTO.ViewModel.Token
{
    public class JwtTokenModel
    {
        #region Private Fields

        #endregion


        #region Private Methods

        private DateTime FromUnixTime(long unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(unixTime);
        }

        #endregion


        #region Constructors

        public JwtTokenModel() { }

        public JwtTokenModel(long id)
        {
            Id = id;
        }

        public JwtTokenModel(long id, long issuedAt,
            long expiresAt, long notValidBefore, AccountType type)
        {
            Id = id;
            IssuedAtEpoch = issuedAt;
            IssuedAt = FromUnixTime(IssuedAtEpoch);
            ExpiresAtEpoch = expiresAt;
            ExpiresAt = FromUnixTime(expiresAt);
            NotValidBeforeEpoch = notValidBefore;
            NotValidBefore = FromUnixTime(notValidBefore);
            Type = type;
        }

        #endregion


        #region Properties

        public long Id { get; set; }

        public long IssuedAtEpoch { get; set; }

        public DateTime IssuedAt { get; set; }

        public long ExpiresAtEpoch { get; set; }

        public DateTime ExpiresAt { get; set; }

        public long NotValidBeforeEpoch { get; set; }

        public DateTime NotValidBefore { get; set; }

        public AccountType Type { get; set; }

        #endregion


        #region Fields

        #endregion


        #region Methods

        #endregion
    }

    public static class TokenClaimKeys
    {
        #region Private Fields

        #endregion


        #region Private Methods

        #endregion


        #region Constructors

        #endregion


        #region Properties

        #endregion


        #region Fields

        public const string Type = "x-type";

        public const string Value = "x-value";

        public const string IssuedAt = "iat";

        public const string ExpiresAt = "exp";

        public const string NotValidBefore = "nbf";

        #endregion


        #region Methods

        #endregion
    }
}
