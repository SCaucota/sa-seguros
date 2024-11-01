using sa_bitsion_DAL;
using sa_bitsion_DAL.Models;
using sa_bitsion_DAL.Repository;
using System.Collections.Generic;

namespace sa_bitsion_BLL
{
    public class ClienteService
    {
        public void AgregarCliente(Cliente cliente)
        {
            ClienteRepository.AgregarCliente(cliente);
        }

        public List<Cliente> ObtenerClientes()
        {
            return ClienteRepository.ObtenerClientes();
        }

        public Cliente ObtenerClientePorDni(int dni)
        {
            return ClienteRepository.ObtenerClientePorDni(dni);
        }

        public bool DniExistente(int dni)
        {
            return ClienteRepository.DniExistente(dni);
        }

        public void EliminarCliente(int dni)
        {
            ClienteRepository.EliminarCliente(dni);
        }

        public void EditarCliente(int dniOriginal, Cliente cliente)
        {
            ClienteRepository.EditarCliente(dniOriginal, cliente);
        }
    }
}