using AAPC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAPC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcAAPCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcAAPCContext>>()))
            {
                // Look for any movies.
                if (context.ParticipanteTreinoTerca.Any())
                {
                    return;   // DB has been seeded
                }

                context.ParticipanteTreinoTerca.AddRange(
                    new TreinoTerca
                    {
                        Nome = "Gisele",
                        Sobrenome = "Souza",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoTerca
                    {
                        Nome = "Marina",
                        Sobrenome = "Rodrigues",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoTerca
                    {
                        Nome = "João",
                        Sobrenome = "Nascimento",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoTerca
                    {
                        Nome = "Romario",
                        Sobrenome = "Santos",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    }
                );
                context.SaveChanges();
            }

            using (var context = new MvcAAPCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcAAPCContext>>()))
            {
                // Look for any movies.
                if (context.ParticipanteTreinoQuinta.Any())
                {
                    return;   // DB has been seeded
                }

                context.ParticipanteTreinoQuinta.AddRange(
                    new TreinoQuinta
                    {
                        Nome = "Juliana",
                        Sobrenome = "Morais",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoQuinta
                    {
                        Nome = "Lucas",
                        Sobrenome = "Silva",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoQuinta
                    {
                        Nome = "Camila",
                        Sobrenome = "Paraguaçu",
                        Nascimento = DateTime.Parse("1995-2-12"),
                    },

                    new TreinoQuinta
                    {
                        Nome = "Israel",
                        Sobrenome = "Barreto",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    }
                );
                context.SaveChanges();
            }

            using (var context = new MvcAAPCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcAAPCContext>>()))
            {
                // Look for any movies.
                if (context.ParticipanteTreinoSabado.Any())
                {
                    return;   // DB has been seeded
                }

                context.ParticipanteTreinoSabado.AddRange(
                    new TreinoSabado
                    {
                        Nome = "Mauricio",
                        Sobrenome = "Oliveira",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoSabado
                    {
                        Nome = "Talita",
                        Sobrenome = "Nogueira",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoSabado
                    {
                        Nome = "Ragnar",
                        Sobrenome = "Lothbrok",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    },

                    new TreinoSabado
                    {
                        Nome = "Diana",
                        Sobrenome = "De Temiscera",
                        Nascimento = DateTime.Parse("1989-2-12"),
                    }
                );
                context.SaveChanges();
            }

            using (var context = new MvcAAPCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcAAPCContext>>()))
            {
                // Look for any movies.
                if (context.Treino.Any())
                {
                    return;   // DB has been seeded
                }

                context.Treino.AddRange(
                    new Treino
                    {
                        Dia = "Terça-Feira",
                        Horario = "20:00h",
                        Local = "Imbui"
                        //Genre = "Romantic Comedy",
                        //Price = 7.99M
                    },

                    new Treino
                    {
                        Dia = "Quinta-Feira",
                        Horario = "20:00h",
                        Local = "Imbui"
                        //Genre = "Romantic Comedy",
                        //Price = 7.99M
                    },

                    new Treino
                    {
                        Dia = "Sabado",
                        Horario = "19:30h",
                        Local = "Imbui"
                        //Genre = "Romantic Comedy",
                        //Price = 7.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
