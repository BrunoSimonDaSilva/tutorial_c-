using Microsoft.EntityFrameworkCore;
using selecao.Data;
using selecao.Models;
using System.Collections.Generic;
using System.Linq;

namespace selecao.Service
{
    public class ServiceSelecao : IServiceSelecao
    {

        private readonly BaseContext _baseContext;
        public ServiceSelecao(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }


        public Time Create(Time time)
        {
            _baseContext.Add(time);
            _baseContext.SaveChanges();
            return time;
        }

        public bool Delete(int id)
        {
            Time time = GetById(id);
            try
            {
                _baseContext.Remove(time);
                _baseContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<Time> GetAll()
        {
            var time = _baseContext.Time.ToList();
            return time;
        }

        public Time GetById(int id)
        {
            Time time = _baseContext.Time.FirstOrDefault(m => m.Id == id);
            return time;
        }

        public Time Update(Time time)
        {
            try
            {
                Time UpTime = GetById(time.Id);
                UpTime.Nome = time.Nome;
                UpTime.Titulos = time.Titulos;
                _baseContext.Update(UpTime);
                _baseContext.SaveChanges();
                return UpTime;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
