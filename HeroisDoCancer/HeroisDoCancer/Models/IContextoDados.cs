using System.Linq;

namespace HeroisDoCancer.Models
{
    public interface IContextoDados
    {
        IQueryable<Voluntario> Voluntarios { get; }

        IQueryable<Evento> Eventos { get; }

        void Adiciona<TModel>(TModel model) where TModel : class;

        void Remove<TModel>(TModel model) where TModel : class;

        void Publica();
    }
}