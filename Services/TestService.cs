using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;

namespace Services
{
    public class TestService : Service<Class2>, IServiceTest
    {
       
            public TestService(IUnitOfWork utwk) : base(utwk)
            {
            }

        //Implementation of custom methods
        /*public DateTime DatePremierChampionat(Equipe e)
        {
            return e.Trophees.Where(t => t.TypeTrophee == TypeTrophee.Championnat)
                .OrderBy(t => t.DateTrophee).First().DateTrophee;
        }*/
    }
}
