﻿using CMS.Studio.Domain.Contracts.Services;
using CMS.Studio.Domain.CQRS.Queries.Photos;
using CMS.Studio.Domain.Models.Responses;
using CMS.Studio.Domain.Models.Results;

using MediatR;

namespace CMS.Studio.Handler.Queries;

public class PhotoQueryHandler : 
    IRequestHandler<PhotoGetAllQuery, PaginatedResponse<PhotoResult>>,
    IRequestHandler<PhotoGetByIdQuery, ItemResponse<PhotoResult>>
{
    protected readonly IPhotoService _photoService;

    public PhotoQueryHandler(IPhotoService photoService)
    {
        _photoService = photoService;
    }

    public async Task<PaginatedResponse<PhotoResult>> Handle(PhotoGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _photoService.GetAll(request);
    }

    public async Task<ItemResponse<PhotoResult>> Handle(PhotoGetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _photoService.GetById<PhotoResult>(request.Id);
    }
}