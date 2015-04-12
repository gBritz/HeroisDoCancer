using HeroisDoCancer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroisDoCancer.ContextoDados
{
    public class ContextoEmMemoria : IContextoDados
    {
        private static readonly Object locker = new Object();
        private static Boolean iniciado;
        private static List<Voluntario> voluntarios;
        private static List<Hospital> hospitais;
        private static List<Comentario> comentarios;
        private static List<Evento> eventos;

        public ContextoEmMemoria()
        {
            IniciarDados();
        }

        public IQueryable<Voluntario> Voluntarios
        {
            get { return voluntarios.AsQueryable(); }
        }

        public IQueryable<Evento> Eventos
        {
            get { return eventos.AsQueryable(); }
        }

        public void Adiciona<TModel>(TModel model) where TModel : class
        {
            lock (locker)
            {
                ObterModelosPelo<TModel>().Add(model);
            }
        }

        public void Remove<TModel>(TModel model) where TModel : class
        {
            lock (locker)
            {
                ObterModelosPelo<TModel>().Remove(model);
            }
        }

        public void Publica() { }

        private static List<TModel> ObterModelosPelo<TModel>()
        {
            var tipo = typeof(TModel);
            if (tipo == typeof(Voluntario))
            {
                return voluntarios as List<TModel>;
            }
            else if (tipo == typeof(Hospital))
            {
                return hospitais as List<TModel>;
            }
            else if (tipo == typeof(Comentario))
            {
                return comentarios as List<TModel>;
            }
            else if (tipo == typeof(Evento))
            {
                return eventos as List<TModel>;
            }

            throw new Exception("Dados não implementados para o tipo " + tipo.Name);
        }

        private static void IniciarDados()
        {
            if (!iniciado)
            {
                lock (locker)
                {
                    if (!iniciado)
                    {
                        PopularDados();
                        iniciado = true;
                    }
                }
            }
        }

        private static void PopularDados()
        {
            hospitais = new List<Hospital> 
            {
                new Hospital()
                {
                    Id = 1,
                    Nome = "Hospital de Clínicas UFRGS",
                    Endereco = "Rua Ramiro Barcelos, 2350",
                    latitude = "-30.039119",
                    longitude = "-51.207156",
                    Site = "http://www.hcpa.ufrgs.br",
                    Telefone = "(51)3359-8000"
                },
                new Hospital()
                {
                    Id = 2,
                    Nome = "Hospital São Lucas da PUC-RS",
                    Endereco = "Av. Ipiranga, 6690",
                    latitude = "-30.0555189",
                    longitude = "-51.1704967",
                    Site = "http://www.hospitalsaolucas.pucrs.br",
                    Telefone = "(51)3320-3000"
                },
                new Hospital()
                {
                    Id = 3,
                    Nome = "Hospital Fêmina S/A (Unacon)",
                    Endereco = "Rua Mostardeiro, 17",
                    latitude = "-30.029233",
                    longitude = "-51.206919",
                    Site = "http://www.femina.com.br",
                    Telefone = "(51)3314-5200"
                },
                new Hospital()
                {
                    Id = 4,
                    Nome = "Complexo Hospitalar Santa Casa",
                    Endereco = "Rua Professor Annes Dias, 295",
                    latitude = "-30.029761",
                    longitude = "-51.220184",
                    Site = "http://www.santacasa.org.br/pt",
                    Telefone = "(51)3214-8000"
                },
                new Hospital()
                {
                    Id = 5,
                    Nome = "Hospital Nossa Senhora da Conceição S/A",
                    Endereco = "Av. Francisco Trein, 596",
                    latitude = "-30.015932",
                    longitude = "-51.158867",
                    Site = "http://www.ghc.com.br/default.asp?idMenu=unidades_hnsc",
                    Telefone = "(51)3357-2000"
                }
            };

            comentarios = new List<Comentario> 
            {
                new Comentario()
                {
                    Id = 1,
                    Nome = "Maria da Silva",
                    Voluntario = null,
                    Evento = null,
                    Descricao = "Minutos antes de eu passar pela minha primeira quimioterapia, uma voluntária veio até mim, segurou forte na minha mão e disse: ‘vai dar tudo certo’. Aquilo me deu uma força enorme. A partir daquele momento, senti que tudo ia realmente dar certo."
                },
                new Comentario()
                {
                    Id = 2,
                    Nome = "João da Silva",
                    Voluntario = null,
                    Evento = null,
                    Descricao = "Fiquei muito feliz ao receber a visita daquelas pessoas que vieram ao hospital e leram várias histórias legais."
                }
            };

            eventos = new List<Evento> 
            {
                new Evento
                {
                    Id = 1,
                    Nome = "Festa de aniversário",
                    DataHora = DateTime.Now.AddDays(2),
                    NroMaximoParticipantes = 4,
                    NroParticipantesRestantes = 4,
                    CriadoEm = new DateTime(2015, 04, 12, 01, 00, 00),
                    Descricao = "Venha participar da festa de aniversário, que acontecerá neste dia 12 de abril.",
                    IdHospital = 1,
                    Hospital = hospitais[0],
                    TipoSituacao = TipoSituacaoEnum.Confirmado
                },
                new Evento
                {
                    Id = 2,
                    Nome = "Leitura em grupo",
                    DataHora = DateTime.Now.AddDays(3),
                    NroMaximoParticipantes = 4,
                    NroParticipantesRestantes = 3,
                    CriadoEm = new DateTime(2015, 04, 12, 01, 00, 00),
                    Descricao = @"Promovemos um encontro para compartilhar o que mais gostamos de fazer: ler livros!
                            Cada encontro, um livro diferente; várias perspectivas.",
                    IdHospital = 1,
                    Hospital = hospitais[0],
                    TipoSituacao = TipoSituacaoEnum.Confirmado
                },
                new Evento
                {
                    Id = 3,
                    Nome = "Dia do Herói",
                    DataHora = DateTime.Now.AddDays(5),
                    NroMaximoParticipantes = 4,
                    NroParticipantesRestantes = 4,
                    CriadoEm = new DateTime(2015, 04, 12, 01, 00, 00),
                    Descricao = @"Venha fantasiado de herói, para fazermos uma festa fantasia.",
                    IdHospital = 1,
                    Hospital = hospitais[0],
                    TipoSituacao = TipoSituacaoEnum.Confirmado
                }
            };

            voluntarios = new List<Voluntario> 
            {
                new Voluntario 
                {
                    Id = 1,
                    Login = "britz",
                    Nome = "Guilherme Britz Videira",
                    Email = "gbritzv@gmail.com",
                    Eventos = new List<Evento>(),
                    Foto = "https://avatars3.githubusercontent.com/u/4161527?v=3&s=40",
                    Senha = "123456"
                }            
            };
        }
    }
}