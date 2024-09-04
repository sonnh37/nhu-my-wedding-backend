﻿using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Queries.Services;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;

using MediatR;

namespace CMS.Studio.Handler.Queries;

public class ServiceQueryHandler :
    IRequestHandler<ServiceGetAllQuery, PaginatedResponse<ServiceResult>>,
    IRequestHandler<ServiceGetByIdQuery, ItemResponse<ServiceResult>>
{
    protected readonly IServiceService _serviceService;

    public ServiceQueryHandler(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<PaginatedResponse<ServiceResult>> Handle(ServiceGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _serviceService.GetAll(request);
    }

    public async Task<ItemResponse<ServiceResult>> Handle(ServiceGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _serviceService.GetById<ServiceResult>(request.Id);
    }
}