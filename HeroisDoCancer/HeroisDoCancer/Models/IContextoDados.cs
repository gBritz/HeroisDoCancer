using System.Collections.Generic;

namespace HeroisDoCancer.Models
{
    public interface IContextoDados
    {
        ICollection<Voluntario> Voluntarios { get; }

        void Adiciona<TModel>(TModel model) where TModel : class;

        void Remove<TModel>(TModel model) where TModel : class;

        void Publica();
    }
}