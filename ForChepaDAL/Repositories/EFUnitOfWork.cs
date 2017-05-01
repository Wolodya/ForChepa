using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForChepaDAL.EF;
using ForChepaDAL.Interfaces;
using ForChepaDAL.Entities;


namespace ForChepaDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private TopographyContext tc;
        private CitiesRepository citiesRepository;
        private CountriesRepository countriesRepository;
        private ThirdRepository thirdRepository;
        public EFUnitOfWork(string connString)
        {
            tc = new TopographyContext(connString); 
        }
        public IRepository<Cities> Cities
        {
            get
            {
                if (citiesRepository==null)
                {
                    citiesRepository = new CitiesRepository(tc);
                }
                return citiesRepository;
            }
        }

        public IRepository<Countries> Countries
        {
            get
            {
                if (countriesRepository == null)
                {
                    countriesRepository = new CountriesRepository(tc);
                }
                return countriesRepository;
            }
        }

        public IRepository<Third> Third
        {
            get
            {
                if (thirdRepository == null)
                {
                    thirdRepository = new ThirdRepository(tc);
                }
                return thirdRepository;
            }
        }

      public  void Save()
        {
            tc.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    tc.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EFUnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

       
        #endregion
    }
}
