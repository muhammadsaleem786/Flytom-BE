using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Unit
{
    public interface IServiceUnit
    {
        IEmailServices Email { get; }
        ITokenService Token { get; }       
        IAccountService Account { get; }
        IMakeService Makes { get; }
        IVehicleModelService VehicleModels { get; }
        IVehicleService Vehicle { get; }
        ICategoryService Category { get; }
        IDropDownMfService DropDownMf { get; }
        IDropDownValueService DropDownValue { get; }
        IOfferService Offer { get; }
    }
}
