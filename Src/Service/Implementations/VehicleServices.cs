using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Service.Interfaces;
using Logger.Interfaces;
using Repository.Interfaces.Unit;
using Service.Models;
using Microsoft.EntityFrameworkCore;
using DTO.Models;
using Common.Helpers;
using DTO.ViewModel.Vehicle;
using Microsoft.AspNetCore.Http;
using iTextSharp.text.pdf.codec;

namespace Service.Implementations
{
    internal class VehicleServices : IVehicleService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public VehicleServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(VehicleRequest model, long AccountId)
        {
            try
            {
                if (model.SequreFeetId == 0)
                    model.SequreFeetId = null;

                if (model.Id != 0)
                {
                    var obj = await _repository.Vehicle.GetByIdAsync(model.Id);
                    if (obj == null)
                        return ServiceResults.Errors.NotFound<string>("Vehicle", null);
                    obj.MakesId = model.MakesId;
                    obj.NoOfDoor = model.NoOfDoor;
                    obj.NoOfSeatId = model.NoOfSeatId;
                    obj.CategoryId = model.CategoryId;
                    obj.TankCapacity = model.TankCapacity;
                    obj.VehicleModelsId = model.VehicleModelsId;
                    obj.CarType = model.CarType;
                    obj.Description = model.Description;
                    obj.DriveWheelType = model.DriveWheelType;
                    obj.FuelTypeId = model.FuelTypeId;
                    obj.SteeringTypeId = model.SteeringTypeId;
                    obj.LicenceType = model.LicenceType;
                    obj.Lift = model.Lift;
                    obj.SequreFeetId = model.SequreFeetId;
                    obj.LoadCapacity = model.LoadCapacity;
                    obj.RangeGiven = model.RangeGiven;
                    obj.Height = model.Height;
                    obj.Length = model.Length;
                    obj.Width = model.Width;
                    obj.UpdatedAt = DateTime.UtcNow;
                    obj.Name = model.Name;
                    if (model.VehiclePartRequest.Count > 0)
                    {
                        var VehiclePartObj = _repository.VehiclePart.FindByCondition(a => a.VehicleId == obj.Id).ToList();
                        if (VehiclePartObj.Count > 0)
                        {
                            VehiclePartObj.ForEach(x =>
                            {
                                x.IsDeleted = true; x.DeletedAt = DateTime.UtcNow;
                            });
                            _repository.VehiclePart.UpdateRange(VehiclePartObj);
                        }
                        List<VehiclePart> listFile = new List<VehiclePart>();
                        foreach (var item in model.VehiclePartRequest)
                        {
                            listFile.Add(new VehiclePart()
                            {
                                DropDownId = item.DropDownId,
                                CreatedAt = DateTime.UtcNow,
                                IsChecked = item.IsChecked
                            });
                        }
                        obj.VehiclePart = listFile;
                    }
                    if (model.VehicleImage != null)
                    {
                        var imageList = _repository.VehicleImage.FindByCondition(a => a.VehicleId == obj.Id).ToList();
                        if (imageList.Count > 0)
                        {
                            imageList.ForEach(x =>
                            {
                                x.IsDeleted = true; x.DeletedAt = DateTime.UtcNow;
                            });
                            _repository.VehicleImage.UpdateRange(imageList);
                        }
                        List<VehicleImage> listFile = new List<VehicleImage>();
                        foreach (var item in model.VehicleImage)
                        {
                            listFile.Add(new VehicleImage()
                            {
                                ImageURL = item.Image,
                                CreatedAt = DateTime.UtcNow,
                            });
                        }
                        obj.VehicleImage = listFile;
                    }
                    _repository.Vehicle.Update(obj);
                    await _repository.SaveAsync();
                    return ServiceResults.UpdatedSuccessfully<string>("Vehicle");
                }
                else
                {
                    Vehicle make = new Vehicle()
                    {
                        AccountId = AccountId,
                        MakesId = model.MakesId,
                        NoOfDoor = model.NoOfDoor,
                        CategoryId = model.CategoryId,
                        NoOfSeatId = model.NoOfSeatId,
                        TankCapacity = model.TankCapacity,
                        VehicleModelsId = model.VehicleModelsId,
                        CarType = model.CarType,
                        Description = model.Description,
                        FuelTypeId = model.FuelTypeId,
                        DriveWheelType = model.DriveWheelType,
                        SteeringTypeId = model.SteeringTypeId,
                        LicenceType = model.LicenceType,
                        Lift = model.Lift,
                        SequreFeetId = model.SequreFeetId,
                        LoadCapacity = model.LoadCapacity,
                        RangeGiven = model.RangeGiven,
                        Height = model.Height,
                        Length = model.Length,
                        Width = model.Width,
                        Name=model.Name,
                    };
                    if (model.VehiclePartRequest.Count > 0)
                    {
                        List<VehiclePart> listFile = new List<VehiclePart>();
                        foreach (var item in model.VehiclePartRequest)
                        {
                            listFile.Add(new VehiclePart()
                            {
                                DropDownId = item.DropDownId,
                                CreatedAt = DateTime.UtcNow,
                                IsChecked = item.IsChecked
                            });
                        }
                        make.VehiclePart = listFile;
                    }
                    if (model.VehicleImage != null)
                    {
                        List<VehicleImage> listFile = new List<VehicleImage>();
                        foreach (var item in model.VehicleImage)
                        {

                            listFile.Add(new VehicleImage()
                            {
                                ImageURL = item.Image,
                                CreatedAt = DateTime.UtcNow,
                            });

                        }
                        make.VehicleImage = listFile;
                    }



                    _repository.Vehicle.Create(make);
                    await _repository.SaveAsync();
                    return ServiceResults.AddedSuccessfully<string>("Vehicle");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ServiceResult<List<ImageList>>> UploadImage(List<IFormFile> ImageList)
        {
            try
            {
                List<ImageList> listFile = new List<ImageList>();
                if (ImageList != null)
                {
                    foreach (var item in ImageList)
                    {
                        var file = await fileManagementService.UploadImageFile(item, "Images", new string[] { "image/png", "video/mp4", "image/jpeg", "image/jpg", "image/gif", "image/webp" });
                        if (file.isSuccess)
                        {
                            listFile.Add(new ImageList()
                            {
                                Image = file.response,
                            });
                        }
                    }
                }
                return ServiceResults.AddedSuccessfully<List<ImageList>>(listFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResult<string>> Delete(long id, long AccountId)
        {
            try
            {
                var makeobj = await _repository.Vehicle.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Vehicle", null);
                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.Vehicle.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Vehicle");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<VehicleResponse>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.Vehicle.FindByCondition(a => a.Id == Id)
                    .Include(a => a.VehicleImage).Include(a => a.sys_drop_down_value)
                    .Include(a => a.sys_drop_down_value1).Include(a => a.sys_drop_down_value2)
                    .Include(a => a.sys_drop_down_value3).Include(a => a.sys_drop_down_value4)
                    .Include(a => a.sys_drop_down_value5).Include(a => a.VehiclePart).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<VehicleResponse>("Vehicle", null);

                var result = new VehicleResponse();
                result.Id = makeobj.Id;
                result.Name = makeobj.Name;
                result.AccountId = makeobj.AccountId;
                result.NoOfDoor = makeobj.NoOfDoor;
                result.NoOfSeatId = makeobj.NoOfSeatId;
                result.DriveWheelType = makeobj.DriveWheelType;
                result.TankCapacity = makeobj.TankCapacity;
                result.CarType = makeobj.CarType;
                result.SteeringTypeId = makeobj.SteeringTypeId;
                result.Description = makeobj.Description;
                result.FuelTypeId = makeobj.FuelTypeId;
                result.MakesId = makeobj.MakesId;
                result.VehicleModelsId = makeobj.VehicleModelsId;
                result.CategoryId = makeobj.CategoryId;
                result.SequreFeetId = makeobj.SequreFeetId ?? 0;
                result.Lift = makeobj.Lift;
                result.LoadCapacity = makeobj.LoadCapacity;
                result.LicenceType = makeobj.LicenceType;
                result.RangeGiven = makeobj.RangeGiven ?? 0;
                result.Height = makeobj.Height;
                result.Length = makeobj.Length;
                result.Width = makeobj.Width;
                result.VehicleImage = makeobj.VehicleImage.Where(a => !a.IsDeleted).Select(z => new VehicleImageResponse
                {
                    Id = z.Id,
                    Image = z.ImageURL
                }).ToList();
                result.VehiclePartRequest = makeobj.VehiclePart.Where(a => !a.IsDeleted).Select(z => new VehiclePartRequest
                {
                    Id = z.Id,
                    DropDownId = z.DropDownId,
                    IsChecked = z.IsChecked,
                }).ToList();
                return ServiceResults.GetListSuccessfully(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ServiceResult<VehicleWebResponse>> GetByIdWebSite(int Id, string Type)
        {
            try
            {
                var makeobj = await _repository.Vehicle.FindByCondition(a => a.Id == Id && a.CarType == Type)
                    .Include(a => a.VehicleImage).Include(a => a.sys_drop_down_value)
                    .Include(a => a.sys_drop_down_value1).Include(a => a.sys_drop_down_value2)
                    .Include(a => a.sys_drop_down_value3).Include(a => a.sys_drop_down_value4)
                    .Include(a => a.sys_drop_down_value5).Include(a => a.VehiclePart).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<VehicleWebResponse>("Vehicle", null);

                var result = new VehicleWebResponse();
                result.Name = makeobj.Name;
                result.NoOfDoor = makeobj.NoOfDoor;
                result.TankCapacity = makeobj.TankCapacity;
                result.CarType = makeobj.CarType == "P" ? "Personal Car" : "Vain";
                result.Description = makeobj.Description;
                result.Lift = makeobj.Lift;
                result.LoadCapacity = makeobj.LoadCapacity;
                result.RangeGiven = makeobj.RangeGiven ?? 0;
                result.Height = makeobj.Height;
                result.Length = makeobj.Length;
                result.Width = makeobj.Width;
                result.FuelType = makeobj.sys_drop_down_value.ValueInNorwegian;
                result.WheelType = makeobj.sys_drop_down_value1.ValueInNorwegian;
                result.SteeringType = makeobj.sys_drop_down_value2.ValueInNorwegian;
                result.Licence = makeobj.sys_drop_down_value3.ValueInNorwegian;

                result.VehicleImage = makeobj.VehicleImage.Where(a => !a.IsDeleted).Select(z => new VehicleImageResponse
                {
                    Id = z.Id,
                    Image = z.ImageURL
                }).ToList();
                result.VehiclePartRequest = makeobj.VehiclePart.Where(a => !a.IsDeleted).Select(z => new VehiclePartRequest
                {
                    Id = z.Id,
                    DropDownId = z.DropDownId,
                    IsChecked = z.IsChecked,
                }).ToList();
                return ServiceResults.GetListSuccessfully(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResult<List<VehicleResponseModel>>> GetWebVehicleList(decimal AccountId, int CurrentPageNo, int RecordPerPage,
            string SortOrder, string SearchText, string Type, string SeatNo, string SteeringType, string FuelType, string DriveWheelType)
        {
            try
            {
                var makeobj = _repository.Vehicle.FindAll().Where(a => a.IsDeleted == false && a.CarType == Type).Include(a => a.Makes)
                    .Include(a => a.VehicleImage).Include(a => a.VehiclePart)
                    .Include(a => a.VehicleModels).Include(a => a.sys_drop_down_value)
                    .Include(a => a.sys_drop_down_value1).Include(a => a.sys_drop_down_value2).AsQueryable();
                if (SeatNo != "undefined" && SeatNo != null)
                {
                    makeobj = makeobj.Where(x => x.NoOfSeatId.ToString().Contains(SeatNo));
                }

                if (SteeringType != "undefined" && SteeringType != null)
                {
                    makeobj = makeobj.Where(x => x.SteeringTypeId.ToString().Contains(SteeringType));
                }
                if (FuelType != "undefined" && FuelType != null)
                {
                    makeobj = makeobj.Where(x => x.FuelTypeId.ToString().Contains(FuelType));
                }
                if (DriveWheelType != "undefined" && DriveWheelType != null)
                {
                    makeobj = makeobj.Where(x => x.DriveWheelType.ToString().Contains(DriveWheelType));
                }
               
                var total = await makeobj.CountAsync();
                makeobj = makeobj.Page(CurrentPageNo, RecordPerPage);
                makeobj = makeobj.OrderByDescending(w => w.CreatedAt);

                var result = makeobj.Select(z => new VehicleResponseModel
                {
                    ID = z.Id,
                    MakeId = z.MakesId,
                    Name=z.Name,
                    ModelId = z.VehicleModelsId,
                    MakeName = z.Makes == null ? "" : z.Makes.Name,
                    ModelName = z.VehicleModels == null ? "" : z.VehicleModels.Name,
                    CarType = z.sys_drop_down_value1.ValueInNorwegian,
                    Description = z.Description,
                    DriveWheelType = z.DriveWheelType,
                    FuelType = z.sys_drop_down_value.ValueInNorwegian,
                    NoOfDoor = z.NoOfDoor,
                    NoOfSeat = z.NoOfSeatId,
                    SteeringType = z.sys_drop_down_value2.ValueInNorwegian,
                    TankCapacity = z.TankCapacity,
                    CarImage = "",
                    VehicleImage = z.VehicleImage.Where(a => !a.IsDeleted).Select(z => new VehicleImageResponse
                    {
                        Id = z.Id,
                        Image = z.ImageURL
                    }).ToList(),
                    VehiclePartRequest = z.VehiclePart.Where(a => !a.IsDeleted).Select(z => new VehiclePartRequest
                    {
                        Id = z.Id,
                        DropDownId = z.DropDownId,
                        IsChecked = z.IsChecked,
                    }).ToList(),
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<VehicleResponseModel>>(result, total);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<List<VehicleResponseModel>>> GetVehicleList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var makeobj = _repository.Vehicle.FindAll().Where(a => a.IsDeleted == false).Include(a => a.Makes)
                    .Include(a => a.VehicleImage).Include(a => a.VehiclePart)
                    .Include(a => a.VehicleModels).Include(a => a.sys_drop_down_value)
                    .Include(a => a.sys_drop_down_value1).Include(a => a.sys_drop_down_value2).AsQueryable();
                if (!string.IsNullOrEmpty(SearchText))
                {
                    makeobj = makeobj.Where(x => x.Makes.Name.ToLower().Contains(SearchText.ToLower()));
                }
                var total = await makeobj.CountAsync();
                makeobj = makeobj.Page(CurrentPageNo, RecordPerPage);
                makeobj = makeobj.OrderByDescending(w => w.CreatedAt);

                var result = makeobj.Select(z => new VehicleResponseModel
                {
                    ID = z.Id,
                    MakeId = z.MakesId,
                    ModelId = z.VehicleModelsId,
                    MakeName = z.Makes == null ? "" : z.Makes.Name,
                    ModelName = z.VehicleModels == null ? "" : z.VehicleModels.Name,
                    CarType = z.sys_drop_down_value1.ValueInNorwegian,
                    Description = z.Description,
                    DriveWheelType = z.DriveWheelType,
                    FuelType = z.sys_drop_down_value.ValueInNorwegian,
                    NoOfDoor = z.NoOfDoor,
                    NoOfSeat = z.NoOfSeatId,
                    SteeringType = z.sys_drop_down_value2.ValueInNorwegian,
                    TankCapacity = z.TankCapacity,
                    CarImage = "",
                    VehicleImage = z.VehicleImage.Where(a => !a.IsDeleted).Select(z => new VehicleImageResponse
                    {
                        Id = z.Id,
                        Image = z.ImageURL
                    }).ToList(),
                    VehiclePartRequest = z.VehiclePart.Where(a => !a.IsDeleted).Select(z => new VehiclePartRequest
                    {
                        Id = z.Id,
                        DropDownId = z.DropDownId,
                        IsChecked = z.IsChecked,
                    }).ToList(),
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<VehicleResponseModel>>(result, total);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
