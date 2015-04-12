
namespace HeroisDoCancer.Models
{
    /// <summary>
    /// Define as situações possível do evento.
    /// </summary>
    public enum TipoSituacaoEnum
    {
        /// <summary>
        /// Evento foi criado mas ainda não confirmado com o hospital.
        /// </summary>
        EmElaboracao = 1,

        /// <summary>
        /// Evento foi confirmado com o hospital e é possível de realizar.
        /// </summary>
        Confirmado = 2,

        /// <summary>
        /// Evento não tem mais espaço para participantes.
        /// </summary>
        Completo = 3,

        /// <summary>
        /// Evento foi realizado no hospital.
        /// </summary>
        Realizado = 4,

        /// <summary>
        /// Evento foi cancelado.
        /// </summary>
        Cancelado = 5
    }
}