using sa_bitsion_BLL;
using sa_bitsion_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sa_bitsion.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteService _clienteService = new ClienteService();

        
        public ActionResult Index()
        {
            return View(new Cliente());
        }

        [HttpGet]
        public ActionResult ObtenerClientes()
        {
            List<Cliente> listaClientes = _clienteService.ObtenerClientes();

            return View("Clientes", listaClientes);
        }

        [HttpGet]
        public ActionResult ObtenerClientePorDni(int dni)
        {
            Cliente clienteAEditar = _clienteService.ObtenerClientePorDni(dni);

            return View("EditarCliente",clienteAEditar);
        }

        [HttpPost]
        public ActionResult AgregarCliente(Cliente cliente)
        {

            if (_clienteService.DniExistente(cliente.DNI))
            {
                ModelState.AddModelError("DNI", "El DNI ingresado ya existe");
            }

            if (ModelState.IsValid)
            {
                _clienteService.AgregarCliente(cliente);
                TempData["Message"] = "El cliente se agregó correctamente";
                TempData["MessageType"] = "success";
                cliente = new Cliente();
            }
            else
            {
                TempData["Message"] = "Hubo un error al agregar el cliente. Revise que todos los campos cumpla con los ";
                TempData["MessageType"] = "danger";
            }

            return View("Index", cliente);
        }

        [HttpPost]
        public ActionResult EliminarCliente(int dniCliente)
        {
            _clienteService.EliminarCliente(dniCliente);
            TempData["MessageTable"] = "Cliente eliminado correctamente";
            TempData["MessageType"] = "success";

            return RedirectToAction("ObtenerClientes");
        }

        [HttpPost]
        public ActionResult EditarCliente(int dniOriginal, Cliente cliente)
        {   
            if(cliente.DNI != dniOriginal)
            {
                if (_clienteService.DniExistente(cliente.DNI))
                {
                    ModelState.AddModelError("DNI", "El DNI ingresado ya existe");
                }
            }

            if (ModelState.IsValid)
            {
                _clienteService.EditarCliente(dniOriginal, cliente);
                TempData["MessageTable"] = "La información del cliente se editó exitosamente";
                TempData["MessageType"] = "success";
                return RedirectToAction("ObtenerClientes");
            }

            TempData["MessageErrorEdit"] = "Hubo un error al agregar el cliente. Revise que todos los campos cumpla con los requisitos";
            TempData["MessageType"] = "danger";
            return View("EditarCliente", cliente);
        }
    }
}