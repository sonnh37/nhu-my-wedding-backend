﻿using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories;
using NM.Studio.Domain.Contracts.Services;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Results;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services;

public class PhotoService : BaseService<Photo>, IPhotoService
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoService(IMapper mapper,
        IUnitOfWork unitOfWork)
        : base(mapper, unitOfWork)
    {
        _photoRepository = _unitOfWork.PhotoRepository;
    }

    public async Task<MessageResults<PhotoResult>> GetAll(PhotoGetAllQuery x,
        CancellationToken cancellationToken = default)
    {
        var photos = await _photoRepository.GetAllWithInclude(x, cancellationToken);
        // map 
        var content = _mapper.Map<IList<Photo>, List<PhotoResult>>(photos);
        var msgResults = AppMessage.GetMessageResults(content);

        return msgResults;
    }
}