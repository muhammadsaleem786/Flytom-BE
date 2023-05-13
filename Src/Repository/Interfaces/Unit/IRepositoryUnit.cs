using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Unit
{
    public interface IRepositoryUnit
    {
        IAppSettingsRepository AppSettings { get; }
        IAuthTokenRepository AuthToken { get; }
        IAccountRepository Account { get; }
        IMakeRepository Makes { get; }
        IVehicleModelsRepository VehicleModels { get; }
        IVehicleRepository Vehicle { get; }
        ICategoryRepository Category { get; }
        IDropDownMfRepository DropDownMf { get; }
        IDropDownValueRepository DropDownValue { get; }
        IOfferRepository Offer { get; }
        IVehicleImageRepository VehicleImage { get; }
        IVehiclePartRepository VehiclePart { get; }
        IContentManagmentRepository ContentManagment { get; }
        IBannerDetailRepository BannerDetail { get; }
        IDeliveryRepository Delivery { get; }
        IContactRepository Contact { get; }
        void DetachAllEntities();

        void Save();

        Task SaveAsync();

        void BeginTransaction();

        void CommitTransaction();

        void RollBackTransaction();

        Task BeginTransactionAsync();
    }
}
