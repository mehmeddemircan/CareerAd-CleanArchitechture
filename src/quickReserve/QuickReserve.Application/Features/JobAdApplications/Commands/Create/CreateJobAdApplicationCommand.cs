using AutoMapper;
using CloudinaryDotNet;
using Core.Constants;
using Core.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using QuickReserve.Application.Features.JobAdApplications.Dtos;
using QuickReserve.Application.Features.JobAdApplications.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Application.Services.CloudinaryService;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdApplications.Commands.Create
{
    public partial class CreateJobAdApplicationCommand : IRequest<IDataResult<CreatedJobAdApplicationDto>>
    {
        public int JobAdId { get; set; }
        public int UserId { get; set; }

        // Kullanıcıdan gelen CV dosyası
        public IFormFile CvFile { get; set; }

        public class CreateJobAdApplicationCommandHandler : IRequestHandler<CreateJobAdApplicationCommand, IDataResult<CreatedJobAdApplicationDto>>
        {
            private readonly IJobAdApplicationRepository _jobadapplicationRepository;
            private readonly IMapper _mapper;
            private readonly JobAdApplicationBusinessRules _jobadapplicationBusinessRules;
            private readonly ICloudinaryService _cloudinaryService;
            public CreateJobAdApplicationCommandHandler(IJobAdApplicationRepository jobadapplicationRepository, IMapper mapper,
                                             JobAdApplicationBusinessRules jobadapplicationBusinessRules, ICloudinaryService cloudinaryService)
            {
                _jobadapplicationRepository = jobadapplicationRepository;
                _mapper = mapper;
                _jobadapplicationBusinessRules = jobadapplicationBusinessRules;
                _cloudinaryService = cloudinaryService;
            }

            public async Task<IDataResult<CreatedJobAdApplicationDto>> Handle(CreateJobAdApplicationCommand request, CancellationToken cancellationToken)
            {
                //await _jobadapplicationBusinessRules.JobAdApplicationNameCanNotBeDuplicatedWhenInserted(request.Name);
                // Cloudinary'ye CV dosyasını yükleyin
                var uploadResult = await _cloudinaryService.UploadPdfToCloudinaryAsync(request.CvFile);


                // Upload sonucunu kontrol et
                if (uploadResult == null || string.IsNullOrEmpty(uploadResult.PublicId))
                {
                    return new ErrorDataResult<CreatedJobAdApplicationDto>("CV yükleme başarısız oldu.");
                }

                // JobAdApplication nesnesini oluşturun ve Cloudinary'den gelen bilgileri atayın
                var jobAdApplication = new JobAdApplication
                {
                    JobAdId = request.JobAdId,
                    UserId = request.UserId,
                    CvPdfPublicId = uploadResult.PublicId,  // Cloudinary'den gelen PublicId'yi kullanın
                    CvPdfUrl = uploadResult.SecureUrl.ToString()  // Cloudinary'den gelen URL'yi kullanın
                };

                JobAdApplication mappedEntity = _mapper.Map<JobAdApplication>(jobAdApplication);
                JobAdApplication createJobAdApplication = await _jobadapplicationRepository.AddAsync(mappedEntity);
                CreatedJobAdApplicationDto createdJobAdApplicationDto = _mapper.Map<CreatedJobAdApplicationDto>(createJobAdApplication);
                return new SuccessDataResult<CreatedJobAdApplicationDto>(createdJobAdApplicationDto, ResultMessages.Added);
            }
        }
    }
}
