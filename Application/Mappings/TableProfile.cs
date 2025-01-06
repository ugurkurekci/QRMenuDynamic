using Application.DTOs.Table;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<CreateTableDto, Table>()
            .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateTime.Now));

        CreateMap<Table, TableDto>();
    }
}