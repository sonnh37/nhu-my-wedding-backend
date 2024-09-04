﻿using AutoMapper;
using CMS.Studio.Domain.Contracts.Repositories;
using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.Contracts.UnitOfWorks;
using CMS.Studio.Domain.CQRS.Queries.Services;
using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;
using CMS.Studio.Domain.Utilities;
using CMS.Studio.Services.Bases;

namespace CMS.Studio.Services;

public class ServiceService : BaseService<Service>, IServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _serviceRepository = _unitOfWork.ServiceRepository;
    }

    public async Task<PaginatedResponse<ServiceResult>> GetAll(ServiceGetAllQuery x)
    {
        var photoWithTotal = await _serviceRepository.GetAll(x);
        var photosResult = _mapper.Map<List<ServiceResult>>(photoWithTotal.Item1);
        var photosResultWithTotal = (photosResult, photoWithTotal.Item2);

        return AppResponse.CreatePaginated(photosResultWithTotal, x);
    }
}