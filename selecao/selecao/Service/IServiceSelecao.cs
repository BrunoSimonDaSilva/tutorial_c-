using selecao.Models;
using System.Collections.Generic;

namespace selecao.Service
{
    public interface IServiceSelecao
    {
        public Time Create(Time time);
        public List<Time> GetAll();
        public Time GetById(int id);
        public Time Update(Time time);
        public bool Delete(int id);
    }
}
