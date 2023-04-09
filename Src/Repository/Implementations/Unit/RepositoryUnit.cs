using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Repository.Interfaces;
using Repository.Implementations;
using Repository.Interfaces.Unit;

namespace Repository.Implementations.Unit
{
    internal class RepositoryUnit : IRepositoryUnit
    {
        private readonly FlyttomContext _db;
        private IAppSettingsRepository _appSettings;
        private IAuthTokenRepository _authToken;
        private IAccountRepository _account;

        private IMakeRepository _make;
        private IVehicleModelsRepository _VehicleModels;
        private IVehicleRepository _vehicle;
        private ICategoryRepository _category;
        private IDropDownMfRepository _DropDownMf;
        private IDropDownValueRepository _DropDownValue;
        private IOfferRepository _Offer;
        private IVehicleImageRepository _VehicleImage;
        private IVehiclePartRepository _vehiclePart;
        public RepositoryUnit(FlyttomContext db)
        {
            _db = db;
        }
        public IVehiclePartRepository VehiclePart =>
       _vehiclePart ??= new VehiclePartRepository(_db);


        public IVehicleImageRepository VehicleImage =>
         _VehicleImage ??= new VehicleImageRepository(_db);

        public IDropDownMfRepository DropDownMf =>
         _DropDownMf ??= new DropDownMfRepository(_db);
        public IDropDownValueRepository DropDownValue =>
         _DropDownValue ??= new DropDownValueRepository(_db);
        public IOfferRepository Offer =>
         _Offer ??= new OfferRepository(_db);

        public ICategoryRepository Category =>
           _category ??= new CategoryRepository(_db);

        public IMakeRepository Makes =>
         _make ??= new MakeRepository(_db);

        public IVehicleModelsRepository VehicleModels =>
           _VehicleModels ??= new VehicleModelsRepository(_db);

        public IVehicleRepository Vehicle =>
           _vehicle ??= new VehicleRepository(_db);

        public IAppSettingsRepository AppSettings =>
            _appSettings ??= new AppSettingsRepository(_db);

        public IAuthTokenRepository AuthToken =>
            _authToken ??= new AuthTokenRepository(_db);


        public IAccountRepository Account =>
            _account ??= new AccountRepository(_db);

       

        public void Save()
        {
            SetCommonValues();
            _db.SaveChanges();
        }

        public void SetCommonValues()
        {
            var AddedEntities = _db.ChangeTracker.Entries()
        .Where(E => E.State == EntityState.Added)
        .ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedAt").CurrentValue = E.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            });

            var EditedEntities = _db.ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
            });
        }

        public async Task SaveAsync()
        {
            SetCommonValues();
            await _db.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _db.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _db.Database.RollbackTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await _db.Database.BeginTransactionAsync();
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = _db.ChangeTracker.Entries()
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
