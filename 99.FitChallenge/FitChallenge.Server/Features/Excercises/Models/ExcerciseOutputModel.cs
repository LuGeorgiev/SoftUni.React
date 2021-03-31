using AutoMapper;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Data.Models.Enums;
using FitChallenge.Server.Infrastructure.Mapping;

namespace FitChallenge.Server.Features.Excercises.Models
{
    public class ExcerciseOutputModel: IMapFrom<Excercise>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Url { get; set; }

        public ExcerciseType ExcerciseType { get; set; }

        public ExcerciseDifficulty ExcerciseDifficulty { get; set; }

        //public void Mapping(AutoMapper.Profile mapper)
        //    => mapper.CreateMap<Excercise, ExcerciseOutputModel>()
        //    .ForMember(e => e.ExcerciseDifficulty, cfg => cfg.MapFrom)
    }
}
