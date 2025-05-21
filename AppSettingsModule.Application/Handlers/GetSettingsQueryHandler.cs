using AppSettingsModule.Contracts.DTOs;
using AppSettingsModule.Contracts.Queries;
using AppSettingsModule.Contracts.Repositories;
using MediatR;
using Shared.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingsModule.Application.Handlers
{
    public class GetSettingsQueryHandler : IRequestHandler<GetSettingsQuery, SettingsDto>
    {
        private readonly ISettingsRepository _settingsRepository;

        public GetSettingsQueryHandler(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }
        public async Task<SettingsDto> Handle(GetSettingsQuery request, CancellationToken cancellationToken)
        {
            var settings = await _settingsRepository.GetSettingsByUserIdAsync(request.userId)
               ?? throw new NotFound("Settings not found");

            return new SettingsDto(settings);
        }
    }
}
