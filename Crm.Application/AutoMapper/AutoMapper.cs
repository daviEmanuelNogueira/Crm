using AutoMapper;
using Crm.Application.Requests;
using Crm.Application.ViewModel;
using Crm.Application.ViewModel.Motivo;
using Crm.Domain.Entities;
using System.Reflection;

namespace Crm.Application.AutoMapper
{
    public class AutoMapperSetup:Profile
    {
        public AutoMapperSetup() 
        {
            #region ViewModelToDomain

            CreateMap<CreateStatusSubstatusRequestVM, StatusSubstatus>();
            CreateMap<StatusSubstatusResponseVM, StatusSubstatus>();
            CreateMap<StatusSubstatusResponseVM, StatusSubstatus>();

            CreateMap<StatusVM, Status>();
            CreateMap<MotivoVM, Motivo>();
            CreateMap<SubstatusVM,Substatus>();
            CreateMap<AtendimentoVM,Atendimento>();

            #endregion

            #region DomainToViewModel
            CreateMap<StatusSubstatus, CreateStatusSubstatusRequestVM>();
            CreateMap<StatusSubstatus, StatusSubstatusResponseVM>();
            CreateMap<Status, StatusVM>();
            CreateMap<Substatus, SubstatusVM>();
            CreateMap<Motivo, MotivoVM>();

            #endregion
        }

    }
}
