using AutoMapper;

namespace FitChallenge.Server.Infrastructure.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }
}
