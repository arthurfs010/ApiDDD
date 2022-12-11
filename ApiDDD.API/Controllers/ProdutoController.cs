using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDDD.Application;
using ApiDDD.Application.DTO;
using ApiDDD.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet("{codigo}")]
        public ActionResult<string> Get(int codigo)
        {
            return Ok(_applicationServiceProduto.GetByCodigo(codigo));
        }

        [HttpGet]
        public ActionResult<string> GetAll()
        {
            return Ok(_applicationServiceProduto.GetAll());
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Add(produtoDTO);
                return Ok("Produto salvo com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();
                
                _applicationServiceProduto.Update(produtoDTO);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Remove(produtoDTO);
                return Ok("Produto inativado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

